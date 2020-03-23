using System;

namespace NullableTutorial {

  class Monster {
    private int? id;
    public int? Id {
      get { return id; }
      set{ id = value; }
    }
  }

  class Runner {
    public static void Main(string[] args) {
      int? a = null;
      int b = a ?? 0;
      Console.WriteLine($"a is {a} and b is {b}");

      Monster monster = new Monster();
      monster.Id = 10;

      int? monsterId = monster?.Id;
      Console.WriteLine(monsterId);

      monster.Id = null;
      
      monsterId = monster?.Id;
      Console.WriteLine(monsterId);
    }
  }
}