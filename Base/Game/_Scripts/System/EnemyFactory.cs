using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //JUAN: NO LE PASES UNA TEXTURA AL PARAMETRO  DEL COSNTRUCTOR!! POR QUE? PIERMA?!!?!!
    //PORQUE VAS A HACER ANIMACIONES
    //PORQUE SI LE PASAS UNA TEXTURA DESPUES TODOS VAN A TENER LA MISMA ANIMACION, ENTONCES TENES QUE PASARLE LA KEY DE LA ANIMACION (STRING PARA EL DICCIONARIO)
    //ESAS ANIMACIONES TENES Q HACERLAS ANTES DE LLAMAR EL ENEMYFACTORY, PORQUE SINO OBJECT REFERENCE ES NOT SET AN INSTANCE OF AN OBJECT 
    public enum TypeOfEnemy { Normal, Heavy, Boss }
 
    static class EnemyFactory
    {
        private const string NORMAL= "0";
        private const string HEAVY= "0";
        private const string BOSS= "0";

        public static EnemyCharacter CreateEnemy(GameObject p_gameObject,TypeOfEnemy type)
        {
            switch (type)
            {
                case TypeOfEnemy.Normal:
                    p_gameObject.transform.scale = new Vector2(3, 3);
                    return new EnemyCharacter(p_gameObject,NORMAL,2, 1, 100,"Textures/Animations/Enemy/NormalEnemy/");
                    break;

                case TypeOfEnemy.Heavy:
                    p_gameObject.transform.scale = new Vector2(0.25f, 0.25f);
                    return new EnemyCharacter(p_gameObject,HEAVY,3, 9, 75, "Textures/Animations/Enemy/HeavyEnemy/");
                    break;

                case TypeOfEnemy.Boss:
                    p_gameObject.transform.scale = new Vector2(0.5f, 0.5f);
                    return new EnemyCharacter(p_gameObject,BOSS,3, 21, 50, "Textures/Animations/Enemy/BossEnemy/");
                    break;
            }
            return default;
        }
    }
}
