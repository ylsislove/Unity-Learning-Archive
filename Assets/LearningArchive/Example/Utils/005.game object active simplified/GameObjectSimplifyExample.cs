using UnityEngine;

namespace LearningArchive.Example.Utils._005.game_object_active_simplified
{
    public class GameObjectSimplifyExample
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/Util/5.GameObject Active 简化", false, 5)]
#endif
        private static void MenuClicked()
        {
            GameObject gameObject = new GameObject();

            gameObject.Hide();
            gameObject.transform.Hide();
        }
    }
}
