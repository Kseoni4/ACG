using System;
using System.Collections.Generic;
using System.Text;

namespace ACG
{
    partial class View
    {
        int crtop_buf = 2;

        public string[] tConsts = new string[] {
            "Решите выражение :"

           };

        ConsoleColor[] clr = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        void drawTitle(int x, int y, int curbuf)
        {
            try
            {

                Console.SetCursorPosition(x, y);
                Console.BackgroundColor = clr[15];
                Console.ForegroundColor = clr[0];
                Console.Write("Another Calc Game by ");
                Console.Write(".");
                Console.ForegroundColor = clr[12];
                Console.Write("ten");
                Console.ForegroundColor = clr[0];
                Console.Write(" minutes stories." +
                    "                                                   " +
                    "    ");
                //Console.ResetColor();


                Console.SetCursorPosition(0, 1);
                Console.ResetColor();
                Console.WriteLine("                     ");

                Console.SetCursorPosition(0, curbuf);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error of GUI draw");
            }
        }


        public void initGUIDraw()
        {
            //crtop_buf = Console.CursorTop;

            Console.BufferHeight = 30;
            Console.BufferWidth = 120;
            Console.WindowWidth = 100;
            drawTitle(0, 0, crtop_buf);

        }

        public void redrawGUI()
        {
            crtop_buf = Console.CursorTop;

            drawTitle(0, 0, crtop_buf);
        }

        void dispSizes()
        {
            Console.WriteLine("Win height: " + Console.WindowHeight);
            Console.WriteLine("Win width: " + Console.WindowWidth);
            Console.WriteLine("Current cursor top (y): " + Console.CursorTop);
            Console.WriteLine("Buffer size x and y " + Console.BufferWidth + " " + Console.BufferHeight);
            Console.WriteLine();
        }

        public void displayEqual(string eqStr, string str)
        {
            //dispSizes();
            if (str is null)
            {
                str = tConsts[0];
            }

            Console.WriteLine(str);
            Console.WriteLine(eqStr);
        }

        public void displayResult(bool cmp, int score, byte lvl)
        {
            switch (cmp)
            {
                case true:
                    Console.WriteLine("It is correct! Your score is " + score + " and level up to " + lvl);
                    break;
                case false:
                    Console.WriteLine("Not correct! Your score is " + score);
                    break;
            }
        }
        
        public void displayFrame(string str)
        {
            Console.WriteLine(str);
        }
    }
}
