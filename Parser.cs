using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace json2class
{
    class Parser
    {
        static public void ParseJson(string source)
        {
            JsonCharArray myArr = new JsonCharArray(source);

            Console.WriteLine(source);

            for (int i = 0; i < 652; i++)
            {
                Console.WriteLine(" :" + myArr.GetNextChar());
            }
            Console.Read();

            

        }

        static public string FindType(string val)
        {
            string StringPattern = "[A-Za-z][^0-9]";
            string DoublePattern = "[0-9]";

            string value = val.ToLower();

            //bool
            if (val == "false" || val == "true" || val == "null")
            {
                return "bool";
            }
            //String
            if (Regex.IsMatch(val, StringPattern, RegexOptions.IgnoreCase))
            {
                return "string";
            }
            //Long
            if (Regex.IsMatch(val, DoublePattern, RegexOptions.IgnoreCase))
            {
                return "double";
            }
            //Exp нужно разобраться с регулярным вырожением для Long
            /*if (Regex.IsMatch(val, ExpPattern, RegexOptions.IgnoreCase))
            {
                return "int";
            }*/

            else
            {
                return "error";
            }


        }
    }
}

    
