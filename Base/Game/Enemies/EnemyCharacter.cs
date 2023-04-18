using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class EnemyCharacter: BaseCharacter, IMonoBehaviour
    {
        private float shootCD=2;
        private float shootTimer;

        public EnemyCharacter(GameObject _gameObject, string textureName, float attackSpeed) : base(_gameObject, textureName)
        {
            shootCD = attackSpeed;
        }

        public void Awake(GameObject gameObject)
        {
            gameObject.transform.scale = new Vector2(3, 3);
            gameObject.transform.rotation = 180;
        }

        public void Update(float deltaTime)
        {
            shootTimer = shootTimer > 0 ? shootTimer - deltaTime : 0;
            if (shootTimer == 0)
            {
                shootTimer = shootCD;
                var b = new GameObject("Bullet");
                Bullet bullet = new Bullet(b, false);
                b.transform.rotation = 180;
                b.transform.SetPosition(m_GameObject.transform.position);
            }
        }
    }
}
