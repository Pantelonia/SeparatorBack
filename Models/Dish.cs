﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeparatorBack.Models
{
    public class Dish
    {
        private string name;
        private decimal cost;
        //Dish may be of two types: 
        //    false - personally, when only you eat this dish(defaul value)
        //    true - communal, when all friands eat this dish(i.e. snack)

        public bool type;
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
        public decimal Cost
        {
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} must be greater than zero");
                cost = value;
            }
            get
            {
                return cost;
            }
        }

        public Dish() : this("Unname", 0) { }
        public Dish(string name, decimal cost) : this(name, cost, false) { }
        public Dish(string name, decimal cost, bool type)
        {
            Name = name;
            Cost = cost;
            type = this.type;
        }


    }
}
