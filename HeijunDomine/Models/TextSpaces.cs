namespace HeijunDomain.DocumentTemplate
{
    public class TextElement
    {
        public TextElement(string key, string label, string required)
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
            
        }
        public string key { get; private set; }
        public string label { get; private set; }
        public bool required { get; private set; }
    }
}