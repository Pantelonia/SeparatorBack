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
        
        public List<Dish> dishes;


        public void Add_dish(Dish dish)
        {
            dishes.Add(dish);
        }
      
        public decimal TakeCost()
        {
            decimal cost = 0;
            foreach (Dish d in dishes)
            {
                cost = cost + d.Cost;
            }
            return cost;
        }

        public Friend() : this("Unnamed") { }
        public Friend(string name)
        {
            Name = name;
            dishes = new List<Dish>();
        }

    }
}
