using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionTutorial {
  class Runner {

    class Important: System.Attribute {
      private string message { get; }

      public Important(string message) {
        this.message = message;
      }
    }

    class Monster {
      [Important("Very Important")]
      public int hp;
      protected int attack;
      private float speed;

      void Attack() { }
    }
    public static void Main(string[] args) {
      Monster monster = new Monster();
      Type type = monster.GetType();
      FieldInfo[] fields = type.GetFields(
          BindingFlags.Public
        | BindingFlags.NonPublic
        | BindingFlags.Static
        | BindingFlags.Instance);

      foreach(FieldInfo field in fields) {
        string access = "protected";

        if (field.IsPublic) {
          access = "public";
        } else if (field.IsPrivate) {
          access = "private";
        }

        IEnumerable<Attribute> attributes = field.GetCustomAttributes();
        foreach(Attribute attribute in attributes) {
          Console.WriteLine(attribute);
        }

        Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");
      }
    }
  }
}