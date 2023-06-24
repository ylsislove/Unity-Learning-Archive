using LearningArchive.Framework.Utils;
using UnityEngine;

namespace LearningArchive.Example._008.singleton_example
{
    public class SingletonExample : Singleton<SingletonExample>
    {
        private SingletonExample()
        {
            Debug.Log("singleton example ctor");
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/8.SingletonExample", false, 8)]
        static void MenuClicked()
        {
            var initInstance = SingletonExample.Instance;
            initInstance = SingletonExample.Instance;
        }
#endif
    }
}
