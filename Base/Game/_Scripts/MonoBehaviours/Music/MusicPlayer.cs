using System.Media;
//NO UTILIZADO TODAVIA, ACA VAMOS A IMPLEMENTAR LO DE DIRECTX AUDIO
namespace Game
{
    class MusicPlayer : IMonoBehaviour
    {
        #region Singleton
        private static MusicPlayer instance;

        public static MusicPlayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MusicPlayer();
                }
                return instance;
            }
        }
        #endregion

        private GameObject gameObject;
        private SoundPlayer soundPlayer = new SoundPlayer("TaylorSong");

        public void PlaySong()
        {
            soundPlayer.PlayLooping();
        }

        public void Awake(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void Update(float deltaTime)
        {

        }
    }
}
