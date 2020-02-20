using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
  public class DinoTracker
  {
    public List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

    public void AcquireADino(string name, string diet, int weight, int enclosure)
    {
      var dino = new Dinosaur
      {
        Name = name,
        DietType = diet,
        Weight = weight,
        EnclosureNumber = enclosure,
        DateAcquired = DateTime.Now
      };
      Dinosaurs.Add(dino);
    }
    public void RemoveADino(string name)
    {
      var deletionDino = Dinosaurs.Where(Dinosaur => Dinosaur.Name == name).ToList();
      if (deletionDino.Count() > 1)
      {
        Console.WriteLine($"We found more than one dino that matches {name}.");
        Console.WriteLine($"Which would you like to remove?");
        for (int i = 0; i < deletionDino.Count(); i++)
        {
          var possibleDeletion = deletionDino[i];
          Console.WriteLine($"{i + 1}: {possibleDeletion.Name} in Enclosure :{possibleDeletion.EnclosureNumber}, weighing {possibleDeletion.Weight}.");
        }
        var index = int.Parse(Console.ReadLine());
        Dinosaurs.Remove(deletionDino[index - 1]);
      }
      else
      {
        Dinosaurs.Remove(deletionDino.First());
      }
    }
    public void MoveADino(string name)
    {
      var moveIndex = Dinosaurs.IndexOf((Dinosaurs.First(name => Dinosaurs.Contains(name))));
      Console.WriteLine($"Where would you like to move them? Please enter an Enclosure Number.");
      var newEnclosure = int.Parse(Console.ReadLine());
      Dinosaurs[moveIndex].EnclosureNumber = newEnclosure;
    }

    public void DisplayThreeHeaviest()
    {
      var heaviestDinos = (Dinosaurs.OrderByDescending(DisplayThreeHeaviest => DisplayThreeHeaviest.Weight).Take(3));
      foreach (var dino in heaviestDinos)
      {
        Console.WriteLine($"The {dino.Name} weighs {dino.Weight}.");
      }
    }


  }




}