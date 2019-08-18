using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Identity
    {
        public Identity(int id, string name, string namePlural, string description)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
            Description = description;
        }

        public Identity(int id, string name, string description)
        {
            ID = id;
            Name = name;
            NamePlural = "";
            Description = description;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }

        public string Description { get; set; }
    }
}
