
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace json2class
{
    class JObject
    {
        //это название класса
        public string JSONObjectName;

        Dictionary<string, string> myDictionary;


        public JObject()
        {
            //тут будут хранится пары полей класса  
            myDictionary = new Dictionary<string, string>();
        }

        public JObject(string name) // "field" : {}
        {
            JSONObjectName = name;
            //тут будут хранится пары полей класса
            myDictionary = new Dictionary<string, string>();
        }

        public static JObject CreateJObject(string name)
        {

            JObject Object = new JObject(name);
            return Object;
        }



        //метод для заполнения словаря с проверкой на уникальность при добавлении(нужно сделать).
        public void addFields(string JSONString, string JSONValue)
        {
            myDictionary.Add(JSONString, JSONValue);
        }

        public void getFields()
        {

            ICollection<string> keys = myDictionary.Keys;
            foreach (string n in keys)
            {
                Console.WriteLine("Name -> {0}  Value -> {1}", n, myDictionary[n]);
                string fieldstring = n + " " + myDictionary[n];
            }

        }
    }
}
