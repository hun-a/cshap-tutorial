using System;

namespace Event {
  class Runner {

    private static void OnInputTest() {
      Console.WriteLine("\nKey is pressed!");
    }

    public static void Main(string[] args) {
      InputManager inputManager = new InputManager();
      inputManager.InputKey += OnInputTest;

      while (true) {
        inputManager.Update();
      }
    }
  }
}