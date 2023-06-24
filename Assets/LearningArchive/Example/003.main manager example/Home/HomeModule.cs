using LearningArchive.Example._003.main_manager_example.Game;
using UnityEngine;

namespace LearningArchive.Example._003.main_manager_example.Home
{
    public class HomeModule : MainManager
    {
        protected override void LaunchInDevelopingMode()
        {
            Debug.Log("developing mode");
        }

        protected override void LaunchInProductionMode()
        {
            // 生产逻辑
            // 加载资源
            // 初始化 SDK
            // 点击开始游戏
            GameModule.LoadModule();
        }

        protected override void LaunchInTestMode()
        {
            // 测试逻辑
            // 加载资源
            // 初始化 SDK
            // 点击开始游戏
            GameModule.LoadModule();
        }
    }
}