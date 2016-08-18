using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace json2class
{
    class ObjectList
    {
        LinkedList<JObject> Llist = new LinkedList<JObject>();

        private ObjectList() { }

        private ObjectList(string name)
        {

        }
    }
}
