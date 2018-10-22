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
            int i = 0, j = 1, min = 0, max = 0, s1L = 0, _rnd;
            s1L = s1.Length;

            for (i = s1L; i > 0;i--)
            {

                //min = s1.Length - s1L;

                if (min < s1.Length - 1)
                {
                    max = j + (s1.Length-s1L);
                }
                try
                {
                    _rnd = rand.Next(min, max);
                    s1 = s1.Insert(_rnd, Convert.ToString(s2[s1.Length - s1L]));
                    min = max;
                    j++;

                }
                catch (Exception)
                {
                    //Console.WriteLine("Some exception");
                    
                }
            }
            _sOut = s1;
            return _sOut;
        }

        public string getInputTypeStringFromFile(string str)
        {
            string _s2TypeOut = "";
            byte i = 0, j = 0;

            while (str[i] != ']')
            {

                if (str[i] == '\0')
                {
                    return "end of file";
                }

                if (str[i] == '[')
                {
                    while (str[i] != ']')
                    {
                        if (str[i] != '[')
                        {
                            _s2TypeOut = _s2TypeOut.Insert(j, Convert.ToString(str[i]));
                            i++;
                            j++;
                        }
                        else i++;
                    }
                }
                else { i++; }
            }
            game.tBuf += i + 1;
            return _s2TypeOut;
        }
        public string getInputTextStringFromFile(string str)
        {
            string _s2TextOut = "";
            byte i = 0, j = 0;
            while (str[i] != '\0')
            {
                if (str[i] != '1' && str[i] != ']' && str[i] != '\n' && str[i] != '\r')
                {
                    _s2TextOut = _s2TextOut.Insert(j, Convert.ToString(str[i]));
                    i++;
                    j++;
                }
                else i++;
            }

            game.tBuf += i + 1;
            return _s2TextOut.ToUpper();
        }
    }
}
