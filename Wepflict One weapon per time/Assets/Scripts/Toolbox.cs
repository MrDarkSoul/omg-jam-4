using UnityEngine;

public class Toolbox : Singleton<Toolbox> {
    protected Toolbox() {}

    public Weapon DefaultWeapon;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        RegisterComponent<AttackHandler>();
    }

    public static T RegisterComponent<T>() where T : Component
    {
        return Instance.GetOrAddComponent<T>();
    }
}
