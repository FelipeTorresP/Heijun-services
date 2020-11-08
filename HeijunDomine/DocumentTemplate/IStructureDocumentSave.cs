using System.Collections.Generic;

namespace HeijunDomain.DocumentTemplate
{
    public interface IStructureDocumentSave
    {
        List<DateElement> GetDateElements(string input);
        List<ListElements> GetListElements(string input);
        List<TextElement> GetTextBoxSpaces(string input);
        void SaveStructureDocument(string pathfile);
    }
}