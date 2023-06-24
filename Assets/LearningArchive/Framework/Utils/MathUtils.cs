using UnityEngine;

namespace LearningArchive.Framework.Utils
{
    public partial class MathUtils
    {
        public static bool Percent(int percent)
        {
            return Random.Range(0, 100) < percent;
        }

        public static T GetRandomValueFrom<T>(params T[] values)
        {
            return values[Random.Range(0, values.Length)];
        }
    }
}