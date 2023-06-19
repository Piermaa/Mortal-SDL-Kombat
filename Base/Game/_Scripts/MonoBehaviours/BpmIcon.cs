using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BpmIcon :IMonoBehaviour
    {
        private GameObject leftTimeSign = new GameObject();
        private GameObject rightTimeSign = new GameObject();

        private GameObject gameObject;
        private Metronome metronome;

        private Texture tickOn;
        private Texture tickOff;

        private SpriteRenderer sr;

        private Vector2 leftTimeSignStartPosition = Vector2.Zero;
        private Vector2 rightTimeSignStartPosition = Vector2.Zero;

        private float tickOnTime=0.1f;
        private float tickOnTimeleft;

        private float yUI=650;
        public void Awake(GameObject gameObject)
        {

            this.gameObject = gameObject;
            //se busca la ref al metronomo
            metronome = GameManager.Instance.CurrentScene.FindObjectOfType<Metronome>();
            //y se suscriben los metodos al evento
            metronome.onBPMTick += ShowBPMTick;
            gameObject.OnDestroy += Unsusribe;

            //se crea el objeto de la barra de fondo
            CreateBar();

            //se guardan las texturas
            TexturesAsignment();

            sr = gameObject.GetComponent<SpriteRenderer>();
            sr.SetTexture(tickOff);

            //pongo en su lugar el simbolo del medio del HUD 
            gameObject.transform.position = new Vector2(GameManager.Instance.WindowDimensions.x / 2 - 5, yUI);
            gameObject.transform.scale = new Vector2(0.2f, 0.2f);

            //guarda posiciones iniciales de las flechitas
            leftTimeSignStartPosition = new Vector2(GameManager.Instance.WindowDimensions.x / 2 - 100, yUI);
            rightTimeSignStartPosition = new Vector2(GameManager.Instance.WindowDimensions.x / 2 + 95, yUI);

            InstantiateTimeSigns();
        }

        private void TexturesAsignment()
        {
            tickOff = Engine.GetTexture("Textures/UI/TickOff.png");
            tickOn = Engine.GetTexture("Textures/UI/TickOn.png");
        }

        private void CreateBar()
        {
            var bar = new GameObject();
            var barSr = new SpriteRenderer(3);
            bar.AddComponent(barSr);
            barSr.SetTexture(Engine.GetTexture("Textures/UI/bar.png"));
            bar.transform.position = new Vector2(GameManager.Instance.WindowDimensions.x / 2, yUI);
            bar.transform.scale = new Vector2(0.7f, 0.25f);
        }

        public void Update(float deltaTime)
        {
            leftTimeSign.transform.position= Vector2.Lerp(leftTimeSignStartPosition , gameObject.transform.position , (float)metronome.clampedCount);
            rightTimeSign.transform.position= Vector2.Lerp(rightTimeSignStartPosition , gameObject.transform.position,(float)metronome.clampedCount);
            //Engine.Debug()
            if (tickOnTimeleft > 0)
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
        /// <summary>
        /// Cambia la textura y resetea las flechitas 
        /// </summary>
        private void ShowBPMTick()
        {
            sr.SetTexture(tickOn);
            tickOnTimeleft = tickOnTime;
            ResetTimeSigns();
        }

        private void ResetTimeSigns()
        {
            leftTimeSign.transform.position = leftTimeSignStartPosition;
            rightTimeSign.transform.position = rightTimeSignStartPosition;
        }

        private void InstantiateTimeSigns()
        {
            //se crea una flechita a la izquierda y se le pone el sprite renderer
            var sr = new SpriteRenderer(3);
            leftTimeSign.AddComponent(sr);
            sr.SetTexture(Engine.GetTexture("Textures/UI/Time sign.png"));
            leftTimeSign.transform.position = leftTimeSignStartPosition;
            leftTimeSign.transform.scale = new Vector2(0.2f,0.2f);
            leftTimeSign.transform.rotation = 180;

            //se crea una flechita a la derecha y se le pone el sprite renderer
            var sr2 = new SpriteRenderer(3);
            rightTimeSign.AddComponent(sr2);
            sr2.SetTexture(Engine.GetTexture("Textures/UI/Time sign.png"));
            rightTimeSign.transform.position = rightTimeSignStartPosition;
            rightTimeSign.transform.scale = new Vector2(0.2f, 0.2f);
        }
    }
}
