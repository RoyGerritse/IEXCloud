using NUnit.Framework;

namespace IEXCloud.Client.Tests
{
    public class ClientTests
    {
        [SetUp]
        public void Setup()
        {
            var token = "test";
            var client = new IEXCloudClient(token);
        }

        [Test]
        public void Test1()
        {
            //todo
            Assert.Pass();
        }
    }
}