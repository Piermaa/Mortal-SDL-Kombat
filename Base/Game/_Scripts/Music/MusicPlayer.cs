using System.Media;

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

        GameObject gameObject;
        SoundPlayer soundPlayer = new SoundPlayer("TaylorSong");


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
