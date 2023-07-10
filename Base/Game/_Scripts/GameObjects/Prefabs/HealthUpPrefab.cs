using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class HealthUpPrefab : GameObject
    {
        public HealthUpPrefab()
        {
            ColliderManager.Instance.AddPowerUpCollider(this);
            transform.scale = new Vector2(.2f,.2f);
            AddComponent(new RigidBody());
            SpriteRenderer sr = new SpriteRenderer();
            sr.SetTexture(Engine.GetTexture("Textures/UI/Health/HealthUp.png"));
            AddComponent(sr);
            AddComponent(new HealthUp());
        }
    }
}
