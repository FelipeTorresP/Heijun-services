using System.Collections.Generic;

namespace HeijunDomain.DocumentTemplate
{
    public class StructureDocument
    {
        public List<TextElement> textElements { get; private set; }
        public List<DateElement> dateElements { get; private set; }
        public List<ListElements> listElements { get; private set; }

        public StructureDocument(List<TextElement> textElements, List<DateElement> dateElements, List<ListElements> listElements)
        {
            this.textElements = textElements;
            this.dateElements = dateElements;
            this.listElements = listElements;
        }
    }
}