namespace Softwarekueche.Categorizer.Persister
{
    public class Config
    {
        public string TopicStart { get; set; }
        public string TopicEnd { get; set; }

        public Config() {}

        public Config(string topicStart, string topicEnd) : this()
        {
            TopicStart = topicStart;
            TopicEnd = topicEnd;
        }
    }
}