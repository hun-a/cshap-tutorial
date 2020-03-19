using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG {

  public enum GameMode {
    None,
    Lobby,
    Town,
    Field
  }

  class Game {
    private GameMode mode = GameMode.None;
    private Player player = null;
    private Monster monster = null;
    private Random rand = new Random();

    public void Process() {
      switch (mode) {
        case GameMode.None:
        case GameMode.Lobby:
          ProcessLobby();
          break;
        case GameMode.Town:
          ProcessTown();
          break;
        case GameMode.Field:
          ProcessField();
          break;
      }
    }

    private void ProcessLobby() {
      Console.WriteLine("* 직업을 선택하세요!");
      Console.WriteLine("[1] 기사");
      Console.WriteLine("[2] 궁수");
      Console.WriteLine("[3] 법사");

      string input = Console.ReadLine();
      switch (input) {
        case "1":
          player = new Knight();
          break;
        case "2":
          player = new Archer();
          break;
        case "3":
          player = new Mage();
          break;
      }

      mode = GameMode.Town;
    }

    private void ProcessTown() {
      Console.WriteLine("* 마을에 입장했습니다!");
      Console.WriteLine("[1] 필드로 가기");
      Console.WriteLine("[2] 로비로 돌아가기");

      string input = Console.ReadLine();
      switch (input) {
        case "1":
          mode = GameMode.Field;
          break;
        case "2":
          player = new Archer();
          mode = GameMode.Lobby;
          break;
      }
    }

    private void ProcessField() {
      Console.WriteLine("* 필드에 입장했습니다!");
      Console.WriteLine("[1] 싸우기");
      Console.WriteLine("[2] 도망가기");

      CreateRandomMonster();

      string input = Console.ReadLine();

      switch (input)
      {
        case "1":
          ProcessFight();
          break;
        case "2":
          TryEscape();
          break;
      }
    }

    private void CreateRandomMonster() {
      int randValue = rand.Next(0, 3);
      switch (randValue)
      {
        case 0:
          monster = new Slime();
          Console.WriteLine("슬라임이 생성되었습니다.");
          break;
        case 1:
          monster = new Orc();
          Console.WriteLine("오크가 생성되었습니다.");
          break;
        case 2:
          monster = new Skeleton();
          Console.WriteLine("스켈레톤이 생성되었습니다.");
          break;
      }
    }

    private void ProcessFight() {
      while (true) {
        int damage = player.GetAttack();
        monster.OnDamaged(damage);
        if (monster.isDead()) {
          Console.WriteLine("승리했습니다.");
          break;
        }

        damage = monster.GetAttack();
        player.OnDamaged(damage);
        if (player.isDead()) {
          Console.WriteLine("패배했습니다.");
          mode = GameMode.Lobby;
          break;
        }
      }
      Console.WriteLine($"Player hp: {player.GetHp()}, Monster hp: {monster.GetHp()}");
    }

    private void TryEscape() {
      int randValue = rand.Next(0, 101);
      if (randValue < 30) {
        Console.WriteLine("도망치기 성공!");
        mode = GameMode.Town;
      } else {
        ProcessFight();
      }
    }
  }
}