using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS_SE_Tool.Save.Items
{
    internal class SiiNBlockCore
    {
        //Original block lines as read from the save (header and closing bracket included)
        internal List<string> sourceLines { get; set; } = null;

        //Attributes which failed to parse - always written back from source
        internal HashSet<string> unparsedAttributes { get; set; } = new HashSet<string>();

        internal void removeWritenBlock(string _input)
        {
            FormMain.SiiNunitData.NamelessControlList.Remove(_input);
        }

        internal void markUnparsed(string _tagLine)
        {
            unparsedAttributes.Add(AttributeName(_tagLine));
        }

        //"wheels_wear[3]" -> "wheels_wear"
        internal static string AttributeName(string _tagLine)
        {
            int bracket = _tagLine.IndexOf('[');

            return (bracket < 0 ? _tagLine : _tagLine.Substring(0, bracket)).Trim();
        }

        //Write attributes in source order. Known attributes are taken from generated output (to keep edits),
        //unknown or unparsed ones are copied from source, attributes absent in source are dropped.
        internal string MergeWithSource(string _generated)
        {
            if (sourceLines == null || sourceLines.Count < 2)
                return _generated;

            List<string> generatedLines = _generated.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();

            int headerIndex = generatedLines.FindIndex(x => x.Contains('{'));

            if (headerIndex < 0)
                return _generated;

            Dictionary<string, List<string>> generatedAttributes = new Dictionary<string, List<string>>();

            for (int i = headerIndex + 1; i < generatedLines.Count && !generatedLines[i].StartsWith("}"); i++)
            {
                if (!generatedLines[i].Contains(':'))
                    continue;

                string name = AttributeName(generatedLines[i].Split(new char[] { ':' }, 2)[0]);

                if (!generatedAttributes.ContainsKey(name))
                    generatedAttributes.Add(name, new List<string>());

                generatedAttributes[name].Add(generatedLines[i]);
            }

            StringBuilder returnSB = new StringBuilder();

            returnSB.AppendLine(generatedLines[headerIndex]);

            string currentName = null;
            bool currentFromGenerated = false;

            for (int i = 1; i < sourceLines.Count - 1; i++)
            {
                string line = sourceLines[i];

                if (!line.Contains(':'))
                {
                    returnSB.AppendLine(line);
                    continue;
                }

                string name = AttributeName(line.Split(new char[] { ':' }, 2)[0]);

                if (name != currentName)
                {
                    currentName = name;
                    currentFromGenerated = generatedAttributes.ContainsKey(name) && !unparsedAttributes.Contains(name);

                    if (currentFromGenerated)
                    {
                        foreach (string generatedLine in generatedAttributes[name])
                            returnSB.AppendLine(generatedLine);

                        generatedAttributes.Remove(name);
                    }
                }

                if (!currentFromGenerated)
                    returnSB.AppendLine(line);
            }

            returnSB.AppendLine("}");

            return returnSB.ToString();
        }
    }
}
