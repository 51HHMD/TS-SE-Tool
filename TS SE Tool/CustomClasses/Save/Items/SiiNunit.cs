using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TS_SE_Tool.Save.DataFormat;
using TS_SE_Tool.Save.Items;

namespace TS_SE_Tool.Save.Items
{
    class SiiNunit
    {
        internal Dictionary<string, dynamic> SiiNitems = new Dictionary<string, dynamic>();

        internal string EconomyNameless = "";

        internal List<string> UnidentifiedBlocks = new List<string>();

        internal List<string> NamelessControlList = new List<string>();

        //Blocks in the order they appear in the save
        internal List<string> BlockOrder = new List<string>();

        internal Economy Economy
        {
            get => (Economy)SiiNitems[EconomyNameless];
            set => SiiNitems[EconomyNameless] = value;
        }

        internal Bank Bank
        {
            get => (Bank)SiiNitems[Economy.bank];
            set => SiiNitems[Economy.bank] = value;
        }

        internal Player Player
        {
            get => (Player)SiiNitems[Economy.player];
            set => SiiNitems[Economy.player] = value;
        }

        internal Player_Job Player_Job
        {
            get => Player.current_job != "null" ? (Player_Job)SiiNitems[Player.current_job] : null;
            set => SiiNitems[Player.current_job] = value;
        }

        internal Economy_event_Queue Economy_event_Queue
        {
            get => (Economy_event_Queue)SiiNitems[Economy.event_queue];
            set => SiiNitems[Economy.event_queue] = value;
        }

        internal SiiNunit()
        { }

