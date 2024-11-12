using UnityEngine;

public class SingletoneBase<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance
    {
        get
        {
            
            if (instance == null)
            {
                
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    string tName = typeof(T).ToString();
                    var singletoneObj = new GameObject(tName);
                    instance = singletoneObj.AddComponent<T>();

                    DontDestroyOnLoad(instance);
                }
            }
            return instance;
        }
    }

    public void Init()
    {
    }

    public void Release()
    {
        Destroy(instance);
    }
}