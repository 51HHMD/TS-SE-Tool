using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS_SE_Tool.Save.Items
{
    class Car_job_Generator : SiiNBlockCore
    {
        internal List<string> car_offers { get; set; } = new List<string>();

        internal Car_job_Generator()
        { }

        internal Car_job_Generator(string[] _input)
        {
            string tagLine = "", dataLine = "";

            foreach (string currentLine in _input)
            {
                if (currentLine.Contains(':'))
                {
                    string[] splittedLine = currentLine.Split(new char[] { ':' }, 2);

                    tagLine = splittedLine[0].Trim();
                    dataLine = splittedLine[1].Trim();
                }
                else
                {
                    tagLine = currentLine.Trim();
                    dataLine = "";
                }
                try
                {
                    switch (tagLine)
                    {
                        case "":
                            {
                                break;
                            }

                        case "car_offers":
                            {
                                car_offers.Capacity = int.Parse(dataLine);
                                break;
                            }

                        case var s when s.StartsWith("car_offers["):
                            {
                                car_offers.Add(dataLine);
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Utilities.IO_Utilities.ErrorLogWriter(ex.Message + Environment.NewLine + this.GetType().Name.ToLower() + " | " + tagLine + " = " + dataLine);
                    this.markUnparsed(tagLine);
                }
            }
        }

        internal string PrintOut(uint _version)
        {
            return PrintOut(_version, null);
        }
        internal string PrintOut(uint _version, string _nameless)
        {
            string returnString = "";

            StringBuilder returnSB = new StringBuilder();

            returnSB.AppendLine("car_job_generator : " + _nameless + " {");

            returnSB.AppendLine(" car_offers: " + car_offers.Count);
            for (int i = 0; i < car_offers.Count; i++)
                returnSB.AppendLine(" car_offers[" + i + "]: " + car_offers[i]);

            returnSB.AppendLine("}");

            returnString = returnSB.ToString();

            this.removeWritenBlock(_nameless);

            return returnString;
        }
    }
}
