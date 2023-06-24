using UnityEngine;

namespace LearningArchive
{
    public enum EnvironmentMode
    {
        Devloping,
        Test,
        Production
    }

    public abstract class MainManager : MonoBehaviour
    {
        public EnvironmentMode mode;

        private static EnvironmentMode mSharedMode;
        private static bool mModeSetted = false;

        private void Start()
        {
            if (!mModeSetted)
            {
                mSharedMode = mode;
                mModeSetted = true;
            }

            switch (mSharedMode)
            {
                case EnvironmentMode.Devloping:
                    LaunchInDevelopingMode();
                    break;
                case EnvironmentMode.Test:
                    LaunchInTestMode();
                    break;
                case EnvironmentMode.Production:
                    LaunchInProductionMode();
                    break;
            }
        }

        protected abstract void LaunchInDevelopingMode();
        protected abstract void LaunchInTestMode();
        protected abstract void LaunchInProductionMode();
    }
}
