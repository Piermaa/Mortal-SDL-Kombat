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
        private const string NORMAL="0";
        private const string HEAVY="0";
        private const string BOSS="0";

        public static EnemyCharacter CreateEnemy(GameObject p_gameObject,TypeOfEnemy type)
        {
            switch (type)
            {
                case TypeOfEnemy.Normal:

                    //PEJ return new EnemyCharacter(p_gameObject,NORMAL ,0.1f);
                    //siendo normal la key de la animacion
                    return new EnemyCharacter(p_gameObject,NORMAL,0.1f);
                    break;

                case TypeOfEnemy.Heavy:
                    return new EnemyCharacter(p_gameObject,HEAVY,0.2f);
                    break;

                case TypeOfEnemy.Boss:
                    return new EnemyCharacter(p_gameObject,BOSS,1);
                    break;
            }
            return default;
        }
    }
}
