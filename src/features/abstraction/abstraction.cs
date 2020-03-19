using System;

namespace Abstraction {
    
  class Runner {

    abstract class Monster {
      public abstract void Shout();
    }

    interface IFlyable {
      void Fly();
    }

    class Orc: Monster {
      public override void Shout() {
        Console.WriteLine("록타르 오가르");
      }
    }

    class FlyableOrc: Orc, IFlyable {
      public void Fly() {
        Console.WriteLine("I can believe I can fly!");
      }
    }

    class Skeleton: Monster {
      public override void Shout() {
        Console.WriteLine("덜그럭 덜그럭");
      }
    }

    public static void Main(string[] args) {
      FlyableOrc flyingOrc = new FlyableOrc();
      flyingOrc.Shout();
      flyingOrc.Fly();

      Skeleton skeleton = new Skeleton();
      skeleton.Shout();
    }
  }
}