namespace DesignPatterns.Singleton
{
    public abstract class ThreadSafeSingleton<T> where T : new()
    {
        private static readonly object padlock = new();

        private static T? instance;

        public static T Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                    return instance;
                }
            }
        }
    }
}
