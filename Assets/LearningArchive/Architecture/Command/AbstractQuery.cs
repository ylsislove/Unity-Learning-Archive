namespace LearningArchive.Architecture
{
    public interface IQuery<out T> : IBelongToArchitecture, ICanSetArchitecture, ICanGetModel, ICanGetSystem,
        ICanSendQuery
    {
        T Do();
    }

    public abstract class AbstractQuery<T> : IQuery<T>
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
        
        T IQuery<T>.Do()
        {
            return OnDo();
        }

        protected abstract T OnDo();
    }
}