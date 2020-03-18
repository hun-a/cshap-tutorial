using System;

namespace Property {

  class Runner {

    class Creature {
      public int Hp { get; set; } = 100;
    }

    public static void Main(string[] args) {
      Creature creature = new Creature();
      Console.WriteLine(creature.Hp);
    }
  }
}