using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Metronome : IMonoBehaviour
    {
        public Action onBPMTick;
        private double bpm = 0.50847457;
        private double bpmCount;
        private float bpmTollerance = 0.25f;

        private int ticks=0;

        public void Awake(GameObject gameObject)
        {
            bpmCount = bpm;
        }

        public void Update(float deltaTime)
        {
            GetBPM(deltaTime);
        }

        private void GetBPM(float deltaTime)
        {
            bpmCount -= deltaTime;

            if (bpmCount < bpmTollerance)
            {
                if (bpmCount <= 0)
                {
                    ticks++;
                    bpmCount = bpm;
                    onBPMTick?.Invoke();
                    Console.WriteLine("Has ended the bpm");
                }
            }
        }

        public bool AbleToShoot()
        {
            return bpmCount < bpmTollerance;
        }

        public bool CanShoot()
        {
            return (bpmCount-bpmTollerance) < 0;
        }
    }
}
