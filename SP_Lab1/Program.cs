using System;

namespace SP_Lab1
{
    class Program
    {
        private static void Main(string[] args)
        {
            var coffeeMachineTest = new CoffeeMachine("Van Darkholme");
            
            coffeeMachineTest.AddCookingMessage((message) => Console.WriteLine(message));
            coffeeMachineTest.AddReplanishingMessage((message) => Console.WriteLine(message));
            coffeeMachineTest.AddCashingMessage((message) => Console.WriteLine(message));
            
            Console.WriteLine(coffeeMachineTest);
            coffeeMachineTest.ReplenishCoffee(150);
            Console.WriteLine(coffeeMachineTest);
            coffeeMachineTest.ReplenishSugar(200);
            Console.WriteLine(coffeeMachineTest);
            coffeeMachineTest.ReplenishMilk(300);
            Console.WriteLine(coffeeMachineTest);
            coffeeMachineTest.ReplenishWater(700);
            Console.WriteLine(coffeeMachineTest);
            coffeeMachineTest.MakeDrink(55, DrinkTypes.Americano, DrinkTypes.Cappuccino, DrinkTypes.Latte);
            Console.WriteLine(coffeeMachineTest);
            coffeeMachineTest.MakeDrink(30, DrinkTypes.Ristretto);
            Console.WriteLine(coffeeMachineTest);
            coffeeMachineTest.TakeMoney();
            Console.WriteLine(coffeeMachineTest);
        }
    }
}