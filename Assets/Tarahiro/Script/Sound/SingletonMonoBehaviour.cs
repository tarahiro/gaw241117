using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    protected SingletonMonoBehaviour() { }
    private static T mInstance;
    public static T Instance
    {
        get
        {
            mInstance = mInstance ?? FindObjectOfType<T>();
            return mInstance ?? (mInstance = (new GameObject(typeof(T).ToString())).AddComponent<T>());
        }
    }
    virtual protected void Awake() => DontDestroyOnLoad(this);
    virtual protected void OnDestroy() => mInstance = null;
}