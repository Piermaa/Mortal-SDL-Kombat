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

            player.TakeDamage(damage);

            var life = player.Health;

            Assert.AreEqual(expectedLife, life);
        }

      
    }
    [TestClass]
    public class SpriteTest
    {
        [TestMethod]
        public void AddToLayerOk()
        {
            var layers = new LayersManager();
            SpriteRenderer sr = new SpriteRenderer();
            layers.AddSpriteToLayer(0, sr);

            Assert.AreEqual(layers.Layers[0].sprites.Count, 1);
        }
    }
}

