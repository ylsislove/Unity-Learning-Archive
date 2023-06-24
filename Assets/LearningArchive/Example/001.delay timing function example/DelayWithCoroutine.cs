using UnityEngine;

namespace LearningArchive.Example._001.delay_timing_function_example
{
    public class DelayWithCoroutine : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/1.定时功能", false, 1)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject().AddComponent<DelayWithCoroutine>();
        }
#endif

        void Start()
        {
            Delay(5.0f, () =>
            {
                Debug.Log(" 5s 之后");
                this.Hide();
            });
        }

        protected override void OnBeforeDestroy()
        {
        }
    }
}