using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //TODO: EVENTO ON DISABLE, EVENTO ON DESTROY ON ENABLE, ETC ETC
    public interface IPooledObject
    {
        void Reset(Vector2 resetPosition, float rotation);
        void Disable();
    }
    /*
     Si hay objetos disponibles en m_poolObjects, lo asignaremos a una variable, la removemos de la lista y la agregamos
    la lista de inUseObjects. Finalmente retornamos ese objecto de tipo T. Si no hay objetos en la lista de disponibles, 
    retornará nulo.
     
     
     * */

    //INTERFAZ DE IPOOLEDOBJECT
    //EVENTO AL MORIR, SUSCRIBIR EL EVENTO AL RESETEAR, DESUSCRIBIR AL DESACTUVAR
    //QUE LA INTEFAZ IMPLEMENTE RESET Y ACTION ONDIE
    // EMBELLECER .ENABLED
    public class Pool<T> where T: new()
    {
        private List<T> m_inUseObjects;
        private List<T> m_poolObjects;
        //private Queue<T> m_poolObjects;
        public Pool()
        {
            m_inUseObjects = new List<T>();
            m_poolObjects = new List<T>();
            //_poolObjects = new Queue<T>();
        }
        public Pool(int size)
        {
            m_inUseObjects = new List<T>();
            m_poolObjects = new List<T>();

            //m_poolObjects = new List<T>(size);
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
            var newAvailableObj=new T();
            m_inUseObjects.Add(newAvailableObj);
            return newAvailableObj;
        }

        public void AddToPool(object p_obj)
        {
         
            T objectPooled;
            try
            {
                objectPooled = (T)p_obj;
            }
            catch (Exception)
            {
                Engine.Debug($"{p_obj} could not be converted to {typeof(T)}");
                throw;
            }
            m_inUseObjects.Remove(objectPooled);
     
             m_poolObjects.Add(objectPooled);
            
        }
    }
}
