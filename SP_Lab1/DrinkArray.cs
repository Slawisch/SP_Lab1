using System;
using System.Collections.Generic;

namespace SP_Lab1
{
    public class DrinkArray
    {
        private List<Drink> drinkList = new List<Drink>();
        
        public Drink this[DrinkTypes drinkType]
        {
            get
            {
                if(drinkList is null)
                    throw new ArgumentException("No drink recipes added!");
                
                foreach (var drinkItem in drinkList)
                {
                    if (drinkType == drinkItem.Type)
                        return drinkItem;
                }
                
                throw new ArgumentException("Invalid drink type!");
            }
        }

        public void AddDrink(DrinkTypes type, int price, int needCoffee, int needMilk, int needWater, int needSugar)
        {
            drinkList.Add(new Drink(type, price, needCoffee, needMilk, needWater, needSugar));
        }
    }
}