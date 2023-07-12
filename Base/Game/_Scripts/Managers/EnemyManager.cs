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
            if (metronome.Ticks==200)
            {
                GameManager.Instance.Win();
            }
            if (metronome.Ticks % 18 == 0)
            {
                SpawnFromFactory();
            }
        }


        private void SpawnFromFactory()
        {
            switch (rounds)
            {
                case 0:
                    Spawn(3, TypeOfEnemy.Normal);
                    break;

                case 1:
                    Spawn(2, TypeOfEnemy.Heavy);
                    break;

                case 2:
                    Spawn(4, TypeOfEnemy.Normal);

                    break;

                case 3:
                    Spawn(3, TypeOfEnemy.Heavy);
                    break;

                case 4:
                    Spawn(5, TypeOfEnemy.Normal);
                    break;

                case 5:
                    Spawn(4, TypeOfEnemy.Heavy);
                    break;

                case 6:
                    Spawn(1, TypeOfEnemy.Boss);
                    Spawn(2, TypeOfEnemy.Normal);    
                    break;
            }

            rounds++;
            
        }

        private static void Spawn(int enemies, TypeOfEnemy type)
        {
            int posX = 0;
            int posDiff = 0;

            switch (enemies)
            {
                case 1:
                    posX = 355;
                    posDiff = 0;
                    break;

                case 2:
                    posX = 220;
                    posDiff = 300;
                    break;

                case 3:
                    posX = 135;
                    posDiff = 220;
                    break;

                case 4:
                    posX = 100;
                    posDiff = 175;
                    break;

                case 5:
                    posX = 75;
                    posDiff = 140;
                    break;
            }

            for (int i = 0; i < enemies; i++)
            {
                var enemyGameObject = new GameObject("Enemy");
                EnemyCharacter enemyCharacter = EnemyFactory.CreateEnemy(enemyGameObject, type);
                enemyGameObject.AddComponent(enemyCharacter);
                enemyGameObject.transform.SetPosition(new Vector2((i * posDiff) + posX, -50));
            }
        }
    }
}
