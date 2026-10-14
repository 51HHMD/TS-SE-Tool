using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS_SE_Tool.Save.Items
{
    class Player_Vehicles : SiiNBlockCore
    {
        #region variables
        internal string vehicle { get; set; } = "";

        internal string stored_vehicle_placement { get; set; } = "";

        internal string stored_vehicle_city { get; set; } = "";

        internal string stored_vehicle_country { get; set; } = "";

        internal string trailer { get; set; } = "";

        internal List<string> stored_trailer_placements { get; set; } = new List<string>();

        internal bool stored_trailer_attached { get; set; } = false;

        #endregion

        internal Player_Vehicles()
        { }

        internal Player_Vehicles(string[] _input)
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

                        case "vehicle":
                            {
                                vehicle = dataLine;
                                break;
                            }

                        case "stored_vehicle_placement":
                            {
                                stored_vehicle_placement = dataLine;
                                break;
                            }

                        case "stored_vehicle_city":
                            {
                                stored_vehicle_city = dataLine;
                                break;
                            }

                        case "stored_vehicle_country":
                            {
                                stored_vehicle_country = dataLine;
                                break;
                            }

                        case "trailer":
                            {
                                trailer = dataLine;
                                break;
                            }

                        case "stored_trailer_placements":
                            {
                                stored_trailer_placements.Capacity = int.Parse(dataLine);
                                break;
                            }

                        case var s when s.StartsWith("stored_trailer_placements["):
                            {
                                stored_trailer_placements.Add(dataLine);
                                break;
                            }

                        case "stored_trailer_attached":
                            {
                                stored_trailer_attached = bool.Parse(dataLine);
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

            returnSB.AppendLine("player_vehicles : " + _nameless + " {");

            returnSB.AppendLine(" vehicle: " + vehicle);
            returnSB.AppendLine(" stored_vehicle_placement: " + stored_vehicle_placement);
            returnSB.AppendLine(" stored_vehicle_city: " + stored_vehicle_city);
            returnSB.AppendLine(" stored_vehicle_country: " + stored_vehicle_country);
            returnSB.AppendLine(" trailer: " + trailer);

            returnSB.AppendLine(" stored_trailer_placements: " + stored_trailer_placements.Count);
            for (int i = 0; i < stored_trailer_placements.Count; i++)
                returnSB.AppendLine(" stored_trailer_placements[" + i + "]: " + stored_trailer_placements[i]);

            returnSB.AppendLine(" stored_trailer_attached: " + stored_trailer_attached.ToString().ToLower());

            returnSB.AppendLine("}");

            returnString = returnSB.ToString();

            this.removeWritenBlock(_nameless);

            return returnString;
        }
    }
}
