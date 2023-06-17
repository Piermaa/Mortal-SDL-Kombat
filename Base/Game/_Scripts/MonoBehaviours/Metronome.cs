using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Metronome : IMonoBehaviour
    {
        #region Singleton
        private static Metronome instance;

        public static Metronome Instance => instance;
        #endregion
        public Action onBPMTick;
        private double cooldownDebugger = 0.50847457;

        public void Awake(GameObject gameObject)
        {
            instance = this;
        }

        public void Update(float deltaTime)
        {
            GetBPM();
        }

        private void GetBPM()
        {
            cooldownDebugger -= Program.DeltaTime;

            if (cooldownDebugger < 0.25f)
            {
                if (cooldownDebugger <= 0)
                {
                    cooldownDebugger = 0.50847457;
                    onBPMTick?.Invoke();
                    Console.WriteLine("Has ended the bpm");
                }
            }
        }

        public bool AbleToShoot()
        {
            return cooldownDebugger < 0.25f;
        }

       
    }
}
