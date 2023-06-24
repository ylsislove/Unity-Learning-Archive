using System.IO;
using UnityEditor;
using UnityEngine;

namespace LearningArchive.Framework.ResKit.Editor
{
	public class AssetBundleExpoter 
	{
		[MenuItem("LearningArchive/Framework/ResKit/Build AssetBundles", false)]
		static void BuildAssetBundles()
		{
			var outputPath = Application.streamingAssetsPath + "/AssetBundles/" + ResKitUtil.GetPlatformName();

			if (!Directory.Exists(outputPath))
			{
				Directory.CreateDirectory(outputPath);
			}

			BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.ChunkBasedCompression,
				EditorUserBuildSettings.activeBuildTarget);

			AssetDatabase.Refresh();
		}
	}
}