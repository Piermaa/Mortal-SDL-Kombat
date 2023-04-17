using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class EnemyCharacter: BaseCharacter, IMonoBehaviour
    {   
        public EnemyCharacter(GameObject _gameObject, string textureName) : base(_gameObject, textureName)
        {
            CharactersManager.Instance.Characters.Add(this);
        }

        public void Awake(GameObject gameObject)
        {
            gameObject.transform.scale = new Vector2(3, 3);
            gameObject.transform.rotation = 180;
        }

        public void Start()
        {
            
        }

        public void Update(float deltaTime)
        {
           
        }
    }
}
