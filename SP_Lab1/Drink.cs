using System;

namespace SP_Lab1
{
    public struct Drink
    {
        public DrinkTypes Type { get; }
        public readonly int Price;
        public readonly int NeedCoffee;
        public readonly int NeedMilk;
        public readonly int NeedWater;
        public readonly int NeedSugar;

        public Drink(DrinkTypes type, int price, int needCoffee, int needMilk, int needWater, int needSugar)
        {
            Type = type;
            Price = price;
            NeedCoffee = needCoffee;
            NeedMilk = needMilk;
            NeedWater = needWater;
            NeedSugar = needSugar;
        }
    }
}