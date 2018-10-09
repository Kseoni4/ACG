using System;


namespace ConsoleApp1
{
    class game
    {
        public static int tBuf = 0;

        public static void GameLoop(Model m, View v, Controller c)
        {
            bool q = false;

            while (q == false)
            {

                string str;
                int answ;
                char _q;

                v.displayEqual(m.generateMathEqual(), null);

                v.redrawGUI();

                answ = Convert.ToInt32(str = c.waitForInput());

                if ((_q = str.ToCharArray()[0]) == 'q')
                {
                    q = true;
                }
                else
                {
                    if (m.compareAnsw(answ) == true)
                    {
                        m.lvl++;
                        m.gameScore += 10;
                        v.displayResult(true, m.gameScore, m.lvl);
                    }
                    else
                    {
                        m.gameScore = (m.gameScore >= 10) ? m.gameScore -= 10 : m.gameScore;
                        v.displayResult(false, m.gameScore, m.lvl);

                    }

                    if (m.lvl > 1)
                    {
                        //Console.WriteLine(m.getInputTypeStringFromFile(c.readfile(@"C:\Users\ancie\source\repos\ConsoleApp1\ConsoleApp1\texts\interrupts.txt")) + ' ' + game.tBuf);
                        v.displayFrame(c.readfile(@"C:\Users\ancie\source\repos\ConsoleApp1\ConsoleApp1\texts\interrupts.txt"));
                        chooseText(m.getInputTypeStringFromFile(c.readfile(@"C:\Users\ancie\source\repos\ConsoleApp1\ConsoleApp1\texts\interrupts.txt")), c, m, v);
                        //Console.WriteLine(c.readfile(@"..\interrupts.txt"));
                        //v.displayEqual(m.generateMathEqual(), m.interruptString(v.tConsts[0], m.getInputStringFromFile(c.readfile(@"ConsoleApp1\texts\interrupts.txt"))));
                    }

                }
            }
        }
        static void chooseText(string _inType, Controller c, Model m, View v)
        {

            char num = '0';

            for (int i = 0; i <= _inType.Length; i++)
            {
                if (_inType[i] == '\r') { _inType = _inType.Replace('\r', ' '); }
                if (_inType[i] == '\n') { _inType = _inType.Replace('\n', ' '); }
                if (_inType[i] == '_')
                {
                    num = _inType[i + 1];
                    _inType = _inType.Remove(i);
                    break;
                }
            }

            switch (_inType)
            {
                case @"INTERRUPT":
                    {
                      v.displayEqual(m.generateMathEqual(), m.interruptString(v.tConsts[0], m.getInputTextStringFromFile(c.readfile(@"C:\Users\ancie\source\repos\ConsoleApp1\ConsoleApp1\texts\interrupts.txt"))));
                        break;
                    }
                case @"FRAME":
                    {
                        //v.displayFrame();
                        break;
                    }
            }
            v.displayFrame(_inType);
        }
    }

    class mainProgramm
    {
        static void Main(string[] args)
        {

            Controller input = new Controller();
            Model mathEqual = new Model();
            View disp = new View();

            disp.initGUIDraw();

            game.GameLoop(mathEqual, disp, input);

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
