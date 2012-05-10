﻿using NUnit.Framework;
using Softwarekueche.Categorizer.Extensions;
using Softwarekueche.Categorizer.Persister;

// ReSharper disable InconsistentNaming
namespace Softwarekueche.Categorizer.Tests
{
    [TestFixture()]
    public class Class1
    {
        [Test()]
        public void Between_Test_1()
        {
            const string test = "hello [world] thomas";

            var actual = test.Between("[", "]");

            Assert.That(actual, Is.EqualTo("world"));
        }

        [Test()]
        public void Between_Test_2()
        {
            const string test = "hello world thomas";

            var actual = test.Between("[", "]");

            Assert.That(actual, Is.Empty);
        }

        [Test()]
        public void Between_Test_3()
        {
            const string test = "[hello world thomas";

            var actual = test.Between("[", "]");

            Assert.That(actual, Is.Empty);
        }

        [Test()]
        public void Between_Test_4()
        {
            const string test = "hello world] thomas";

            var actual = test.Between("[", "]");

            Assert.That(actual, Is.Empty);
        }

        [Test()]
        public void Between_Test_5()
        {
            const string test = "hello |world| thomas";

            var actual = test.Between("|", "|");

            Assert.That(actual, Is.EqualTo("world"));
        }

        [Test()]
        public void Parse_Subject_Without_Anything()
        {
            const string sampleSubject = "This is the subject";
            var sut = new EnhancedSubject(sampleSubject, new Config("[", "]"));

            Assert.That(sut.Subject, Is.EqualTo("This is the subject"));
        }

        [Test()]
        public void Parse_Subject_With_Topic()
        {
            const string sampleSubject = "[TPC]This is the subject";
            var sut = new EnhancedSubject(sampleSubject, new Config("[", "]"));

            Assert.That(sut.Subject, Is.EqualTo("This is the subject"));
            Assert.That(sut.Topic, Is.EqualTo("TPC"));
        }
    }
}
