using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    partial class Model
    {
        public byte lvl = 1;

        public int gameScore = 0;

        public int[] mbrs = new int[5];

        public int summ = 0;

        Random rand = new Random();

        public string generateMathEqual()
        {
            byte i = 0;

            int rnd = 0;

            summ = 0;

            string _equalOut = "";

            for (i = 0; i < 3; i++)
            {

                rnd = rand.Next(5 * lvl);
                mbrs[i] = rnd;
            }

            for (i = 0; i <= mbrs.Length - 1; i++)
            {
                summ = summ + mbrs[i];
            }

            for (i = 0; i <= mbrs.Length - 3; i++)
            {
                _equalOut = _equalOut.Insert(_equalOut.Length, (mbrs[i].ToString()));
                if (i <= mbrs.Length - 4)
                {
                    _equalOut = _equalOut.Insert(_equalOut.Length, " + ");
                }
            }

            if (_equalOut != "")
            {
                _equalOut = _equalOut.Insert(_equalOut.Length, " = ?");
                //   _equalOut = _equalOut.Insert(_equalOut.Length, summ.ToString());

                return _equalOut;
            }

            else
                return _equalOut = "Empty string";
        }

        public bool compareAnsw(int input)
        {
            if (input == summ)
            {
                return true;
            }
            else
                return false;
        }

        public string interruptString(string s1, string s2)
        {
            string _sOut = "";
            int i = 0, min = 0, max = 0;

            for (i = s1.Length; i > 0; i--)
            {

                min = s1.Length - i;

                if (min < s1.Length - 1)
                {
                    max = 2 + (min);
                }
                try
                {
                    s1 = s1.Replace(s1[(rand.Next(min, max))], s2[s1.Length - i]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Some exception");
                }
            }
            _sOut = s1;
            return _sOut;
        }

        public string getInputStringFromFile(string str)
        {
            string _s2Out = "";

            return _s2Out;
        }
    }
}
