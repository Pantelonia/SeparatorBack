using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeparatorBack.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name{ get; set;}
        public int? FriendId { get; set; }
        public virtual Friend Friend { get; set; }
        public int Cost { get;  set; }
        //Dish may be of two types: 
        //    false - personally, when only you eat this dish(defaul value)
        //    true - communal, when all friands eat this dish(i.e. snack)

        public bool Type { get; set; }
        
        
        public Dish() : this("Unname", 0) { }
        public Dish(string name, int cost) : this(name, cost, false) { }
        public Dish(string name, int cost, bool type)
        {
            Name = name;
            Cost = cost;
            Type = type;
        }


    }
}
