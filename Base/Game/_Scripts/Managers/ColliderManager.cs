using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ColliderManager : IMonoBehaviour
    {
        #region Singleton
        private static ColliderManager instance;

        public static ColliderManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ColliderManager();
                }
                return instance;
            }
        }
        #endregion

        private GameObject playerCollider;
        public GameObject PlayerCollider
        {
            get { return playerCollider; }
            set { playerCollider = value; }
        }

        private List<GameObject> enemies = new List<GameObject>();
        public List<GameObject> EnemyColliders
        {
            get
            {
                List<GameObject> eCols = enemies;
                return eCols;
            }
        }

        private List<BulletPrefab> bullets = new List<BulletPrefab>();

        private List<BulletPrefab> bulletsToRemove = new List<BulletPrefab>();
        private List<GameObject> enemiesToRemove = new List<GameObject>();

        public void AddEnemyCollider(GameObject col)
        {
            enemies.Add(col);
        }

        public void AddBulletCollider(BulletPrefab col)
        {
            bullets.Add(col);
        }

        public void RemoveEnemyCollider(GameObject col)
        {
            enemies.Remove(col);
        }

        public void RemoveBulletCollider(BulletPrefab col)
        {
            //xd
            bulletsToRemove.Add(bullets.Find((x) => col == x));
            //POR LO QUE ENTENDI:
            //Se agrega a la lista de balas a remover una bala. Esta bala que agregamos se obtiene buscandola en la lista.
            //Para buscarla se pasa como parametro aquella que se comparará. X entiendo que es como el nombre de la variable en un foreach
            //Es decir, foreach(BulletPrefab x in bullets) {if(x==col) return col;}
            //inchequeable.
            //TODO: preguntarle a ed sheerann a ver si lo explica distinto 
        }

        public void Reset()
        {
            bullets.Clear();
            enemies.Clear();
            playerCollider = default;
        }

        public bool AreCircleColliding(GameObject p_objA, GameObject p_objB)
        {
            float distanceX = p_objA.transform.position.x - p_objB.transform.position.x;
            float distanceY = p_objA.transform.position.y - p_objB.transform.position.y;

            float totalDistance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
            if (totalDistance < p_objA.Radius + p_objB.Radius)
            {
                Engine.Debug($"{p_objA.IsEnabled}  {p_objB.IsEnabled}");
            }
            return p_objA.IsEnabled && p_objB.IsEnabled && totalDistance < p_objA.Radius + p_objB.Radius;
        }

        public void Awake(GameObject gameObject)
        {

        }

        public void Update(float deltaTime)
        {
            //por cada bullet instanciada
            foreach (BulletPrefab currentBullet in bullets)
            {
                //verificar si es aliada
                var b = currentBullet.GetComponent<Bullet>();

                if (b.Ally)
                {
                    //si lo es, verificar si impacta algun enemigo
                    for (int j = 0; j < enemies.Count; j++)
                    {
                        if (AreCircleColliding(currentBullet, enemies[j]))
                        {
                            var enemy = enemies[j].GetComponent<EnemyCharacter>();
                            enemy.TakeDamage(1);
                            currentBullet.Disable();
                            return;
                        }
                    }
                }
                else
                {
                    //sino, verificar si impacta al player
                    if (AreCircleColliding(currentBullet, playerCollider))
                    {
                        currentBullet.Disable();
                        var player = playerCollider.GetComponent<PlayerCharacter>();
                        player.TakeDamage(1);
                    }
                }
            }
            // las balas no son eliminadas de la lista al impactar. Al impactar se agregar a una lista de objetos a remover
            // por que? Porque al usar foreach, si durante el foreach se cambiaba el .Count de la List se rompia todo
            foreach (BulletPrefab btr in bulletsToRemove)
            {
                bullets.Remove(btr);
            }
            bulletsToRemove.Clear(); // se limpia la lista para que no se vuelvan a eliminar las que ya se eliminaron
        }
    }
}