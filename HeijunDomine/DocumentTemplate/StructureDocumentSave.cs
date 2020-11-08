

using Newtonsoft.Json;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace HeijunDomain.DocumentTemplate
{
    public class StructureDocumentSave : IStructureDocumentSave
    {
        public StructureDocumentSave()
        {

        }

        public void SaveStructureDocument(string pathfile)
        {
            FileStream fileStreamPath = new FileStream(pathfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            WordDocument document = new WordDocument(fileStreamPath, FormatType.Automatic);
            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Txt);
            document.Close();
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            List<TextElement> textElements = this.GetTextBoxSpaces(text);
            List<DateElement> dateElements = this.GetDateElements(text);
            List<ListElements> listElements = this.GetListElements(text);
            StructureDocument structureDocument = new StructureDocument(textElements, dateElements, listElements);
            string json = JsonConvert.SerializeObject(structureDocument);

            //write string to file
            System.IO.File.WriteAllText(@".\structureText.json", json);


        }

        public List<TextElement> GetTextBoxSpaces(string input)
        {
            List<TextElement> textSpaces = new List<TextElement>();
            string pattern = @"(?<=%t%)(.*)(?=%t%)";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                string[] propierities = m.Value.Split("//");
                textSpaces.Add(new TextElement(propierities[0].Replace(" ", ""), propierities[0], propierities[1]));
            }
            return textSpaces.GroupBy(x => x.key).Select(g => g.First()).ToList();
        }

        public List<ListElements> GetListElements(string input)
        {
            List<ListElements> listElements = new List<ListElements>();
            string pattern = @"(?<=%l%)(.*)(?=%l%)";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                string[] propierities = m.Value.Split("//");
                listElements.Add(new ListElements(propierities[0].Replace(" ", ""), propierities[0], propierities[1], propierities[2]));
            }
            return listElements.GroupBy(x => x.key).Select(g => g.First()).ToList();
        }

        public List<DateElement> GetDateElements(string input)
        {
            List<DateElement> listElements = new List<DateElement>();
            string pattern = @"(?<=%d%)(.*)(?=%d%)";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                string[] propierities = m.Value.Split("//");
                listElements.Add(new DateElement(propierities[0].Replace(" ", ""), propierities[0], propierities[1]));
            }
            return listElements.GroupBy(x => x.key).Select(g => g.First()).ToList();
        }
    }
}
