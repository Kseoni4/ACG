using System;

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

        if (line.Length > 0)
        {

            return line;

        }
        else
            return "0";

    }
}