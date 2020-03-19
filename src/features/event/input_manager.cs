using System;

namespace Event {

  class InputManager {

    public delegate void OnInputKey();
    public event OnInputKey InputKey;

    public void Update() {
      if (Console.KeyAvailable == false) {
        return;
      }

      ConsoleKeyInfo info = Console.ReadKey();
      if (info.Key == ConsoleKey.A) {
        InputKey();
      }
    }
  }
}