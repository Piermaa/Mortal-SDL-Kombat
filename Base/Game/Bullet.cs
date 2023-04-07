using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bullet
    {
        float _speed = 150;
        float _posX = 0;
        float _posY = 0;
        float _rot = 0;

        float lifeTime = 1;
        float timer = 0;

        bool draw = true;

        public bool Draw => draw;

        public Bullet(float posX, float posY, float rot)
        {
            _posX = posX;
            _posY = posY;
            _rot = rot;
        }

        public void Update()
        {
            _posY -= _speed * Program.deltaTime;

            timer += Program.deltaTime;

            if (timer >= lifeTime)
            {
                draw = false;
            }
        }

        public void DrawBullet()
        {
            if (draw)
                Engine.Draw("0.png", _posX, _posY, .25f, .25f, _rot, 145.5f, 86.5f);
        }

    }
}
