using LearningArchive.Framework.Utils;
using UnityEngine;

namespace LearningArchive.Example.Utils._009.mono_singleton_example
{
    public class MonoSingletonExample : MonoSingleton<MonoSingletonExample>
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/Util/9.MonoSingletonExample", false, 9)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
        }
#endif

        [RuntimeInitializeOnLoadMethod]
        static void Example()
        {
            var initInstance = MonoSingletonExample.Instance;
            initInstance = MonoSingletonExample.Instance;
        }
    }
}
