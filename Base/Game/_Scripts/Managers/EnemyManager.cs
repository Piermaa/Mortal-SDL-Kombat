using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class EnemyManager : IMonoBehaviour
    {
        private Metronome metronome;

        private int rounds;

        public void Awake(GameObject gameObject)
        {
            metronome = GameManager.Instance.CurrentScene.FindObjectOfType<Metronome>();
            metronome.onBPMTick += CalculateTicks;
        }

        public void Update(float deltaTime)
        {
            
        }

        private void CalculateTicks()
        {
            if (metronome.Ticks % 10 == 0)
            {
                SpawnFromFactory();
            }
        }


        private void SpawnFromFactory()
        {
            switch (rounds)
            {
                case 0:
                    Spawn(5, TypeOfEnemy.Normal);
                    break;

                case 1:
                    Spawn(3, TypeOfEnemy.Heavy);
                    break;

                case 2:
                    Spawn(1, TypeOfEnemy.Boss);
                    rounds = -1;
                    break;
            }

            rounds++;
            
        }

        private static void Spawn(int enemies, TypeOfEnemy type)
        {
            int posX = 0;

            switch (enemies)
            {
                case 5:
                    posX = 75;
                    break;

                case 3:
                    posX = 215;
                    break;

                case 1:
                    posX = 355;
                  break;
            }

            for (int i = 0; i < enemies; i++)
            {
                var enemyGameObject = new GameObject("Enemy");
                EnemyCharacter enemyCharacter = EnemyFactory.CreateEnemy(enemyGameObject, type);
                enemyGameObject.AddComponent(enemyCharacter);
                enemyGameObject.transform.SetPosition(new Vector2((i * 140) + posX, 50));
            }
        }
    }
}
