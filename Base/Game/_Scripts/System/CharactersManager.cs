using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
     class CharactersManager
    {
        #region Singleton
        private static CharactersManager instance;

        public static CharactersManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CharactersManager();
                }
                return instance;
            }
        }
        #endregion

        private List<BaseCharacter> characters = new List<BaseCharacter>();

        public List<BaseCharacter> Characters => characters;
        //SI QUIERO UNA REF LOCAL A LA LISTA CACHEADO (MAS PERFORMANTE): var l_Characters= Manager.Instance.Characters;
        // l_ porque es local
    }
}
