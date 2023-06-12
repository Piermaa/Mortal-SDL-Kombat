using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TakeDamageUnitTest()
        {
            GameObject playerGameObject = new GameObject("Player");
            playerGameObject = new GameObject("Player");

            int damage = 1;

            PlayerCharacter player = new PlayerCharacter(playerGameObject, "Textures/Player/Player.png");

            player.TakeDamage(damage);

            var expectedLife = player.health - damage;

            var life = player.health;

            Assert.AreEqual(expectedLife, life);
        }

        [TestMethod]
        public void VectorUnitTest()
        {
            int x = 2;
            int y = 5;

            var vector = new Vector2(x, y);

            var resultado = vector.ToString();

            var resultadoEsperado = $"X: {x} / Y: {y}";

            Assert.AreEqual(resultado, resultadoEsperado);
        }

        //[TestMethod]
        //public void AddSpriteUnitTest()
        //{
        //    GameObject playerGameObject = new GameObject("Player");
        //    playerGameObject = new GameObject("Player");
        //    SpriteRenderer spriteRenderer = new SpriteRenderer();
        //    string p_textureName = "Textures/Player/Player.png";

        //    spriteRenderer.SetTexture(Engine.GetTexture(p_textureName));
        //    playerGameObject.AddComponent(spriteRenderer);

        //}
    }
}

