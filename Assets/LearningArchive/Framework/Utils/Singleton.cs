using System;
using System.Reflection;

namespace LearningArchive.Framework.Utils
{
    public abstract class Singleton<T> where T : Singleton<T>
    {
        private static T mInstance;

        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    // 首先获取所有非 public 的构造方法
                    var ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                    // 从 ctors 中获取无参的构造方法
                    var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                    if (ctor == null)
                        throw new Exception("Non-public ctor() not found!");
                    // 调用构造方法
                    mInstance = ctor.Invoke(null) as T;
                }
                return mInstance;
            }
        }

        protected Singleton()
        {

        }
    }

}
