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
        private string source;
        private int length;
        private int current_position;
        private List<JObject> list;
        private string TempClassName;
        private string FieldNameString;
        private string FieldTypeString;
        private Stack<string> st;
        private JObject CurrentJObject;


        public Parser(string _source)
        {
            list = new List<JObject>();
            source = System.Text.RegularExpressions.Regex.Replace(_source, @"\s+", "");
            length = source.Length;
            current_position = 0;
            TempClassName = "Root Object";
            st = new Stack<string>();
        }



        public void ParseJson()
        {

            Console.WriteLine(source);
            Console.ReadLine();

            
            ParseClass();

        }

        public void ParseClass()
        {
            if (source.Substring(current_position, 1) == "{")
            {
                st.Push(source.Substring(current_position, 1));
                AddObject(TempClassName);

                for (GetCurrentPosition(); current_position < length; current_position++)
                {
                    string currsor = source.Substring(current_position, 1);
                    if (currsor == "\"")
                    {
                        ParseClassFields();
                    }

                }
            }     
        }

        public void ParseArray()
        {
            AddObject(TempClassName);
            current_position--;
            for (GetCurrentPosition(); current_position < length; current_position++)
            {
                string currsor = source.Substring(current_position, 1);
                if (currsor == "[")
                {
                    st.Push(source.Substring(current_position, 1));
                    if (currsor == "{")
                    {
                        ParseArrayFields();
                    }

                }
            }

        }

        public void ParseArrayFields()
        {

        }

        public void ParseClassFields()
        {
            current_position--;
            for (GetCurrentPosition(); current_position < length; current_position++)
            {
                string currsor = source.Substring(current_position, 1);
                if (currsor == "\"")
                {
                    FieldNameString = ParseFieldName(currsor);

                    for (GetCurrentPosition(); current_position < length; current_position++)
                    {
                        currsor = source.Substring(current_position, 1);
                        if (currsor == ":")
                        {
                            for (GetCurrentPosition(); current_position < length; current_position++)
                            {
                                currsor = source.Substring(current_position, 1);
                                if (currsor == "\"")
                                {
                                    FieldTypeString = ParseFieldValue(currsor);
                                    if (!String.IsNullOrEmpty(FieldNameString) && !String.IsNullOrEmpty(FieldTypeString))
                                    {
                                        JObject obj = list.FirstOrDefault(x => x.JSONObjectName == TempClassName);
                                        obj.addFields(FieldNameString, FieldTypeString);
                                    }
                                    for (GetCurrentPosition(); current_position < length; current_position++)
                                    {
                                        currsor = source.Substring(current_position, 1);
                                        if (currsor == ",")
                                        {
                                            ParseClassFields();
                                        }

                                        if (currsor == "}")
                                        {
                                            if (st.Peek() == "{")
                                            {
                                                st.Pop();
                                            }
                                            else
                                            {///ERROR}
                                            }
                                        }
                                   
                                    }

                                    if (currsor == "{")
                                    {

                                        ParseClass();
                                    }

                                    if (currsor == "[")
                                    {
                                        ParseArray();
                                    }
                                }
                            }

                        }
                    }
                }
                
            }
        }

        public string ParseFieldName(string cur)
        {
            string val = "";
            current_position--;

            for (GetCurrentPosition(); current_position < length; current_position++)
            {
                if (cur == "\"")
                {
                    return val;
                }
                else
                {
                    val = val + cur;
                }
            }

            return val ;
        }

        public string ParseFieldValue(string _cur)
        {
            string val = "";
            current_position--;

            for (GetCurrentPosition(); current_position < length; current_position++)
            {
                if (_cur == "\"")
                {
                    return val;
                }
                else
                {
                    val = val + _cur;
                }
            }

            return val;
        }

        private int GetCurrentPosition()
        {
            return current_position;
        }

        public List<JObject> AddObject(string ObjName)
        {

            var item = list.FirstOrDefault(x => x.JSONObjectName == ObjName);

            if (item == null)
            {
                list.Add(JObject.CreateJObject(ObjName));
            }
            return list;
        }

        private string RemoveSpaces(string inputString)
        {
            inputString = inputString.Replace("  ", string.Empty);
            inputString = inputString.Trim().Replace(" ", string.Empty);

            return inputString;
        }


        

        public string FindType(string val)
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
           
            else
            {
                return "error";
            }


        }
    }
}

    
