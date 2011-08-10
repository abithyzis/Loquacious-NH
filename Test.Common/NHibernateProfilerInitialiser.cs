using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace Test.Common
{
    public static class NHibernateProfilerInitialiser
    {
        private static bool _isInitialised;

        public static void Initialise()
        {
            if (!_isInitialised)
            {
                NHibernateProfiler.Initialize();
                _isInitialised = true;
            }
        }
    }
}