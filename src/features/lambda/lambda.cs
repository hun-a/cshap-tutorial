using System;
using System.Collections;
using System.Collections.Generic;

namespace Lambda {
  class Runner {

    enum ItemType {
      Weapon, Armor, Ring
    }

    enum ItemRarity {
      Normal, Magic, Rare, Unique
    }

    class Item {
      public ItemType itemType { get; set; }
      public ItemRarity itemRarity { get; set; }

      public Item(ItemType itemType, ItemRarity itemRarity) {
        this.itemType = itemType;
        this.itemRarity = itemRarity;
      }
    }

    static List<Item> inventory = new List<Item>();

    static Item FindItem(Func<Item, bool> func) {
      foreach(Item item in inventory) {
        if (func(item)) {
          return item;
        }
      }
      return null;
    }

    public static void Main(string[] args) {
      inventory.Add(new Item(ItemType.Weapon, ItemRarity.Unique));
      inventory.Add(new Item(ItemType.Armor, ItemRarity.Rare));
      inventory.Add(new Item(ItemType.Ring, ItemRarity.Normal));

      Item weapon = FindItem(item => item.itemType.Equals(ItemType.Weapon));
      Console.WriteLine(weapon.itemType);

      Item unique = FindItem(item => item.itemRarity.Equals(ItemRarity.Unique));
      Console.WriteLine(unique.itemRarity);
    }
  }
}