using System;

namespace Property {

  class Runner {

    class Creature {
      public int Hp {
        get; set;
      }
    }

    public static void Main(string[] args) {
      Creature creature = new Creature();
      creature.Hp = 100;
      Console.WriteLine(creature.Hp);
    }
  }
}