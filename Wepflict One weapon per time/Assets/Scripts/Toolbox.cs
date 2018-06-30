using UnityEngine;

public class Toolbox : Singleton<Toolbox> {
    protected Toolbox() {}

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static T RegisterComponent<T>() where T : Component
    {
        return Instance.GetOrAddComponent<T>();
    }
}
