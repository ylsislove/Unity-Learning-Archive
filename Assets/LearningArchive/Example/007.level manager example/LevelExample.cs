using System.Collections.Generic;
using UnityEngine;

namespace LearningArchive.Example._007.level_manager_example
{
    public class LevelExample : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/7.LevelManager", false, 7)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject("LevelExample").AddComponent<LevelExample>();
        }
#endif

        void Start()
        {
            DontDestroyOnLoad(this);

            LevelManager.Init(new List<string>
            {
                "Home",
                "Level",
            });

            LevelManager.LoadCurrent();


            Delay(5.0f, LevelManager.LoadNext);
        }

        protected override void OnBeforeDestroy()
        {
        }
    }
}