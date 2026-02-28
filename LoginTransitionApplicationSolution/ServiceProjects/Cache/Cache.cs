namespace Cache
{
    public class Cache
    {
        static Cache? _cache;
        IApplicationCache _applicationCache = new ApplicationCache();

        public IApplicationCache ApplicationCache
        {
            get
            {
                return _applicationCache;
            }
        }

        public static Cache GetInstance()
        {
            if (_cache == null)
            {
                _cache = new Cache();
            }

            return _cache;
        }
    }
}
