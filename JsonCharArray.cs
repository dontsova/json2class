using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace json2class
{
    class JsonCharArray
    {
        static int counter = 0;

        ArrayList myArrayList = new ArrayList();

        private int getCounter()
        {
            return counter++;
        }


        public JsonCharArray(string strLine)
        {
            CreateCharArray(strLine);
        }

        public void CreateCharArray(string source)
        {
            Stack<char> stk = new Stack<char>();
            foreach (char c in source)
            {
                myArrayList.Add(c);
            }
        }

        public char GetNextChar()
        {
            
            char oneChar = (char)myArrayList[getCounter()];
            
            return oneChar;

        }
    }
}
