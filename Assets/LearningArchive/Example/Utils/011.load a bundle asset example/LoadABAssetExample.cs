using LearningArchive.Framework.ResKit;
using UnityEngine;

namespace LearningArchive.Example.Utils._011.load_a_bundle_asset_example
{
	public class LoadABAssetExample : MonoBehaviour
	{

#if UNITY_EDITOR
		[UnityEditor.MenuItem("LearningArchive/Example/Util/11.LoadABAssetExample", false, 11)]
		static void MenuClicked()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject("LoadABAssetExample")
				.AddComponent<LoadABAssetExample>();
		}
#endif

		private ResLoader mResLoader = new ResLoader();
		
		// Use this for initialization
		void Start()
		{
			var squareTexture = mResLoader.LoadSync<Texture2D>("square", "Square");
			Debug.Log(squareTexture.name);
			
//			mResLoader.LoadAsync<GameObject>("gameobject","GameObject",
//				gameObjPrefab => { Instantiate(gameObjPrefab); });
		}

		private void OnDestroy()
		{
			mResLoader.ReleaseAll();
			mResLoader = null;
		}
	}
}