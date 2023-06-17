using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BpmIcon :IMonoBehaviour
    {
        private GameObject gameObject;
        private Metronome metronome;

        private Texture tickOn;
        private Texture tickOff;

        private SpriteRenderer sr;


        private float tickOnTime=0.1f;
        private float tickOnTimeleft;
        public void Awake(GameObject gameObject)
        {
            tickOff = Engine.GetTexture("Textures/UI/TickOff.png");
            tickOn = Engine.GetTexture("Textures/UI/TickOn.png");

            this.gameObject = gameObject;
            metronome=GameManager.Instance.CurrentScene.FindObjectOfType<Metronome>();
            metronome.onBPMTick +=ShowBPMTick;
            gameObject.OnDestroy += Unsusribe;

            gameObject.transform.position= new Vector2(GameManager.Instance.WindowDimensions.x/2 - 5,
                650);
            gameObject.transform.scale= new Vector2(0.2f,0.2f);

            sr = gameObject.GetComponent<SpriteRenderer>();

            sr.SetTexture(tickOff);
        }
        public void Update(float deltaTime)
        {
            //Engine.Debug()
            if (tickOnTimeleft >= 0)
            {
                tickOnTimeleft -= deltaTime;
            }
            else
            {
                sr.SetTexture(tickOff);
            }
        }

        private void Unsusribe()
        {
            metronome.onBPMTick -= ShowBPMTick;
            gameObject.OnDestroy -= Unsusribe;
        }

        private void ShowBPMTick()
        {
            Engine.Debug("tick");
            sr.SetTexture(tickOn);
            tickOnTimeleft = tickOnTime;
        }
    }
}
