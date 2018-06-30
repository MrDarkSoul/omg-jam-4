using UnityEngine;

public static class MonoBehaviourExtended {

	public static T GetOrAddComponent<T>(this Component child) where T : Component
    {
        T component = child.GetComponent<T>();

        if (component == null)
        {
            component = child.gameObject.AddComponent<T>();
        }

        return component;
    }
}
