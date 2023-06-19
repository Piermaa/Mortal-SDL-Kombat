using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class EnemyManager
    {
        // Llamar al encapsulado de Ticks del metronome

        // Cada tantos ticks 

        // OnBpmTick += Method
        /* Method()
         * {
         *  if (ticks % 10 == 0)
         *  {
         *      Spawn from EnemyFactory
         *  }
         * }
         * 
        */

        /*
         * int posX = 75;
            for (int i = 0; i < 5; i++)
            {
                var enemyGameObject = new GameObject("Enemy");
                EnemyCharacter enemyCharacter = EnemyFactory.CreateEnemy(enemyGameObject, TypeOfEnemy.Normal); //Elegir el tipo de enemigo
                enemyGameObject.AddComponent(enemyCharacter);
                enemyGameObject.transform.SetPosition(new Vector2((i * 140) + posX, 50));
            }
         */
    }
}
