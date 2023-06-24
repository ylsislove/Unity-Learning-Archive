using LearningArchive.Framework.Utils;
using UnityEngine;

namespace LearningArchive.Example.Utils._007.hide_function_script
{
    public class HideExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/Util/7.Hide 脚本", false, 7)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject().AddComponent<Hide>();
        }
#endif
    }
}
