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
            var playerHealth = GameManager.Instance.player.GetComponent<PlayerCharacter>();

            int damage = 1;

            playerHealth.TakeDamage(damage);

            var expectedLife = playerHealth.Health - damage;

            var life = playerHealth.Health;

            Assert.AreEqual(expectedLife, life);
        }
    }
}

