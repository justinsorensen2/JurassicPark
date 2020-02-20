using System;

namespace JurassicPark
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to Jurassic Park's Dino Database");
      Console.WriteLine("Displaying your existing dinosaurs:");
      var tracker = new DinoTracker();

      var isRunning = true;
      while (isRunning)
      {

        Console.WriteLine("What would you like to do?");
        Console.WriteLine("View All(VIEW), Add a dinosaur(ADD), Remove a dinosaur(REMOVE), Display a summary - sorted by diet(DIET), ");
        Console.WriteLine("Display 3 heaviest (HEAVY), Transfer a dinosaur(MOVE), or Quit(QUIT)?");
        var input = Console.ReadLine().ToUpper();
        if (input == "ADD")
        {
          Console.WriteLine("What is the name of the dinosaur you are adding?");
          var name = Console.ReadLine();

          Console.WriteLine("What is the weight of this dinosaur(in lbs)?");
          int weight = int.Parse(Console.ReadLine());

          Console.WriteLine("What is this dino's diet type? Please enter (herbivore) or (carnivore).");
          var diet = Console.ReadLine();

          Console.WriteLine("What enclosure will this dinosaur call home? Please enter an Enclosure Number.");
          var enclosure = int.Parse(Console.ReadLine());

          tracker.AcquireADino(name, diet, weight, enclosure);

        }
        else if (input == "REMOVE")
        {
          Console.WriteLine("Which dinosaur would you like to remove? Please enter a name.");
          var deletionDino = Console.ReadLine();
          tracker.RemoveADino(deletionDino);
        }
        else if (input == "HEAVY")
        {
          tracker.DisplayThreeHeaviest();
        }
        else if (input == "MOVE")
        {
          Console.WriteLine("Which dinosaur would you like to move? Please enter a name.");
          var name = Console.ReadLine();
          tracker.MoveADino(name);
        }
        else if (input == "VIEW")
        {
          foreach (var d in tracker.Dinosaurs)
          {
            Console.WriteLine($"{d.Name} weighs {d.Weight}, is a(n) {d.DietType}, and lives in Enclosure {d.EnclosureNumber}. It was acquired, {d.DateAcquired}.");
          }
        }
        else if (input == "DIET")
        {
          tracker.DietSummary();
        }
        else
        {
          Console.WriteLine("Thank you for using the Jurassic Park Dino Database! Goodbye!");
          isRunning = false;
          Console.Clear();
        }
      }
    }
  }
}
