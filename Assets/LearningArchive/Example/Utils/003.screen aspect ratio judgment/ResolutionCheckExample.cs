using LearningArchive.Framework.Utils;
using UnityEngine;

namespace LearningArchive.Example.Utils._003.screen_aspect_ratio_judgment
{
    public class ResolutionCheckExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/Util/3.屏幕宽高比判断", false, 3)]
#endif
        private static void MenuClicked()
        {
            Debug.Log(ResolutionCheck.IsPadResolution() ? "是 Pad" : "不是 Pad");
            Debug.Log(ResolutionCheck.IsPhoneResolution() ? "是 Phone" : "不是 Phone");
            Debug.Log(ResolutionCheck.IsPhone15Resolution() ? "是 4s" : "不是 4s");
            Debug.Log(ResolutionCheck.IsiPhoneXResolution() ? "是 iphonex" : "不是 iphonex");
        }
    }
}
