using System;

namespace ConsoleApp1
{
    class Program
    {
        public class Controller
        {
            public string readfile()
            {
                string out_string = "";
                
                // reading file code here

                return out_string;
            }

            public string waitForInput()
            {
                string line;

                

                Console.Write(">");

                line = Console.ReadLine();

                if (line.Length > 0) {

                    return line;

                }
                else
                    return "0";

            }
        }

        public class Model
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
                
                for (i = 0; i <= mbrs.Length-1; i++)
                {
                    summ = summ + mbrs[i];
                }

                for (i = 0; i <= mbrs.Length-3; i++)
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

                for (i = s1.Length; i > 0; i--) {

                    min = s1.Length - i;

                    if (min < s1.Length - 1)
                    {
                        max = 2 + (min);
                    }

                    s1 = s1.Replace(s1[(rand.Next(min, max))], s2[s1.Length-i]);

                }

                _sOut = s1;
                return _sOut;
            }
        }

        public class View
        {
            int crtop_buf = 0;

            ConsoleColor[] clr = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

            public void displayGUIDraw()
            {
                crtop_buf = Console.CursorTop;

                if (crtop_buf == 1)
                {
                    crtop_buf = 2;
                }

                Console.SetCursorPosition(1, 0);
                
                Console.Write(".");
                Console.ForegroundColor = clr[12];
                Console.Write("ten");
                Console.ResetColor();
                Console.Write(" minutes stories.");
                Console.ResetColor();

                Console.CursorTop = crtop_buf+1;

                Console.SetCursorPosition(1, Console.CursorTop);

            }

            public void displayEqual(string str)
            {
                Console.WriteLine("Решите уравнение: ");
                Console.WriteLine(str);
            }

            public void displayResult(bool cmp, int score, byte lvl)
            {
                switch (cmp) {
                    case true:
                        Console.WriteLine("It is correct! Your score is " + score + " and level up to " + lvl);
                        break;
                    case false:
                        Console.WriteLine("Not correct! Your score is " + score);
                        break;
                }
            }
        }


        public static void GameLoop(Model a, View b, Controller c)
        {
            bool q = false;

            while (q == false) {

                b.displayGUIDraw();

                string str;

                int answ;

                char _q;

                b.displayEqual(a.generateMathEqual());

                answ = Convert.ToInt32(str = c.waitForInput());

                if ((_q = str.ToCharArray()[0]) == 'q')
                {
                    q = true;
                }
                else
                {
                    if (a.compareAnsw(answ) == true)
                    {
                        a.lvl++;
                        a.gameScore += 10;
                        b.displayResult(true, a.gameScore, a.lvl);
                    }
                    else
                    {
                        a.gameScore = (a.gameScore >= 10) ? a.gameScore -= 10 : a.gameScore;
                        b.displayResult(false, a.gameScore, a.lvl);

                    }

                    if (a.lvl > 5)
                    {

                    }
                }
            }
        }


        static void Main(string[] args)
        {

            Controller input = new Controller();
            Model mathEqual = new Model();
            View disp = new View();
                    

            GameLoop(mathEqual, disp, input);

        }

    }
}



/*
 * OLD CODE
Random rand = new Random();

Console.WriteLine("Welcome to the AnotherCalcGame!");
Console.WriteLine("\nYou are on level " + lvl);
Console.WriteLine("Your score is " + score);

num1 = rand.Next(100);
num2 = rand.Next(100);
summ = num1 + num2;

sw = gVar.rand.Next(1, 4);

switch (sw)
{
    case 1:
        a1 = '+';
        a2 = '+';
        break;
}

Console.WriteLine("\nEnter the correct answer for :");
Console.WriteLine(num1 + " + " + num2);

answ = Convert.ToInt32(Console.ReadLine());

if (answ == summ)
{
    Console.WriteLine("\nIt's correct! You have 10 scores and go to the next level!");
    score += 10;
    lvl++;
}
if (answ != summ)
{
    Console.WriteLine("\nNot correct! You lose your scores, try again!");
    if (score >= 10)
    {
        score -= 10;
    }
}

Console.WriteLine("\nYou are on level " + lvl);
Console.WriteLine("Your score is " + score);
Console.ReadKey();
*/
