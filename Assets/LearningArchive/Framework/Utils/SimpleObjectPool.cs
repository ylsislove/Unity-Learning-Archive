using System;
using System.Collections.Generic;

namespace LearningArchive.Framework.Utils
{
    public interface IPool<T>
    {
        T Allocate();

        bool Recycle(T obj);
    }

    public interface IObjectFactory<T>
    {
        T Create();
    }

    public abstract class Pool<T> : IPool<T>
    {
        protected Stack<T> mCachedStack = new Stack<T>();

        protected IObjectFactory<T> mFactory;

        public int CurCount
        {
            get { return mCachedStack.Count; }
        }

        /// <summary>
        /// default is 5
        /// </summary>
        protected int mMaxCount = 5;

        public virtual T Allocate()
        {
            return mCachedStack.Count > 0 ? mCachedStack.Pop() : mFactory.Create();
        }

        public abstract bool Recycle(T obj);
    }

    public class CustomObjectFactory<T> : IObjectFactory<T>
    {
        private Func<T> mFactoryMethod;

        public CustomObjectFactory(Func<T> factoryMethod)
        {
            mFactoryMethod = factoryMethod;
        }

        public T Create()
        {
            return mFactoryMethod();
        }
    }


    /// <summary>
    /// unsafe but fast
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SimpleObjectPool<T> : Pool<T>
    {
        readonly Action<T> mResetMethod;

        public SimpleObjectPool(Func<T> factoryMethod, Action<T> resetMethod = null, int initCount = 0)
        {
            mFactory = new CustomObjectFactory<T>(factoryMethod);
            mResetMethod = resetMethod;

            for (var i = 0; i < initCount; i++)
            {
                mCachedStack.Push(mFactory.Create());
            }
        }

        public override bool Recycle(T obj)
        {
            if (mResetMethod != null)
            {
                mResetMethod(obj);
            }

            mCachedStack.Push(obj);

            return true;
        }
    }

}
