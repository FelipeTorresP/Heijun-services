using System;
using System.Collections.Generic;

namespace HeijunDomain.DocumentTemplate
{
    public class ListElements
    {
        public ListElements(string key, string label, string elements, string required)
        {
            this.key = key;
            this.label = label;
            if (required.Equals("true"))
            {
                this.required = true;
            }
            else
            {
                this.required = false;
            }
            this.elements = new List<string>();
            this.SetElements(elements);
        }

        private void SetElements(string elements)
        {
           var elementsArray = elements.Split("%");
            foreach (var element in elementsArray)
            {
                this.elements.Add(element);
            }
        }

        public string key { get; private set; }
        public string label { get; private set; }

        public List<string> elements { get; private set; }
        public bool required { get; private set; }
    }
}