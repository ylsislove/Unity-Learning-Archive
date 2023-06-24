using System;
using System.Collections.Generic;
using LearningArchive.Framework.ResKit.Res;
using Object = UnityEngine.Object;

namespace LearningArchive.Framework.ResKit
{
	public class ResLoader
	{
		#region API		
		public T LoadSync<T>(string assetBundleName, string assetName) where T : Object
		{
			return DoLoadSync<T>(assetName, assetBundleName);
		}
		
		public T LoadSync<T>(string assetName) where T : Object
		{
			return DoLoadSync<T>(assetName);

		}

		public void LoadAsync<T>(string assetName, Action<T> onLoaded) where T : Object
		{
			DoLoadAsync(assetName, null, onLoaded);
		}

		public void LoadAsync<T>(string assetBundleName, string assetName, Action<T> onLoaded) where T : Object
		{
			DoLoadAsync(assetName, assetBundleName, onLoaded);
		}
		
		public void ReleaseAll()
		{
			mResRecord.ForEach(loadedAsset => loadedAsset.Release());

			mResRecord.Clear();
		}

		
		#endregion

		
		#region Private		
		private T DoLoadSync<T>(string assetName, string assetBundleName = null) where T : Object
		{
			var res = GetOrCreateRes(assetName);

			if (res != null)
			{
				switch (res.State)
				{
					case ResState.Loading:
						throw new Exception(string.Format("请不要在异步加载资源 {0} 时，进行 {0} 的同步加载", res.Name));
					case ResState.Loaded:
						return res.Asset as T;
				}
			}

			// 真正加载资源
			res = CreateRes(assetName,assetBundleName);

			res.LoadSync();

			return res.Asset as T;
		}

		private void DoLoadAsync<T>(string assetName, string ownerBundleName, Action<T> onLoaded) where T : Object
		{
			// 查询当前的 资源记录
			var res = GetOrCreateRes(assetName);

			Action<Res.Res> onResLoaded = null;

			onResLoaded = loadedRes =>
			{
				onLoaded(loadedRes.Asset as T);

				res.UnRegisterOnLoadedEvent(onResLoaded);
			};

			if (res != null)
			{
				if (res.State == ResState.Loading)
				{
					res.RegisterOnLoadedEvent(onResLoaded);
				}
				else if (res.State == ResState.Loaded)
				{
					onLoaded(res.Asset as T);
				}

				return;
			}

			// 真正加载资源
			res = CreateRes(assetName, ownerBundleName);

			res.RegisterOnLoadedEvent(onResLoaded);

			res.LoadAsync();
		}


		private List<Res.Res> mResRecord = new List<Res.Res>();

		private Res.Res GetOrCreateRes(string assetName)
		{
			// 查询当前的 资源记录
			var res = GetResFromRecord(assetName);

			if (res != null)
			{
				return res;
			}

			// 查询全局资源池
			res = GetFromResMgr(assetName);

			if (res != null)
			{
				AddRes2Record(res);

				return res;
			}

			return res;
		}

		private Res.Res CreateRes(string assetName, string ownerBundle = null)
		{
			var res = ResFactory.Create(assetName, ownerBundle);

			ResMgr.Instance.SharedLoadedReses.Add(res);

			AddRes2Record(res);

			return res;
		}

		private Res.Res GetResFromRecord(string assetName)
		{
			return mResRecord.Find(loadedAsset => loadedAsset.Name == assetName);
		}

		private Res.Res GetFromResMgr(string assetName)
		{
			return ResMgr.Instance.SharedLoadedReses.Find(loadedAsset => loadedAsset.Name == assetName);
		}

		private void AddRes2Record(Res.Res resFromResMgr)
		{
			mResRecord.Add(resFromResMgr);
				
			resFromResMgr.Retain();
		}
		
		#endregion
	}
}