﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ACG
{
    partial class Controller
    {
        public string out_string = "";
        public string full_string = "";
        Boolean rO = false;

        public string readfile(string fName)
        {
            // reading file code here

            try
            {
                using (FileStream fstream = new FileStream(fName, FileMode.Open)) {

                    byte[] byteArray = new byte[fstream.Length];

                    if (game.tBuf < fstream.Length)
                    {

                        fstream.Seek(game.tBuf, SeekOrigin.Begin);

                        fstream.Read(byteArray, 0, byteArray.Length);
                        
                        out_string = System.Text.Encoding.UTF8.GetString(byteArray);

                        if (rO != true) { full_string = System.Text.Encoding.UTF8.GetString(byteArray); rO = true; }

                        //game.tBuf = Convert.ToInt16(fstream.Position);
                    }
                    else return "End of file";
                }
            } catch (Exception)
            {
                out_string = "Error for open file";
            }

            return out_string;
        }

        public string waitForInput()
        {
            string line;

            Console.Write(">");

            line = Console.ReadLine();

            if (line.Length > 0)
            {

                return line;

            }
            else
                return "0";

        }
    }
}
