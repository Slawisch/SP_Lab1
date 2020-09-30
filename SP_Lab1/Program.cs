using System;

namespace SP_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var coffeeMachineTest = new CoffeeMachine();
            coffeeMachineTest.ReplenishCoffee(150);
            coffeeMachineTest.ReplenishMilk(300);
            coffeeMachineTest.ReplenishSugar(200);
            coffeeMachineTest.ReplenishWater(500);
            coffeeMachineTest.MakeDrink(50, DrinkTypes.Americano, DrinkTypes.Cappuccino, DrinkTypes.Latte);
            
        }
    }
}