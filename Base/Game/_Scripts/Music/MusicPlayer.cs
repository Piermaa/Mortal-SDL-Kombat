using System.Media;

namespace Game
{
    class MusicPlayer : IMonoBehaviour
    {
        GameObject gameObject;
        SoundPlayer soundPlayer = new SoundPlayer("TaylorSong");

        public void Start(GameObject gameObject)
        {
            this.gameObject = gameObject;

            //PlaySong();
        }

        public void Update(float deltaTime)
        {

        }

        public void PlaySong()
        {
            soundPlayer.PlayLooping();
        }

        public void Awake(GameObject gameObject)
        {
            throw new System.NotImplementedException();
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }
    }
}
