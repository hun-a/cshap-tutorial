using System;

namespace TextRPG {

  class Game {

    static void Main(string[] args) {
      Player knight = new Knight();
      Monster orc = new Orc();

      Console.WriteLine($"Monster hp: {orc.GetHp()}");

      int damage = knight.GetAttack();
      orc.OnDamaged(damage);
      
      Console.WriteLine($"Player attack! {damage}");
      Console.WriteLine($"Monster hp: {orc.GetHp()}");
    }
  }
}