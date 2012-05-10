using Microsoft.Office.Interop.Outlook;

namespace Softwarekueche.Categorizer.Persister
{
    public class OutlookPstConfigPersister : IConfigPersister
    {
        private const string ConfigDataString = "Config";
        private StorageItem _storage;

        public OutlookPstConfigPersister(StorageItem storage)
        {
            _storage = storage;
        }

        #region Implementation of IConfigPersister

        /// <summary>
        /// get a list of topics
        /// </summary>
        public Config GetConfig()
        {
            return new Config("[", "]");
        }

        /// <summary>
        /// set a list of topics. this list replaces the existing list
        /// </summary>
        public void SetConfig(Config config)
        {
            // todo implement
        }

        #endregion
    }
}