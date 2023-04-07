using System.Media;

namespace TestEngine
{
    internal class MusicPlayer : IMonoBehaviour
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
    }
}
