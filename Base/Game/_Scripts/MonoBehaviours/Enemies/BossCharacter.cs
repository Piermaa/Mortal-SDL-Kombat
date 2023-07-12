using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BossCharacter : EnemyCharacter, IMonoBehaviour
    {
        private float horizontalSpeed = 100;
        private int posY = 50;
        private Vector2[] positions = {new Vector2(50,50), new Vector2(670,50) };
        private bool moveLeft;
   
        public BossCharacter(GameObject _gameObject, int score, string textureName, int attackSpeed, int health, float speed, bool isBoss, string texturePath) : base(_gameObject, score, textureName, attackSpeed, health, speed, isBoss, texturePath)
        {

        }
        public void Awake(GameObject gameObject)
        {
            metronome = GameManager.Instance.CurrentScene.FindObjectOfType<Metronome>();
            metronome.onBPMTick += Shoot;
            gameObject.transform.rotation = 180;
        }

        public void Update(float deltaTime)
        {
            Movement();
            if (gameObject.transform.position.y > 1000)
            {
                Destroy();
            }

        }

        private void Movement()
        {
            Vector2 velocity = Vector2.Zero;

            if (transform.position.x <= positions[0].x)
            {
                moveLeft = false;
            }
            if (transform.position.x >= positions[1].x)
            {
                moveLeft = true;
            }

            velocity.y= transform.position.y < 50 ? 100 :0;
            velocity.x = moveLeft ? -horizontalSpeed : horizontalSpeed;




            Engine.Debug(velocity);
            rb.Velocity = velocity;

        }
    }
}
