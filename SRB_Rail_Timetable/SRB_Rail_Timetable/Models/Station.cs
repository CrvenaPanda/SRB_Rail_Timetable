using System;
using System.Collections.Generic;
using System.Text;

namespace SRB_Rail_Timetable.Models
{
    public class Station
    {
        public Station(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; private set; }
        public string Id { get; private set; }
    }
}
