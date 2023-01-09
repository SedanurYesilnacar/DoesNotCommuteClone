using UnityEngine;

namespace _GameData.Scripts
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    var objs = FindObjectsOfType(typeof(T)) as T[];
 
                    if (objs.Length > 0)
                        _instance = objs[0];
 
                    if (objs.Length > 1)
                    {
                        Debug.LogError("[Singleton] There is more than one instance of " + typeof(T).Name + " in the scene.");
                    }
 
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.hideFlags = HideFlags.DontSave;
                        _instance = obj.AddComponent<T>();
                    }
                }
 
                return _instance;
 
            }
        }
 
        public static bool IsInitialized => _instance != null;

        protected virtual void OnDestroy()
        {
            if(_instance == this)
            {
                _instance = null;
            }
        }
        
    }
}