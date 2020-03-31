using UnityEngine;

namespace devy
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T s = null;

        public static T Instance
        {
            get
            {
                if (s == null)
                {
                    s = FindObjectOfType(typeof(T)) as T;
                }

                if (s == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    s = obj.AddComponent(typeof(T)) as T;
                }
                return s;
            }
        }
    }
}

