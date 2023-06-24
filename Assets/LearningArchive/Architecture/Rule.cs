using System;
using System.Windows.Input;

namespace LearningArchive.Architecture
{
    public interface IBelongToArchitecture
    {
        IArchitecture GetArchitecture();
    }

    public interface ICanSetArchitecture
    {
        void SetArchitecture(IArchitecture architecture);
    }

    public interface ICanGetModel : IBelongToArchitecture
    {
    }

    public static class CanGetModelExtension
    {
        public static T GetModel<T>(this ICanGetModel self) where T : class, IModel
        {
            return self.GetArchitecture().GetModel<T>();
        }
    }

    public interface ICanGetSystem : IBelongToArchitecture
    {
    }

    public static class CanGetSystemExtension
    {
        public static T GetSystem<T>(this ICanGetSystem self) where T : class, ISystem
        {
            return self.GetArchitecture().GetSystem<T>();
        }
    }

    public interface ICanGetUtility : IBelongToArchitecture
    {
    }

    public static class CanGetUtilityExtension
    {
        public static T GetUtility<T>(this ICanGetUtility self) where T : class, IUtility
        {
            return self.GetArchitecture().GetUtility<T>();
        }
    }

    public interface ICanRegisterEvent : IBelongToArchitecture
    {
    }

    public static class CanRegisterEventExtension
    {
        public static IUnRegister RegisterEvent<T>(this ICanRegisterEvent self, Action<T> onEvent)
        {
            return self.GetArchitecture().RegisterEvent(onEvent);
        }

        public static void UnRegisterEvent<T>(this ICanRegisterEvent self, Action<T> onEvent)
        {
            self.GetArchitecture().UnRegisterEvent(onEvent);
        }
    }

    public interface ICanSendCommand : IBelongToArchitecture
    {
    }

    public static class CanSendCommandExtension
    {
        public static void SendCommand<T>(this ICanSendCommand self) where T : ICommand, new()
        {
            self.GetArchitecture().SendCommand(new T());
        }

        public static void SendCommand<T>(this ICanSendCommand self, T command) where T : ICommand
        {
            self.GetArchitecture().SendCommand(command);
        }

        public static TResult SendCommand<TResult>(this ICanSendCommand self, ICommand<TResult> command)
        {
            return self.GetArchitecture().SendCommand(command);
        }
    }

    public interface ICanSendEvent : IBelongToArchitecture
    {
    }

    public static class CanSendEventExtension
    {
        public static void SendEvent<T>(this ICanSendEvent self) where T : new()
        {
            self.GetArchitecture().SendEvent<T>();
        }

        public static void SendEvent<T>(this ICanSendEvent self, T e)
        {
            self.GetArchitecture().SendEvent(e);
        }
    }

    public interface ICanSendQuery : IBelongToArchitecture
    {
    }

    public static class CanSendQueryExtension
    {
        public static TResult SendQuery<TResult>(this ICanSendQuery self, IQuery<TResult> query)
        {
            return self.GetArchitecture().SendQuery(query);
        }
    }
}