using System;
using System.IO;
using LearningArchive.Framework.Utils;
using UnityEngine;
using UnityEditor;

namespace LearningArchive.Example
{
    public class Exporter
    {
        private static string GeneratePackageName()
        {
            return "LearningArchive_" + DateTime.Now.ToString("yyyyMMdd_HH");
        }

        [MenuItem("LearningArchive/Framework/Editor/导出 UnityPackage %e", false, 1)]
        private static void MenuClicked()
        {
            EditorUtils.ExportPackage("Assets/LearningArchive", GeneratePackageName() + ".unitypackage");
            EditorUtils.OpenInFolder(Path.Combine(Application.dataPath, "../"));
        }
    }
}
