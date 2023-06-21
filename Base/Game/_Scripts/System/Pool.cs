using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IPooledObject
    {
        void Reset(Vector2 resetPosition, float rotation);
        void Disable();
    }

    //where T: new() 
    //permite crear instancias del tipo T
    public class Pool<T> where T: new() 
    {
        private List<T> m_inUseObjects;
        private List<T> m_poolObjects;
        public Pool()
        {
            m_inUseObjects = new List<T>();
            m_poolObjects = new List<T>();
        }

        /// <summary>
        /// Se obtiene on objeto de la la pool de objetos, si no hay, se crea uno
        /// </summary>
        /// <returns>Devuelve el objeto pedido, si no hubo, se creo</returns>
        public T GetObject()
        {
            if (m_poolObjects.Count > 0)
            {
                var l_availableObj = m_poolObjects[0];
                m_poolObjects.Remove(l_availableObj);
                m_inUseObjects.Add(l_availableObj);
                return l_availableObj;
            }
            //===Distinto a lo q mostraron los profes:  ===
            //En la clase si se devolvia null lo creaban y lo metian en la lista cada vez, si es algo que puede pasar con cada
            //pool, entonces parecio mejor que sea parte de la funcion para evitar repetir codigo
            var newAvailableObj=new T();
            m_inUseObjects.Add(newAvailableObj);
            return newAvailableObj;
        }

        /// <summary>
        /// Se agrega un elemento a la lista de objetos pooleados
        /// </summary>
        /// <param name="p_obj">Objeto a instertar en la pool</param>
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
