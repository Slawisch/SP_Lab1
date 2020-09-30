using System;

namespace SP_Lab1
{
    public class CoffeeMachine
    {
        public readonly string Name;
        private int _coffee;
        private int _milk;
        private int _water;
        private int _sugar;
        private readonly int _maxCoffee; //In gramms
        private readonly int _maxMilk; //In gramms
        private readonly int _maxWater; //In gramms
        private readonly int _maxSugar; //In gramms
        private int _cash;

        private Drink GetDrinkByType(DrinkTypes type) => type switch
        {
            DrinkTypes.Americano => new Drink(DrinkTypes.Americano, 15, 20, 0, 150, 10),
            DrinkTypes.Cappuccino => new Drink(DrinkTypes.Cappuccino, 20, 20, 25, 125, 15),
            DrinkTypes.Espresso => new Drink(DrinkTypes.Espresso, 15, 25, 0, 100, 0), 
            DrinkTypes.Latte => new Drink(DrinkTypes.Latte, 20, 15, 30, 120, 15),
            _ => throw new ArgumentException("Invalid drink type!")
        };

        private void ValidateCoffeeMaking(int payment, Drink drink)
        {
            if(payment < drink.Price)
                throw new ArgumentException("Not enough money!");
            if(drink.NeedCoffee > _coffee)
                throw new ArgumentException("Not enough coffee!");
            if(drink.NeedMilk > _milk)
                throw new ArgumentException("Not enough milk!");
            if(drink.NeedWater > _water)
                throw new ArgumentException("Not enough water!");
            if(drink.NeedSugar > _sugar)
                throw new ArgumentException("Not enough sugar!");
        }

        public CoffeeMachine(string name = "NONAME", int maxCoffee = 1000, int maxMilk = 1000, int maxWater = 1000, int maxSugar = 1000)
        {
            Name = name;
            _maxCoffee = maxCoffee;
            _maxMilk = maxMilk;
            _maxWater = maxWater;
            _maxSugar = maxSugar;
        }

        public void MakeDrink(int payment, params DrinkTypes[] drinkTypes)
        {
            foreach (var drinkItem in drinkTypes)
            {
                var drink = GetDrinkByType(drinkItem);
                ValidateCoffeeMaking(payment, drink);
                payment -= drink.Price;
                _cash += drink.Price;
                _coffee -= drink.NeedCoffee;
                _milk -= drink.NeedMilk;
                _water -= drink.NeedWater;
                _sugar -= drink.NeedSugar;
            }
        }

        public void ReplenishCoffee(int quantity)
        {
            if(quantity + _coffee > _maxCoffee)
                throw new ArgumentException("Too much coffee!");
            _coffee += quantity;
        }

        public void ReplenishMilk(int quantity)
        {
            if(quantity + _milk > _maxMilk)
                throw new ArgumentException("Too much milk!");
            _milk += quantity;
        }

        public void ReplenishWater(int quantity)
        {
            if(quantity + _water > _maxWater)
                throw new ArgumentException("Too much water!");
            _water += quantity;
        }

        public void ReplenishSugar(int quantity)
        {
            if(quantity + _sugar > _maxSugar)
                throw new ArgumentException("Too much sugar!");
            _sugar += quantity;
        }

        public int TakeMoney()
        {
            var returnableCash = _cash;
            _cash = 0;
            return returnableCash;
        }
    }
}