using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;

namespace UnitTestProject
{
    [TestClass]
    public class SpriteTest
    {
        [TestMethod]
        public void AddToLayerOk()
        {
            var layerManager = new LayersManager();
            SpriteRenderer sr = new SpriteRenderer();
            layerManager.AddSpriteToLayer(0, sr);

            Assert.AreEqual(layerManager.Layers[0].sprites.Count, 1);
        }
    }
}