        internal SiiNunit(string[] _input)
        {
            string tagLine = "", dataLine = "", nameless = "";

            List<string> blockLines = null;

            //block decoding
            for (int line = 0; line < _input.Length; line++)
            {
                string currentLine = _input[line];

                if (currentLine.Contains(':') && currentLine.Contains('{'))
                {
                    string[] splittedLine = currentLine.Split(new char[] { ':', '{' }, 3);

                    tagLine = splittedLine[0].Trim();
                    dataLine = splittedLine[1].Trim();
                }
                else
                {
                    continue;
                }

                nameless = dataLine;

                NamelessControlList.Add(nameless);

                blockLines = null;

                switch (tagLine)
                {
                    case "":
                        {
                            break;
                        }

                    case "}":
                        {
                            break;
                        }

                    case "economy":
                        {
                            EconomyNameless = nameless;

                            SiiNitems.Add(nameless, new Economy(GetLines().ToArray()));

                            break;
                        }

                    case "bank":
                        {
                            SiiNitems.Add(nameless, new Bank(GetLines().ToArray()));

                            break;
                        }

                    case "bank_loan":
                        {
                            SiiNitems.Add(nameless, new Bank_Loan(GetLines().ToArray()));

                            break;
                        }

                    case "player":
                        {
                            SiiNitems.Add(nameless, new Player(GetLines().ToArray()));

                            break;
                        }

                    case "trailer":
                        {
                            SiiNitems.Add(nameless, new Trailer(GetLines().ToArray()));

                            break;
                        }

                    case "trailer_utilization_log":
                        {
                            SiiNitems.Add(nameless, new Trailer_Utilization_log(GetLines().ToArray()));

                            break;
                        }

                    case "trailer_utilization_log_entry":
                        {
                            SiiNitems.Add(nameless, new Trailer_Utilization_log_Entry(GetLines().ToArray()));

                            break;
                        }

                    case "trailer_def":
                        {
                            SiiNitems.Add(nameless, new Trailer_Def(GetLines().ToArray()));

                            break;
                        }

                    case "player_job":
                        {
                            SiiNitems.Add(nameless, new Player_Job(GetLines().ToArray()));

                            break;
                        }

                    case "vehicle":
                        {
                            SiiNitems.Add(nameless, new Vehicle(GetLines().ToArray()));

                            break;
                        }

                    case "vehicle_accessory":
                        {
                            SiiNitems.Add(nameless, new Vehicle_Accessory(GetLines().ToArray()));

                            break;
                        }

                    case "vehicle_addon_accessory":
                        {
                            SiiNitems.Add(nameless, new Vehicle_Addon_Accessory(GetLines().ToArray()));

                            break;
                        }

                    case "vehicle_drv_plate_accessory":
                        {
                            SiiNitems.Add(nameless, new Vehicle_Drv_plate_Accessory(GetLines().ToArray()));

                            break;
                        }

                    case "vehicle_wheel_accessory":
                        {
                            SiiNitems.Add(nameless, new Vehicle_Wheel_Accessory(GetLines().ToArray()));

                            break;
                        }

                    case "vehicle_paint_job_accessory":
                        {
                            SiiNitems.Add(nameless, new Vehicle_Paint_job_Accessory(GetLines().ToArray()));

                            break;
                        }

                    case "vehicle_sound_accessory":
                        {
                            SiiNitems.Add(nameless, new Vehicle_Sound_Accessory(GetLines().ToArray()));

                            break;
                        }

                    case "vehicle_cargo_accessory":
                        {
                            SiiNitems.Add(nameless, new Vehicle_Cargo_Accessory(GetLines().ToArray()));

                            break;
                        }

                    case "profit_log":
                        {
                            SiiNitems.Add(nameless, new Profit_log(GetLines().ToArray()));

                            break;
                        }

                    case "profit_log_entry":
                        {
                            SiiNitems.Add(nameless, new Profit_log_Entry(GetLines().ToArray()));

                            break;
                        }

                    case "driver_player":
                        {
                            SiiNitems.Add(nameless, new Driver_Player(GetLines().ToArray()));

                            break;
                        }

                    case "driver_ai":
                        {
                            SiiNitems.Add(nameless, new Driver_AI(GetLines().ToArray()));

                            break;
                        }

                    case "job_info":
                        {
                            SiiNitems.Add(nameless, new Job_Info(GetLines().ToArray()));

                            break;
                        }

                    case "company":
                        {
                            SiiNitems.Add(nameless, new Company(GetLines().ToArray()));

                            break;
                        }
                    case "job_offer_data":
                        {
                            SiiNitems.Add(nameless, new Job_offer_Data(GetLines().ToArray()));

                            break;
                        }

                    case "garage":
                        {
                            SiiNitems.Add(nameless, new Garage(GetLines().ToArray()));

                            break;
                        }

                    case "game_progress":
                        {
                            SiiNitems.Add(nameless, new Game_Progress(GetLines().ToArray()));

                            break;
                        }

                    case "registry":
                        {
                            SiiNitems.Add(nameless, new Registry(GetLines().ToArray()));

                            break;
                        }

                    case "transport_data":
                        {
                            SiiNitems.Add(nameless, new Transport_Data(GetLines().ToArray()));

                            break;
                        }

                    case "economy_event_queue":
                        {
                            SiiNitems.Add(nameless, new Economy_event_Queue(GetLines().ToArray()));

                            break;
                        }

                    case "economy_event":
                        {
                            SiiNitems.Add(nameless, new Economy_event(GetLines().ToArray()));

                            break;
                        }

                    case "mail_ctrl":
                        {
                            SiiNitems.Add(nameless, new Mail_Ctrl(GetLines().ToArray()));

                            break;
                        }

                    case "mail_def":
                        {
                            SiiNitems.Add(nameless, new Mail_Def(GetLines().ToArray()));

                            break;
                        }

                    case "oversize_job_save":
                        {
                            SiiNitems.Add(nameless, new Oversize_Job_save(GetLines().ToArray()));

                            break;
                        }

                    case "trajectory_orders_save":
                        {
                            SiiNitems.Add(nameless, new Trajectory_orders_Save(GetLines().ToArray()));

                            break;
                        }

                    case "oversize_block_rule_save":
                        {
                            SiiNitems.Add(nameless, new Oversize_Block_rule_Save(GetLines().ToArray()));

                            break;
                        }

                    case "police_ctrl":
                        {
                            SiiNitems.Add(nameless, new Police_Ctrl(GetLines().ToArray()));

                            break;
                        }

                    case "oversize_offer_ctrl":
                        {
                            SiiNitems.Add(nameless, new Oversize_offer_Ctrl(GetLines().ToArray()));

                            break;
                        }

                    case "oversize_route_offers":
                        {
                            SiiNitems.Add(nameless, new Oversize_Route_offers(GetLines().ToArray()));

                            break;
                        }

                    case "oversize_offer":
                        {
                            SiiNitems.Add(nameless, new Oversize_Offer(GetLines().ToArray()));

                            break;
                        }

                    case "delivery_log":
                        {
                            SiiNitems.Add(nameless, new Delivery_log(GetLines().ToArray()));

                            break;
                        }

                    case "delivery_log_entry":
                        {
                            SiiNitems.Add(nameless, new Delivery_log_Entry(GetLines().ToArray()));

                            break;
                        }

                    case "ferry_log":
                        {
                            SiiNitems.Add(nameless, new Ferry_log(GetLines().ToArray()));

                            break;
                        }

                    case "ferry_log_entry":
                        {
                            SiiNitems.Add(nameless, new Ferry_log_Entry(GetLines().ToArray()));

                            break;
                        }

                    case "gps_waypoint_storage":
                        {
                            SiiNitems.Add(nameless, new GPS_waypoint_Storage(GetLines().ToArray()));

                            break;
                        }

                    case "map_action":
                        {
                            SiiNitems.Add(nameless, new Map_action(GetLines().ToArray()));

                            break;
                        }

                    case "bus_stop":
                        {
                            SiiNitems.Add(nameless, new Bus_stop(GetLines().ToArray()));

                            break;
                        }
                        
                    case "bus_job_log":
                        {
                            SiiNitems.Add(nameless, new Bus_job_Log(GetLines().ToArray()));

                            break;
                        }

                    case "player_vehicles":
                        {
                            SiiNitems.Add(nameless, new Player_Vehicles(GetLines().ToArray()));

                            break;
                        }

                    case "car_job_log":
                        {
                            SiiNitems.Add(nameless, new Car_job_Log(GetLines().ToArray()));

                            break;
                        }

                    case "car_job_generator":
                        {
                            SiiNitems.Add(nameless, new Car_job_Generator(GetLines().ToArray()));

                            break;
                        }

                    default:
                        {
                            List<string> tmpNewBlockLines = GetLines();

                            UnidentifiedBlocks.Add(nameless);
                            SiiNitems.Add(nameless, new Unidentified(tmpNewBlockLines));

                            Utilities.IO_Utilities.ErrorLogWriter("Save | New Data block | " + tagLine + Environment.NewLine + 
                                string.Join(Environment.NewLine, tmpNewBlockLines));

                            break;
                        }
                }

                if (blockLines != null && SiiNitems.ContainsKey(nameless))
                {
                    BlockOrder.Add(nameless);

                    if (SiiNitems[nameless] is SiiNBlockCore block)
                        block.sourceLines = blockLines;
                }

                continue;

                //===
                List<string> GetLines()
                {
                    string workLine = "";
                    List<string> Data = new List<string>();

                    line--;

                    do
                    {
                        line++;
                        workLine = _input[line];
                        Data.Add(workLine);

                    } while (!_input[line].StartsWith("}"));

                    blockLines = Data;

                    return Data;
                }
                //===
            }
        }

        internal string PrintOut(uint _version)
        {
            string returnString = "";

            StringBuilder returnSB = new StringBuilder();

            returnSB.AppendLine("SiiNunit" + Environment.NewLine + "{");

            //=== All blocks in original order

            foreach (string item in BlockOrder.Where(x => SiiNitems.ContainsKey(x)))
            {
                returnSB.AppendLine(PrintBlock(item));
            }

            returnSB.Append("}");

            returnString = returnSB.ToString();

            return returnString;
        }

        private string PrintBlock(string _nameless)
        {
            dynamic block = SiiNitems[_nameless];

            string generated = block.PrintOut(0, _nameless);

            if (block is Unidentified)
                return generated;

            return ((SiiNBlockCore)block).MergeWithSource(generated);
        }

    }
}
