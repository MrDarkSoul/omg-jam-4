using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

    private static T instance;
    private static object objLock = new object();

    public static T Instance
    {
        get
        {
            if (quitting)
            {
                Debug.LogFormat("Instância única do tipo {0} chamada enquanto a aplicação está sendo fechada. Retornando null.", typeof(T).ToString());
                return null;
            }

            lock (objLock)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();

                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        Debug.LogWarningFormat("Mais de uma instância de {0} encontrada: isto não é permitido. Recarregar a cena pode arrumar isto.", typeof(T).ToString());
                        return instance;
                    }

                    if (instance == null)
                    {
                        GameObject singleton = (GameObject)Instantiate(null);
                        instance = singleton.AddComponent<T>();
                        singleton.name = "(Singleton) - " + typeof(T).ToString();

                        DontDestroyOnLoad(singleton);

                        Debug.LogWarningFormat("Nenhuma instância de {0} encontrada. " +
                            "Foi criada um GameObject com este componente e setado com DontDestroyOnLoad.", typeof(T).ToString());
                    }
                }

                return instance;
            }
        }
    }

    private static bool quitting = false;

    private void OnDestroy()
    {
        quitting = true;
    }
}
