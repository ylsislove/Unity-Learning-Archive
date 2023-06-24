using System.Collections.Generic;

namespace LearningArchive.Framework.ResKit.Data
{
	public class AssetBundleData
	{
		public string Name;
		
		public List<AssetData> AssetDataList = new List<AssetData>();

		public string[] DependencyBundleNames;
	}
}