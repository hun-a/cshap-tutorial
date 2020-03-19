using System;

namespace Delegate {
  class Runner {
    delegate void OnClicked();

    private static void ButtonPressed(OnClicked clickedFunction) {
      clickedFunction();
    }

    private static void Func() {
      Console.WriteLine("Hello Delegate!");
    }

    public static void Main(string[] args) {
      OnClicked clicked = new OnClicked(Func);
      clicked += Func;

      ButtonPressed(clicked);
    }
  }
}