using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using IEmailUnitTest;

namespace IEmailUnitTest.Tests
{
    [TestFixture]
    public class BulkEmailSenderTests
    {
        [Test]
        public void SendEmail_WhenFails_ThrowsException()
        {
           
            var mb = new Mock<IEmailSender>();
            var bulk = new BulkEmailSender(mb.Object, string.Empty);
            var adresses = new List<string>{"a@a.com"};
            Assert.That(() => bulk.SendEmail(adresses, string.Empty), Throws.TypeOf<Exception>());
        }

        [Test]
        public void SendEmail_3Add_Sends3mails()
        {
            var mb = new Mock<IEmailSender>();
            var bulk = new BulkEmailSender(mb.Object, string.Empty);
            var adresses = new List<string> { "a@a.com", "b@b.com", "c@c.com" };
            mb.Setup(es => es.SendEmail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            bulk.SendEmail(adresses, string.Empty);
            mb.Verify(es => es.SendEmail(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(3));

        }

        [Test]
        public void SendEmail_ThreeAdd_SendsOneEach()
        {
            var mb = new Mock<IEmailSender>();
            var bulk = new BulkEmailSender(mb.Object, string.Empty);
            var adresses = new List<string> { "a@a.com", "b@b.com", "c@c.com" };
            mb.Setup(es => es.SendEmail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            bulk.SendEmail(adresses, string.Empty);
            mb.Verify(es => es.SendEmail("b@b.com", It.IsAny<string>()), Times.Once);

        }

    }
}
