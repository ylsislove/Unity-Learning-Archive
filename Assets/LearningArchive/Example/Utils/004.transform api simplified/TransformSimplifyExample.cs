using UnityEngine;

namespace LearningArchive.Example.Utils._004.transform_api_simplified
{
    public class TransformSimplifyExample
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/Util/4.Transform API 简化", false, 4)]
#endif
        private static void MenuClicked()
        {
            GameObject gameObject = new GameObject();

            gameObject.transform.SetLocalPosX(5.0f);
            gameObject.transform.SetLocalPosY(5.0f);
            gameObject.transform.SetLocalPosZ(5.0f);

            gameObject.transform.Identity();

            var parentTrans = new GameObject("ParentTransform").transform;
            var childTrans = new GameObject("ChildTransform").transform;

            parentTrans.AddChild(childTrans);
        }
    }
}
