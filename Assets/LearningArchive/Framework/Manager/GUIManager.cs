using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LearningArchive
{
    public enum UILayer
    {
        Bg,
        Common,
        Top
    }

    public class GUIManager : MonoBehaviour
    {
        private static GameObject mPrivateUIRoot;
        
        public static GameObject UIRoot
        {
            get
            {
                if (mPrivateUIRoot == null)
                {
                    mPrivateUIRoot = Instantiate(Resources.Load<GameObject>("UIRoot"));
                    mPrivateUIRoot.name = "UIRoot";
                }
                return mPrivateUIRoot;
            }
        }

        private static Dictionary<string, GameObject> mPanelDict = new Dictionary<string, GameObject>();

        public static void SetResolution(float width, float height, float matchWidthOrHeight)
        {
            var canvasScaler = UIRoot.GetComponent<CanvasScaler>();
            canvasScaler.referenceResolution = new Vector2(width, height);
            canvasScaler.matchWidthOrHeight = matchWidthOrHeight;
        }

        public static void UnLoadPanel(string panelName)
        {
            if (mPanelDict.ContainsKey(panelName))
            {
                Destroy(mPanelDict[panelName]);
            }
        }
        
        public static GameObject LoadPanel(string panelName, UILayer uiLayer)
        {
            var panelPrefab = Resources.Load<GameObject>(panelName);
            var panelObj = Instantiate(panelPrefab);
            panelObj.name = panelName;

            mPanelDict.Add(panelName, panelObj);

            switch(uiLayer)
            {
                case UILayer.Bg:
                    panelObj.transform.SetParent(UIRoot.transform.Find("Bg"));
                    break;
                case UILayer.Common:
                    panelObj.transform.SetParent(UIRoot.transform.Find("Common"));
                    break;
                case UILayer.Top:
                    panelObj.transform.SetParent(UIRoot.transform.Find("Top"));
                    break;
            }

            var panelRectTrans = panelObj.transform as RectTransform;

            panelRectTrans.offsetMin = Vector2.zero;
            panelRectTrans.offsetMax = Vector2.zero;
            panelRectTrans.anchoredPosition3D = Vector3.zero;
            panelRectTrans.anchorMin = Vector2.zero;
            panelRectTrans.anchorMax = Vector2.zero;

            panelRectTrans.localScale = Vector3.one;

            return panelObj;
        }
    }
}
