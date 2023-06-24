using System.Collections;
using LearningArchive.Framework.ResKit;
using UnityEngine;

namespace LearningArchive.Example._010.res_mgr_example
{
	public class ResMgrExample : MonoBehaviour
	{

#if UNITY_EDITOR
		[UnityEditor.MenuItem("LearningArchive/Example/10.ResMgrExample", false, 10)]
		static void MenuItem()
		{
			UnityEditor.EditorApplication.isPlaying = true;

			new GameObject("ResMgrExample")
				.AddComponent<ResMgrExample>();
		}
#endif

		ResLoader mResLoader = new ResLoader();


		private IEnumerator Start()
		{
			yield return new WaitForSeconds(2.0f);

			mResLoader.LoadAsync<AudioClip>("resources://coin", coinClip =>
			{
				Debug.Log(coinClip.name);
				
				Debug.Log(Time.time);
			});
			
			Debug.Log(Time.time);

			yield return new WaitForSeconds(2.0f);

			mResLoader.LoadSync<AudioClip>("resources://home");

			yield return new WaitForSeconds(2.0f);

			mResLoader.LoadSync<GameObject>("resources://HomePanel");
			
			mResLoader.LoadSync<AudioClip>("resources://Audio/coin");

			yield return new WaitForSeconds(5.0f);

			mResLoader.ReleaseAll();
		}
	}
}