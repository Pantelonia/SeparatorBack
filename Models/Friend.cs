using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeparatorBack.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        
        public virtual List<Dish> Dishes { get; set; }


        public void Add_dish(Dish dish)
        {
            Dishes.Add(dish);
        }
      
        public decimal TakeCost()
        {
            decimal cost = 0;
            foreach (Dish d in Dishes)
            {
                cost = cost + d.Cost;
            }
            return cost;
        }

        public Friend() : this("Unnamed") { }
        public Friend(string name)
        {
            Name = name;
            Dishes = new List<Dish>();
        }

    }
}
