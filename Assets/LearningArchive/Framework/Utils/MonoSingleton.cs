using UnityEngine;

namespace LearningArchive.Framework.Utils
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        protected static T mInstance = null;

        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = FindObjectOfType<T>();

                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        Debug.LogWarning("More than 1");
                        return mInstance;
                    }

                    if (mInstance == null)
                    {
                        var instanceName = typeof(T).Name;
                        Debug.Log($"Instance Name: {instanceName}");
                        var instanceObj = GameObject.Find(instanceName);

                        if (!instanceObj)
                            instanceObj = new GameObject(instanceName);

                        mInstance = instanceObj.AddComponent<T>();
                        DontDestroyOnLoad(instanceObj);

                        Debug.Log($"Add New Singleton {instanceName} in Game!");
                    }
                    else
                    {
                        Debug.Log($"Already exist: {mInstance.name}");
                    }
                }
                return mInstance;
            }
        }

        protected virtual void OnDestroy()
        {
            mInstance = null;
        }
    }
}
