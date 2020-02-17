using System;
using System.Collections.Generic;
using System.Text;

namespace GrammerConsole
{
  class VarianceFun
  {
    public void Run()
    {
      var animals = new List<Animal>();
      animals.Add(new Cat());
      animals.Add(new Fish());
      animals.Add(new Animal());

      PrintAnimalsName(animals);

      //covariant
      var fishs = new List<Fish>();
      fishs.Add(new Fish("1"));
      fishs.Add(new Fish("2"));
      PrintAnimalsName(fishs);
    }

    private void PrintAnimalsName(IEnumerable<Animal> animals)
    {
      foreach(var ani in animals)
      {
        Console.WriteLine(ani.Name);
      }
    }
  }

  class Animal
  {
    public string Name { get; set; }
    public Animal()
    {
      Name = "Animal";
    }

    public Animal(string name)
    {
      Name = "Animal " + name;
    }
  }

  class Fish : Animal
  {
    public Fish()
    {
      Name = "Fish";
    }

      public Fish(string name)
      {
        Name = "Fish " + name;
      }
    }

  class Cat : Animal
  {
    public Cat()
    {
      Name = "Cat";
    }

    public Cat(string name)
    {
      Name = "Cat " + name;
    }
  }
}
