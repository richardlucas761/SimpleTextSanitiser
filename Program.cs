using System;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace SimpleTextSanitiser
{
    public class Program
    {
        private const string NoInputFoundToSanitise = "No input found to sanitise.";
        private const string ScriptNodeName = "script";

        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            // Read in text input from standard input
            var inputText = new StringBuilder();
            var inputLine = Console.ReadLine();

            while (inputLine != null)
            {
                inputText.AppendLine(inputLine);
                inputLine = Console.ReadLine();
            }

            // Validate the input
            if (inputText == null) throw new Exception(NoInputFoundToSanitise);

            // Write sanitised output to standard output
            var outputText = SanitiseInput(inputText);
            Console.Write(outputText);
        }

        public static string SanitiseInput(StringBuilder inputString)
        {
            if (inputString == null) throw new ArgumentException(nameof(inputString));

            // Parse the input text using HTML Agility Pack
            var doc = new HtmlDocument();
            doc.LoadHtml(inputString.ToString());

            // Read all of the nodes from the document which aren't a script
            var nodes = from getnode in doc.DocumentNode.ChildNodes where getnode.Name.ToLowerInvariant() != ScriptNodeName select getnode;

            // Rebuild the text from the collection and return it
            var outputStringBuilder = new StringBuilder();
            foreach (var node in nodes)
            {
                outputStringBuilder.Append(node.InnerText);
            }

            return outputStringBuilder.ToString();
        }
    }
}
