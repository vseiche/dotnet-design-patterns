using System;

namespace DesignPatterns.Singleton
{
    public abstract class LazySingleton<T> where T : new()
    {
        private static readonly Lazy<T> lazyInstance = new Lazy<T>(() => new T());

        public static T Instance
        {
            get
            {
                return lazyInstance.Value;
            }
        }
    }
}
