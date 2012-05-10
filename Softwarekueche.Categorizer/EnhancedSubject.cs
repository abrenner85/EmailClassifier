using Softwarekueche.Categorizer.Extensions;
using Softwarekueche.Categorizer.Persister;

namespace Softwarekueche.Categorizer
{
    public class EnhancedSubject
    {
        private readonly Config _config;

        public EnhancedSubject(string subjectToParse, Config config)
        {
            _config = config;
            Subject = subjectToParse;

            Parse();
        }

        private void Parse()
        {
            // get topic of email and remove topic
            var tmpTopic = Subject.Between(_config.TopicStart, _config.TopicEnd).Trim();
            Topic=new Topic() {Title = tmpTopic};

            // get subject w/o topic
            Subject = Subject.Replace(_config.TopicStart + tmpTopic + _config.TopicEnd, "")
                .Trim()
                .Replace("  ", " ").Replace("  ", " "); // replace all multiple spaces.
        }

        public Topic Topic { get; set; }

        public string Subject { get; set; }
    }
}