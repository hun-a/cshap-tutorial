using System;

class MainClass {

  enum ClassType {
    None = 0,
    Knight = 1,
    Archer = 2,
    Mage = 3
  }

  struct Player {
    public int hp;
    public int attack;
    public ClassType type;
  }

  enum MonsterType {
    None = 0,
    Slime = 1,
    Orc = 2,
    Skeleton = 3
  }

  struct Monster {
    public int hp;
    public int attack;
    public MonsterType type;
  }

  public static void Main (string[] args) {
    while (true) {
      // Select the class type
      ClassType choice = ChooseClass();

      // Create the character
      Player player = new Player();
      player.type = choice;
      CreatePlayer(ref player);

      // Go to Play!
      EnterGame(player);
    }
  }

  static ClassType ChooseClass() {
    ClassType choice = ClassType.None;

    while (choice == ClassType.None) {
      Console.WriteLine("* 직업을 선택하세요!");
      Console.WriteLine("[1] 기사");
      Console.WriteLine("[2] 궁수");
      Console.WriteLine("[3] 법사");

      string input = Console.ReadLine();

      switch (input) {
        case "1":
          choice = ClassType.Knight;
          break;
        case "2":
          choice = ClassType.Archer;
          break;
        case "3":
          choice = ClassType.Mage;
          break;
      }
    }

    return choice;
  }

  static void CreatePlayer(ref Player player) {
    // Knight(100/10), Archar(75/12), Mage(50/15)
    switch(player.type) {
      case ClassType.Knight:
        player.hp = 100;
        player.attack = 10;
        break;
      case ClassType.Archer:
        player.hp = 75;
        player.attack = 12;
        break;
      case ClassType.Mage:
        player.hp = 50;
        player.attack = 12;
        break;
      default:
        player.hp = 0;
        player.attack = 0;
        break;
    }
  }

  static void EnterGame(Player player) {
    while (true) {
      if (player.hp <= 0) {
        return;
      }

      Console.WriteLine("* 마을에 접속했습니다!");
      Console.WriteLine("[1] 필드로 간다");
      Console.WriteLine("[2] 로비로 돌아간다");

      string input = Console.ReadLine();

      if (input == "1") {
        EnterField(ref player);
      } else if (input == "2") {
        return;
      }
    }
  }

  static void EnterField(ref Player player) {
    while (true) {
      if (player.hp <= 0) {
        break;
      }

      Console.WriteLine("* 필드에 접속했습니다!");

      // 몬스터 생성
      Monster monster = new Monster();
      CreateRandomMonster(ref monster);

      Console.WriteLine("[1] 전투 모드로 돌입");
      Console.WriteLine("[2] 일정 확률로 마을로 도망");

      string input = Console.ReadLine();
      if (input == "1") {
        Fight(ref player, ref monster);
      } else if (input == "2") {
        Random rand = new Random();
        int randValue = rand.Next(0, 101);
        if (randValue <= 33) {
          Console.WriteLine("도망치는데 성공했습니다!");
          break;
        } else {
          Fight(ref player, ref monster);
        }
      }
    }
  }

  static void CreateRandomMonster(ref Monster monster) {
    Random rand = new Random();
    int randMonster = rand.Next(1, 4);

    switch (randMonster) {
      case (int)MonsterType.Slime:
        Console.WriteLine("슬라임이 스폰되었습니다!");
        monster.type = MonsterType.Slime;
        monster.hp = 20;
        monster.attack = 2;
        break;
      case (int)MonsterType.Orc:
        Console.WriteLine("오크가 스폰되었습니다!");
        monster.type = MonsterType.Slime;
        monster.hp = 40;
        monster.attack = 4;
        break;
      case (int)MonsterType.Skeleton:
        Console.WriteLine("스켈레톤이 스폰되었습니다!");
        monster.type = MonsterType.Slime;
        monster.hp = 30;
        monster.attack = 3;
        break;
      default:
        monster.type = MonsterType.None;
        monster.hp = 0;
        monster.attack = 0;
        break;

    }
  }

  static void Fight(ref Player player, ref Monster monster) {
    while (true) {
      monster.hp -= player.attack;
      if (monster.hp <= 0) {
        Console.WriteLine("승리했습니다!");
        Console.WriteLine($"남은 체력: {player.hp}");
        break;
      }

      player.hp -= monster.attack;
      if (player.hp <= 0) {
        Console.WriteLine("패배했습니다!");
        break;
      }
    }
  }
}