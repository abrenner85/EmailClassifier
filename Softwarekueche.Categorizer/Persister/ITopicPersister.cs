﻿using System.Collections.Generic;

namespace Softwarekueche.Categorizer.Persister
{
    /// <summary>
    /// interface to manage the topics
    /// </summary>
    interface ITopicPersister
    {
        /// <summary>
        /// get a list of topics
        /// </summary>
        IEnumerable<Topic> GetTopics();

        /// <summary>
        /// set a list of topics. this list replaces the existing list
        /// </summary>
        void SetTopics(IEnumerable<Topic> topics);

        /// <summary>
        /// add the topic to the store
        /// </summary>
        void AddTopic(Topic topic);
    }
}
