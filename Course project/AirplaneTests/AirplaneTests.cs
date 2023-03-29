using Core.Game;
using Core.Game.Missile;
using Core.Game.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirplaneTests
{
  /// <summary>
  /// ����� ��� ������ Airplane
  /// </summary>
  [TestClass]
  public class AirplaneTests
  {
    /// <summary>
    /// ���������� ��� ���������� ����������� ��������
    /// </summary>
    private const int COORD_FOR_FREE_MOVE = 200;

    /// <summary>
    /// ��������� ��������� ����������� �������� ������
    /// </summary>
    [TestMethod]
    public void FreeMoveRightTest()
    {
      GameModel newGame = new GameModel();
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE, null);
      double expectedX = airplane.X + Airplane.OFFSET;
      airplane.MoveRight();
      Assert.AreEqual(expectedX, airplane.X);
    }

    /// <summary>
    /// ��������� ����������� �������� ������, ����� �� ��������� � ���� ������
    /// </summary>
    [TestMethod]
    public void WallMoveRightTest()
    {
      GameModel newGame = new GameModel();
      double initialX = GameModel.SCREEN_WIDTH - Airplane.WIDTH;
      Airplane airplane = new Airplane(newGame, initialX, COORD_FOR_FREE_MOVE, null);
      airplane.MoveRight();
      Assert.AreEqual(initialX, airplane.X);
    }

    /// <summary>
    /// ��������� ����������� �������� ������, ����� �� ��������� ����� � �������� ������ �� ����������, ������� ��� ��� ����������� ������������
    /// </summary>
    [TestMethod]
    public void NearToWallMoveRightTest()
    {
      GameModel newGame = new GameModel();
      double initialX = GameModel.SCREEN_WIDTH - Airplane.WIDTH - Airplane.OFFSET / 2.0;
      Airplane airplane = new Airplane(newGame, initialX, COORD_FOR_FREE_MOVE, null);
      double expectedX = GameModel.SCREEN_WIDTH - Airplane.WIDTH;
      airplane.MoveRight();
      Assert.AreEqual(expectedX, airplane.X);
    }

    /// <summary>
    /// ��������� ��������� ����������� �������� �����
    /// </summary>
    [TestMethod]
    public void FreeMoveLeftTest()
    {
      GameModel newGame = new GameModel();
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE, null);
      double expectedX = airplane.X - Airplane.OFFSET;
      airplane.MoveLeft();
      Assert.AreEqual(expectedX, airplane.X);
    }

    /// <summary>
    /// ��������� ����������� �������� �����, ����� �� ��������� � ���� ������
    /// </summary>
    [TestMethod]
    public void WallMoveLeftTest()
    {
      GameModel newGame = new GameModel();
      double initialX = 0;
      Airplane airplane = new Airplane(newGame, initialX, COORD_FOR_FREE_MOVE, null);
      airplane.MoveLeft();
      Assert.AreEqual(initialX, airplane.X);
    }

    /// <summary>
    /// ��������� ����������� �������� �����, ����� �� ��������� ����� � �������� ������ �� ����������, ������� ��� ��� ����������� ������������
    /// </summary>
    [TestMethod]
    public void NearToWallMoveLeftTest()
    {
      GameModel newGame = new GameModel();
      double initialX = 0 + Airplane.OFFSET / 2.0;
      Airplane airplane = new Airplane(newGame, initialX, COORD_FOR_FREE_MOVE, null);
      double expectedX = 0;
      airplane.MoveLeft();
      Assert.AreEqual(expectedX, airplane.X);
    }

    /// <summary>
    /// ��������� ��������� ����������� �������� �����
    /// </summary>
    [TestMethod]
    public void FreeMoveUpTest()
    {
      GameModel newGame = new GameModel();
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE, null);
      double expectedY = airplane.Y - Airplane.OFFSET;
      airplane.MoveUp();
      Assert.AreEqual(expectedY, airplane.Y);
    }

    /// <summary>
    /// ��������� ����������� �������� �����, ����� �� ��������� � ���� ������
    /// </summary>
    [TestMethod]
    public void WallMoveUpTest()
    {
      GameModel newGame = new GameModel();
      double initialY = GameModel.SCREEN_TEXT_HEIGHT;
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, initialY, null);
      airplane.MoveUp();
      Assert.AreEqual(initialY, airplane.Y);
    }

    /// <summary>
    /// ��������� ����������� �������� �����, ����� �� ��������� ����� � �������� ������ �� ����������, ������� ��� ��� ����������� ������������
    /// </summary>
    [TestMethod]
    public void NearToWallMoveUpTest()
    {
      GameModel newGame = new GameModel();
      double initialY = GameModel.SCREEN_TEXT_HEIGHT + Airplane.OFFSET / 2.0;
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, initialY, null);
      double expectedY = GameModel.SCREEN_TEXT_HEIGHT;
      airplane.MoveUp();
      Assert.AreEqual(expectedY, airplane.Y);
    }

    /// <summary>
    /// ��������� ��������� ����������� �������� ����
    /// </summary>
    [TestMethod]
    public void FreeMoveDownTest()
    {
      GameModel newGame = new GameModel();
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE,  null);
      double expectedY = airplane.Y + Airplane.OFFSET;
      airplane.MoveDown();
      Assert.AreEqual(expectedY, airplane.Y);
    }

    /// <summary>
    /// ��������� ����������� �������� ����, ����� �� ��������� � ���� ������
    /// </summary>
    [TestMethod]
    public void WallMoveDownTest()
    {
      GameModel newGame = new GameModel();
      double initialY = GameModel.SCREEN_HEIGHT - Airplane.HEIGHT;
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, initialY, null);
      airplane.MoveDown();
      Assert.AreEqual(initialY, airplane.Y);
    }

    /// <summary>
    /// ��������� ����������� �������� ����, ����� �� ��������� ����� � �������� ������ �� ����������, ������� ��� ��� ����������� ������������
    /// </summary>
    [TestMethod]
    public void NearToWallMoveDownTest()
    {
      GameModel newGame = new GameModel();
      double initialY = GameModel.SCREEN_HEIGHT - Airplane.HEIGHT - Airplane.OFFSET / 2.0;
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, initialY, null);
      double expectedY = GameModel.SCREEN_HEIGHT - airplane.Height;
      airplane.MoveDown();
      Assert.AreEqual(expectedY, airplane.Y);
    }

    /// <summary>
    /// ��������� ������ ������ ������
    /// </summary>
    [TestMethod]
    public void ShotgunBonusTakeTest()
    {
      GameModel newGame = new GameModel();
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE, null);
      newGame.Airplane = airplane;
      Bonus shotgunBonus = new Bonus(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE);
      
      shotgunBonus.BonusType = BonusType.Shotgun;
      shotgunBonus.Update();
      Assert.IsTrue(airplane.Weapon is Shotgun);
    }

    /// <summary>
    /// ��������� ������ ������ �������
    /// </summary>
    [TestMethod]
    public void EnergyBonusTakeTest()
    {
      GameModel newGame = new GameModel();
      int energyNumber = 10;
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE, null);
      airplane.Energy = energyNumber;
      newGame.Airplane = airplane;
      Bonus energyBonus = new Bonus(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE);

      energyBonus.BonusType = BonusType.Energy;
      energyBonus.Update();

      int expectedEnergy = energyNumber + Bonus.BONUS_ENERGY_AMOUNT;
      Assert.AreEqual(expectedEnergy, airplane.Energy);
    }

    /// <summary>
    /// ��������� �� ������ ������ ������ 
    /// </summary>
    [TestMethod]
    public void ShotgunBonusNotTakeTest()
    {
      GameModel newGame = new GameModel();
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE, null);
      newGame.Airplane = airplane;
      Bonus shotgunBonus = new Bonus(newGame, COORD_FOR_FREE_MOVE + airplane.Width + 1, COORD_FOR_FREE_MOVE);

      shotgunBonus.BonusType = BonusType.Shotgun;
      shotgunBonus.Update();
      Assert.IsTrue(airplane.Weapon == null);
    }

    /// <summary>
    /// ��������� �� ������ ������ �������
    /// </summary>
    [TestMethod]
    public void EnergyBonusNotTakeTest()
    {
      GameModel newGame = new GameModel();
      int energyNumber = 10;
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE, null);
      airplane.Energy = energyNumber;
      newGame.Airplane = airplane;
      Bonus energyBonus = new Bonus(newGame, COORD_FOR_FREE_MOVE + airplane.Width + 1, COORD_FOR_FREE_MOVE);

      energyBonus.BonusType = BonusType.Energy;
      energyBonus.Update();

      Assert.AreEqual(energyNumber, airplane.Energy);
    }

    /// <summary>
    /// ��������� ������ ������� �������
    /// </summary>
    [TestMethod]
    public void LightningEnergyWastingTest()
    {
      GameModel newGame = new GameModel();
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE, null);
      int expectedEnergy = airplane.Energy - Airplane.LIGHTNING_ENERGY_COST;
      airplane.UseLightning();

      Assert.AreEqual(expectedEnergy, airplane.Energy);
    }

    /// <summary>
    /// ��������� ������������� ������ ��� ������������� ���������� �������
    /// </summary>
    [TestMethod]
    public void LightningEnergyNotWastingTest()
    {
      GameModel newGame = new GameModel();
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE, null);
      int energyNumber = Airplane.LIGHTNING_ENERGY_COST / 2;

      airplane.Energy = energyNumber;
      airplane.UseLightning();
      int expectedEnergy = energyNumber;

      Assert.AreEqual(expectedEnergy, airplane.Energy);
    }

    /// <summary>
    /// ��������� ��������� ����� �� ���������� �������
    /// </summary>
    [TestMethod]
    public void EnemyMissileDamageTakeTest()
    {
      GameModel newGame = new GameModel();
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE, null);
      newGame.Airplane = airplane;

      int damage = 10;
      int expectedHealth = airplane.Health - damage;

      WeaponMissile missile = new WeaponMissile(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE, 10, 10, 0, 0, MissileType.EnemyMissile, damage); 

      missile.Update();

      Assert.AreEqual(expectedHealth, airplane.Health);
    }

    /// <summary>
    /// ��������� ���������� ��������� ����� �� ����������� ��������
    /// </summary>
    [TestMethod]
    public void OwnMissileDamageNotTakeTest()
    {
      GameModel newGame = new GameModel();
      Airplane airplane = new Airplane(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE, null);
      newGame.Airplane = airplane;

      int damage = 10;
      int expectedHealth = airplane.Health;

      WeaponMissile machineGunMissile = new WeaponMissile(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE, 10, 10, 0, 0, MissileType.MachineGunMissile, damage);
      WeaponMissile shotgunMissile = new WeaponMissile(newGame, COORD_FOR_FREE_MOVE, COORD_FOR_FREE_MOVE, 10, 10, 0, 0, MissileType.ShotgunMissile, damage);

      machineGunMissile.Update();
      shotgunMissile.Update();

      Assert.AreEqual(expectedHealth, airplane.Health);
    }
  }
}