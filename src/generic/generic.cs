using System;
using System.Collections.Generic;

namespace Generics {

  class CustomList<T> {
    private T[] list;
    private int currentIndex = 0;

    public CustomList(int size) {
      list = new T[size];
    }

    public T[] GetList() {
      return list;
    }

    public void Add(T t) {
      list[currentIndex++] = t;
    }

    public T Get(int index) {
      return list[index];
    }

    public int Length() {
      return currentIndex;
    }
  }

  class Player {
    private int id;

    public Player(int id) {
      this.id = id;
    }

    public int GetId() {
      return id;
    }
  }

  class GenericTutorial {

    static void Main(string[] args) {
      CustomList<int> list = new CustomList<int>(10);
      Console.WriteLine($"Length: {list.Length()}");

      list.Add(10);
      list.Add(20);
      list.Add(30);

      Console.WriteLine($"Length: {list.Length()}");
      
      for (int i = 0; i < list.Length(); i++) {
        Console.WriteLine($"Index: {i}, Value: {list.Get(i)}");
      }

      Console.WriteLine(list.GetList());


      CustomList<Player> playerList = new CustomList<Player>(10);
      Console.WriteLine($"Player Length: {playerList.Length()}");

      playerList.Add(new Player(10));
      Console.WriteLine($"Player Length: {playerList.Length()}");
      Console.WriteLine($"Player ID: {playerList.Get(0).GetId()}");
    }
  }

}