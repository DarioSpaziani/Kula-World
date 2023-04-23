using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;

    public virtual void Awake()
    {
        if (!Instance)
        {
            Instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}