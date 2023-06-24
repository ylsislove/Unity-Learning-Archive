using UnityEngine;

namespace LearningArchive.Framework.Utils
{
    public partial class CommonUtils
    {
        public static void CopyText(string text)
        {
            GUIUtility.systemCopyBuffer = text;
        }
    }
}