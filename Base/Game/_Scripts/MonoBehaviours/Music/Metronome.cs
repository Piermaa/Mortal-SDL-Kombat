using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Metronome : IMonoBehaviour
    {
        public double clampedCount
        {
            get { return 1 - bpmCount / bpm; }
        }
        public event Action onBPMTick;

        private double bpm = 0.5f;

        private double bpmCount;
        private float bpmTollerance = 0.13f;

        private double bpmCountExtra;
        private float bpmTolleranceExtra = 0.13f;

        private bool canShoot;
        private bool hasShot;

        private int ticks = 0;

        public int Ticks => ticks;

        public void Awake(GameObject gameObject)
        {
            bpmCount = bpm;
        }

        public void Update(float deltaTime)
        {
            GetBPM(deltaTime);
            
            canShoot = AbleToShoot();
        }

        private void GetBPM(float deltaTime)
        {
            bpmCount -= deltaTime;
            bpmCountExtra += deltaTime;

            if (bpmCount < bpmTollerance && canShoot)
            {
                if (bpmCount <= 0)
                {
                    bpmCountExtra = 0;
                    ticks++;
                    bpmCount = bpm;
                    onBPMTick?.Invoke(); //otras clases le pueden decir aca pasan cosas
                }

                if (bpmCountExtra >= bpmTolleranceExtra + 0.2f)
                {
                    hasShot = false;
                    bpmCountExtra = 0;
                }
            }
        }

        public bool AbleToShoot()
        {
            return bpmCount < bpmTollerance || bpmCountExtra < bpmTolleranceExtra;
        }

        public bool CanShoot()
        {
            if (AbleToShoot() && !hasShot)
            {
                hasShot = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
