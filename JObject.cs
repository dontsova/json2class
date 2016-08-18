using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace json2class
{
    class JObject
    {
        //это название класса
        private string JSONObjectName;
        Dictionary<string, string> myDictionary;


        private JObject()
        {
            //тут будут хранится пары полей класса  
            myDictionary = new Dictionary<string, string>();
        }

        private JObject(string name)
        {
            JSONObjectName = name;
            //тут будут хранится пары полей класса
            myDictionary = new Dictionary<string, string>();
        }

        public JObject CreateJObject(string name)
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
