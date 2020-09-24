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

        public virtual List<Friend> Friends { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Input total cost")]
        public int TotalCost { get; set; }

        public void AddNewFriend(string name)
        {
            Friend friend = new Friend(name);
            Friends.Add(friend);
            Console.WriteLine($"Welcome to the {Name} group!\n");
        }
        public void AddNewFriend(Friend friend)
        {            
            Friends.Add(friend);
            Console.WriteLine($"Welcome to the {Name} group!\n");
        }
        public void DeleteFriend(Friend friend)
        {
            Friends.Remove(friend);
            Console.WriteLine($"Goodbye, dear friend!\nMembers {friend.Name} of leave from {Name} group:\n");
        }
        public void Create_personal_dish(Dish dish, string FriendName)
        {
            Friend friend = Friends.Where(i => i.Name == FriendName).FirstOrDefault();
            Console.WriteLine($"Add dish {dish.Name} to {friend.Name}");
            friend.Add_dish(dish);
            TotalCost = TotalCost + dish.Cost;
        }
        public void Create_communal_dish(Dish dish)
        {
            Console.WriteLine($"Add dish {dish.Name} to all friend");
            foreach (Friend friend in Friends)
            {
                friend.Add_dish(dish);
            }
            TotalCost = TotalCost + dish.Cost;
        }

        public Group() : this("Unnamed") { }
        public Group(string name) : this(name, 0) { }
        public Group(string name, int total_cost)
        {
            Name = name;
            TotalCost = total_cost;
            Friends = new List<Friend>();
        }
    }
}
