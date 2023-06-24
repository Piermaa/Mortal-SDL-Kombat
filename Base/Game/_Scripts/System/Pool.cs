using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /*
     Si hay objetos disponibles en m_poolObjects, lo asignaremos a una variable, la removemos de la lista y la agregamos
    la lista de inUseObjects. Finalmente retornamos ese objecto de tipo T. Si no hay objetos en la lista de disponibles, 
    retornará nulo.
     
     
     * */

    //INTERFAZ DE IPOOLEDOBJECT
    //EVENTO AL MORIR, SUSCRIBIR EL EVENTO AL RESETEAR, DESUSCRIBIR AL DESACTUVAR
    //QUE LA INTEFAZ IMPLEMENTE RESET Y ACTION ONDIE
    // EMBELLECER .ENABLED
    public class Pool<T> where T : IMonoBehaviour
    {
        private List<T> m_inUseObjects;
        private List<T> m_poolObjects;

        public Pool()
        {
            m_inUseObjects = new List<T>();
            m_poolObjects = new List<T>();
        }

        public T GetObjectFromPool()
        {
            if (m_poolObjects.Count > 0)
            {
                var l_availableObj = m_poolObjects[0];
                m_poolObjects.Remove(l_availableObj);
                m_inUseObjects.Add(l_availableObj);
                return l_availableObj;
            }

            return default;
        }

        public void AddToPool(T p_obj)
        {
            m_inUseObjects.Remove(p_obj);
            m_poolObjects.Add(p_obj);
        }
    }

    
}
