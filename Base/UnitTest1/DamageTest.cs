using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;

namespace UnitTestProject
{
    [TestClass]
    public class DamageTests
    {
        [TestMethod]
        public void TakeDamageUnitTest()
        {
            var playerGameObject = new GameObject();

            PlayerCharacter player = new PlayerCharacter(playerGameObject, "Textures/Player/Player.png");

            int damage = 1;

            var expectedLife = player.Health - damage;

            var life = player.Health;

            Assert.AreNotEqual(expectedLife, life);
        }
    }
}