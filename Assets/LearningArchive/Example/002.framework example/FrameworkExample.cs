using System.Collections;
using LearningArchive.Framework.Utils;
using UnityEngine;

namespace LearningArchive.Example._002.framework_example
{
    public class FrameworkExample : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("LearningArchive/Example/2.框架示例", false, 2)]
        private static void MenuClicked()
        {
            MsgDispatcher.UnRegisterAll("Do");
            MsgDispatcher.UnRegisterAll("OK");

            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject("MsgReceiverObj").AddComponent<FrameworkExample>();
        }
#endif

        private void Awake()
        {
            RegisterMsg("Do", DoSomething);
            RegisterMsg("Do", DoSomething);

            RegisterMsg("OK", data =>
            {
                Debug.Log(data);
                UnRegisterMsg("OK");
            });
        }

        private IEnumerator Start()
        {
            MsgDispatcher.Send("Do", "hello");

            yield return new WaitForSeconds(1.0f);

            MsgDispatcher.Send("Do", "hello1");

            SendMsg("OK", "hello");
            SendMsg("OK", "hello");
        }

        private void DoSomething(object data)
        {
            // do something
            Debug.LogFormat("Received Do msg:{0}", data);
        }

        protected override void OnBeforeDestroy()
        {
        }
    }
}