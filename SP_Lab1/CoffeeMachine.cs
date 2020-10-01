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
        private event Action<string> CookingMessage;
        private event Action<string> ReplenishingMessage;
        private event Action<string> CashingMessage;
        private DrinkArray _drinks = new DrinkArray();

        public CoffeeMachine(string name = "NONAME", int maxCoffee = 1000, int maxMilk = 1000, int maxWater = 1000, int maxSugar = 1000)
        {
            if (name == string.Empty)
                throw new ArgumentException("Name can't be empty!");
            name = name.Replace(" ", string.Empty);
            
            Name = name;
            _maxCoffee = maxCoffee;
            _maxMilk = maxMilk;
            _maxWater = maxWater;
            _maxSugar = maxSugar;
            
            _drinks.AddDrink(DrinkTypes.Americano, 15, 20, 0, 150, 10);
            _drinks.AddDrink(DrinkTypes.Cappuccino, 20, 20, 25, 125, 15);
            _drinks.AddDrink(DrinkTypes.Espresso, 15, 25, 0, 100, 0);
            _drinks.AddDrink(DrinkTypes.Latte, 20, 15, 30, 120, 15);
            _drinks.AddDrink(DrinkTypes.Mocha, 18, 25,20,130,10);
            _drinks.AddDrink(DrinkTypes.Ristretto,22,30,0,150, 5);
        }

        public void AddCookingMessage(Action<string> message) => CookingMessage = message;
        public void AddReplanishingMessage(Action<string> message) => ReplenishingMessage = message;
        public void AddCashingMessage(Action<string> message) => CashingMessage = message;

        private void ValidateCoffeeMaking(int payment, Drink drink)
        {
            if (payment < drink.Price)
                throw new ArgumentException("Not enough money!");
            if (drink.NeedCoffee > _coffee)
                throw new ArgumentException("Not enough coffee!");
            if (drink.NeedMilk > _milk)
                throw new ArgumentException("Not enough milk!");
            if (drink.NeedWater > _water)
                throw new ArgumentException("Not enough water!");
            if (drink.NeedSugar > _sugar)
                throw new ArgumentException("Not enough sugar!");
            if (payment <= 0) throw new ArgumentOutOfRangeException(nameof(payment));
        }

        public void MakeDrink(int payment, params DrinkTypes[] drinkTypes)
        {
            foreach (var drinkItem in drinkTypes)
            {
                var drink = _drinks[drinkItem];
                ValidateCoffeeMaking(payment, drink);
                payment -= drink.Price;
                _cash += drink.Price;
                _coffee -= drink.NeedCoffee;
                _milk -= drink.NeedMilk;
                _water -= drink.NeedWater;
                _sugar -= drink.NeedSugar;
                CookingMessage?.Invoke($"Cooked {drinkItem}");
            }
        }

        public void ReplenishCoffee(int quantity)
        {
            if(quantity + _coffee > _maxCoffee)
                throw new ArgumentException("Too much coffee!");
            _coffee += quantity;
            ReplenishingMessage?.Invoke($"Added {quantity} coffee");
        }

        public void ReplenishMilk(int quantity)
        {
            if(quantity + _milk > _maxMilk)
                throw new ArgumentException("Too much milk!");
            _milk += quantity;
            ReplenishingMessage?.Invoke($"Added {quantity} milk");
        }

        public void ReplenishWater(int quantity)
        {
            if(quantity + _water > _maxWater)
                throw new ArgumentException("Too much water!");
            _water += quantity;
            ReplenishingMessage?.Invoke($"Added {quantity} water");
        }

        public void ReplenishSugar(int quantity)
        {
            if(quantity + _sugar > _maxSugar)
                throw new ArgumentException("Too much sugar!");
            _sugar += quantity;
            ReplenishingMessage?.Invoke($"Added {quantity} sugar");
        }

        public int TakeMoney()
        {
            var returnableCash = _cash;
            _cash = 0;
            CashingMessage?.Invoke($"Cashed {returnableCash}");
            return returnableCash;
        }

        public override string ToString()
        {
            return $"Name: {Name}; Cash: {_cash}; Coffee:{_coffee}; Sugar:{_sugar}; Milk:{_milk}; Water:{_water};";
        }
    }
}