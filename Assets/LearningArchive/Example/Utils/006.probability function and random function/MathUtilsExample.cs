using LearningArchive.Framework.Utils;
using UnityEngine;

namespace LearningArchive.Example.Utils._006.probability_function_and_random_function
{
    public class MathUtilsExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/Util/6.概率函数和随机函数", false, 6)]
#endif
        private static void MenuClicked()
        {
            Debug.Log(MathUtils.Percent(50));

            var randomAge = MathUtils.GetRandomValueFrom(new int[] { 1, 2, 3 });
            Debug.Log(randomAge);

            var randomAge2 = MathUtils.GetRandomValueFrom("asdasd", "123123");
            Debug.Log(randomAge2);
        }
    }
}
