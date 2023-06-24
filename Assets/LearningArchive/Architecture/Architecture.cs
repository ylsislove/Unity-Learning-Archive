using System;
using System.Collections.Generic;

namespace LearningArchive.Architecture
{
    #region Architecture
    
    public interface IArchitecture
    {
        void RegisterSystem<T>(T system) where T : ISystem;
    
        void RegisterModel<T>(T model) where T : IModel;
    
        void RegisterUtility<T>(T utility) where T : IUtility;
    
        T GetSystem<T>() where T : class, ISystem;
    
        T GetModel<T>() where T : class, IModel;
    
        T GetUtility<T>() where T : class, IUtility;
    
        void SendCommand<T>(T command) where T : ICommand;
    
        TResult SendCommand<TResult>(ICommand<TResult> command);
    
        TResult SendQuery<TResult>(IQuery<TResult> query);
    
        void SendEvent<T>() where T : new();
        void SendEvent<T>(T e);
    
        IUnRegister RegisterEvent<T>(Action<T> onEvent);
        void UnRegisterEvent<T>(Action<T> onEvent);
    }
    
    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        private bool mInited;

        private readonly HashSet<ISystem> mSystems = new HashSet<ISystem>();

        private readonly HashSet<IModel> mModels = new HashSet<IModel>();

        public static Action<T> OnRegisterPatch = architecture => { };

        private static T mArchitecture;

        public static IArchitecture Interface
        {
            get
            {
                if (mArchitecture == null)
                {
                    MakeSureArchitecture();
                }
                return mArchitecture;
            }
        }
        
        private static void MakeSureArchitecture()
        {
            if (mArchitecture != null) return;
            
            mArchitecture = new T();
            mArchitecture.Init();

            OnRegisterPatch?.Invoke(mArchitecture);

            foreach (var architectureModel in mArchitecture.mModels)
            {
                architectureModel.Init();
            }
            mArchitecture.mModels.Clear();

            foreach (var architectureSystem in mArchitecture.mSystems)
            {
                architectureSystem.Init();
            }
            mArchitecture.mSystems.Clear();

            mArchitecture.mInited = true;
        }

        protected abstract void Init();

        private readonly IocContainer mContainer = new IocContainer();

        public void RegisterSystem<TSystem>(TSystem system) where TSystem : ISystem
        {
            system.SetArchitecture(this);
            mContainer.Register(system);

            // 如果 mArchitecture 还未初始化，就先缓存起来，等到初始化的时候在 MakeSureArchitecture 中统一初始化
            if (!mInited)
            {
                mSystems.Add(system);
            }
            // 如果 mArchitecture 已经初始化了，就直接初始化这个 system
            else
            {
                system.Init();
            }
        }

        public void RegisterModel<TModel>(TModel model) where TModel : IModel
        {
            model.SetArchitecture(this);
            mContainer.Register(model);

            // 如果 mArchitecture 还未初始化，就先缓存起来，等到初始化的时候在 MakeSureArchitecture 中统一初始化
            if (!mInited)
            {
                mModels.Add(model);
            }
            // 如果 mArchitecture 已经初始化了，就直接初始化这个 model
            else
            {
                model.Init();
            }
        }

        public void RegisterUtility<TUtility>(TUtility utility) where TUtility : IUtility
        {
            mContainer.Register(utility);
        }

        public TSystem GetSystem<TSystem>() where TSystem : class, ISystem
        {
            return mContainer.Get<TSystem>();
        }

        public TModel GetModel<TModel>() where TModel : class, IModel
        {
            return mContainer.Get<TModel>();
        }

        public TUtility GetUtility<TUtility>() where TUtility : class, IUtility
        {
            return mContainer.Get<TUtility>();
        }

        public TResult SendCommand<TResult>(ICommand<TResult> command)
        {
            return ExecuteCommand(command);
        }

        public void SendCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            ExecuteCommand(command);
        }

        protected virtual TResult ExecuteCommand<TResult>(ICommand<TResult> command)
        {
            command.SetArchitecture(this);
            return command.Execute();
        }

        protected virtual void ExecuteCommand(ICommand command)
        {
            command.SetArchitecture(this);
            command.Execute();
        }

        public TResult SendQuery<TResult>(IQuery<TResult> query)
        {
            return DoQuery(query);
        }

        protected virtual TResult DoQuery<TResult>(IQuery<TResult> query)
        {
            query.SetArchitecture(this);
            return query.Do();
        }

        private readonly TypeEventSystem mTypeEventSystem = new();

        public void SendEvent<TEvent>() where TEvent : new()
        {
            mTypeEventSystem.Send<TEvent>();
        }

        public void SendEvent<TEvent>(TEvent e)
        {
            mTypeEventSystem.Send(e);
        }

        public IUnRegister RegisterEvent<TEvent>(Action<TEvent> onEvent)
        {
            return mTypeEventSystem.Register(onEvent);
        }

        public void UnRegisterEvent<TEvent>(Action<TEvent> onEvent)
        {
            mTypeEventSystem.UnRegister(onEvent);
        }
    }

    public interface IOnEvent<in T>
    {
        void OnEvent(T e);
    }

    public static class OnGlobalEventExtension
    {
        public static IUnRegister RegisterEvent<T>(this IOnEvent<T> self) where T : struct
        {
            return TypeEventSystem.Global.Register<T>(self.OnEvent);
        }

        public static void UnRegisterEvent<T>(this IOnEvent<T> self) where T : struct
        {
            TypeEventSystem.Global.UnRegister<T>(self.OnEvent);
        }
    }
    
    #endregion
    
    #region Controller

    public interface IController : IBelongToArchitecture, ICanGetSystem, ICanGetModel, ICanGetUtility,
        ICanRegisterEvent, ICanSendCommand, ICanSendQuery
    {
    }

    #endregion
    
    #region System

    public interface ISystem : IBelongToArchitecture, ICanSetArchitecture, ICanGetSystem, ICanGetModel, ICanGetUtility,
        ICanRegisterEvent, ICanSendEvent
    {
        void Init();
    }

    public abstract class AbstractSystem : ISystem
    {
        private IArchitecture mArchitecture;

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return mArchitecture;
        }

        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }

        void ISystem.Init()
        {
            OnInit();
        }

        protected abstract void OnInit();
    }

    #endregion
    
    #region Model

    public interface IModel : IBelongToArchitecture, ICanSetArchitecture, ICanGetUtility, ICanSendEvent
    {
        void Init();
    }

    public abstract class AbstractModel : IModel
    {
        private IArchitecture mArchitecture;

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return mArchitecture;
        }

        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }

        void IModel.Init()
        {
            OnInit();
        }

        protected abstract void OnInit();
    }

    #endregion
    
    #region Utility

    public interface IUtility
    {
    }

    #endregion
}
