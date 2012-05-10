namespace Softwarekueche.Categorizer.Persister
{
    /// <summary>
    /// interface to manage the topics
    /// </summary>
    interface IConfigPersister
    {
        /// <summary>
        /// get a list of topics
        /// </summary>
        Config GetConfig();

        /// <summary>
        /// set a list of topics. this list replaces the existing list
        /// </summary>
        void SetConfig(Config config);
    }
}
