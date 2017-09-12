using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace Lori.Domain.Texts
{
    public class TextsReader
    {
        public const string Greeting = "greeting";

        private const string TextFileResourseName = "";

        public IEnumerable<LocalizedText> Get(string group)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(TextFileResourseName);

            var xml = new XmlDocument();
            if (stream == null)
            {
                yield break;
            }

            xml.Load(stream);

            var all = xml.GetElementsByTagName("Text");
            foreach (XmlNode text in all)
            {
                if (text.Attributes?["Name"].Value == group)
                {
                    foreach (XmlNode localization in text.ChildNodes)
                    {
                        if (localization.Name == "Localization")
                        {
                            if (text.Attributes?["Locale"] != null)
                            {
                                yield return new LocalizedText
                                {
                                    Locale = text.Attributes?["Locale"].Value,
                                    Text = text.Value
                                };
                            }
                        }
                    }
                }
            }
        }
    }

    public class LocalizedText
    {
        public string Locale { get; set; }

        public string Text { get; set; }
    }
}
