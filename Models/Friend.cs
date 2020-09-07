using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeparatorBack.Models
{
    public class Friend
    {
        public int Id { get; set; }
        private string name;
        public List<Dish> dishes;


        public string Name
        {
            set
            {
                name = value ?? "Unnamed";
                if (name.Length > 1)
                    name = char.ToUpper(name[0]) + name.Substring(1);

            }
            get
            {
                return name;
            }
        }

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
