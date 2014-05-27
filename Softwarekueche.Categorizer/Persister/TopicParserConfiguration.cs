namespace Softwarekueche.Categorizer.Persister
{
    public class TopicParserConfiguration
    {
        public string TopicStart { get; set; }
        public string TopicEnd { get; set; }

        public TopicParserConfiguration() {}

        public TopicParserConfiguration(string topicStart, string topicEnd) : this()
        {
            TopicStart = topicStart;
            TopicEnd = topicEnd;
        }
    }
}