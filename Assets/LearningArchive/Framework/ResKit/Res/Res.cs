using System;
using LearningArchive.Framework.Utils;
using Object = UnityEngine.Object;

namespace LearningArchive.Framework.ResKit.Res
{
    public enum ResState
    {
        Waiting,
        Loading,
        Loaded,
    }
    
    public abstract class Res : SimpleRC
    {
        public ResState State
        {
            get { return mState;}
            protected set
            {
                mState = value;

                if (mState == ResState.Loaded)
                {
                    if (mOnLoadedEvent != null)
                    {
                        mOnLoadedEvent.Invoke(this);
                    }
                }
            } 
        }

        private ResState mState;
        
        public Object Asset { get; protected set; }

        public string Name { get; protected set; }

        private string mAssetPath;

        public abstract bool LoadSync();

        public abstract void LoadAsync();

        protected abstract void OnReleaseRes();

        protected override void OnZeroRef()
        {
            OnReleaseRes();
        }


        private event Action<Res> mOnLoadedEvent;

        public void RegisterOnLoadedEvent(Action<Res> onLoaded)
        {
            mOnLoadedEvent += onLoaded;
        }

        public void UnRegisterOnLoadedEvent(Action<Res> onLoaded)
        {
            mOnLoadedEvent -= onLoaded;
        }
    }
}