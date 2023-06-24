using UnityEngine;

namespace LearningArchive.Framework.ResKit.Res
{
    public class ResourcesRes : Res
    {
        private string mAssetPath;

        public ResourcesRes(string assetPath)
        {
            mAssetPath = assetPath.Substring("resources://".Length);

            Name = assetPath;

            State = ResState.Waiting;
        }

        public override bool LoadSync()
        {
            State = ResState.Loading;

            Asset = Resources.Load(mAssetPath);

            State = ResState.Loaded;
            
            return Asset;
        }

        public override void LoadAsync()
        {
            State = ResState.Loading;
            
            var resRequest = Resources.LoadAsync(mAssetPath);

            resRequest.completed += operation =>
            {
                Asset = resRequest.asset;

                State = ResState.Loaded;                
            };
        }

        protected override void OnReleaseRes()
        {
            if (Asset is GameObject)
            {
                Asset = null;
                
                Resources.UnloadUnusedAssets();
            }
            else
            {
                Resources.UnloadAsset(Asset);
            }

            ResMgr.Instance.SharedLoadedReses.Remove(this);
                
            Asset = null; 
        }
    }
}