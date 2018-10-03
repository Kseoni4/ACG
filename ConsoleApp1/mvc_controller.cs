using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Controller
    {
        public string readfile(string fName)
        {
            // reading file code here

            string out_string = "";

            try
            {
                using (FileStream fstream = new FileStream(fName, FileMode.Open)) {

                    byte[] byteArray = new byte[fstream.Length];

                    fstream.Read(byteArray, 0, byteArray.Length);

                    out_string = System.Text.Encoding.Default.GetString(byteArray);
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
