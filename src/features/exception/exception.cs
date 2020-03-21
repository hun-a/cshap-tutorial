using System;

namespace ExceptionTutorial {
  class Runner {

    class CustomException: Exception { }

    public static void WTF() {
      throw new CustomException();
    }

    public static void Main(string[] args) {
      try {
        WTF();
      } catch (CustomException e) {
        Console.WriteLine(e);
      }
    }
  }
}