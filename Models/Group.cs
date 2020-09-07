using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SeparatorBack.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AllCost { get; set; }
        public List<Friend> Friends { get; set; }



        public Group() : this("Unnamed") { }
        public Group(string name) : this(name, 0) { }
        public Group(string name, int total_cost)
        {
            Name = name;
            AllCost = total_cost;
            Friends = new List<Friend>();
        }
    }
}
