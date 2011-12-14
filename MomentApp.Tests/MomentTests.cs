using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace MomentApp.Tests
{
    [TestClass]
    public class MomentTests
    {
        [TestMethod]
        public void TestScheduleJob()
        {
            Uri testUri = new Uri("http://google.com");
            // You will need an app.config with this setting available
            Moment a = new Moment(ConfigurationManager.AppSettings["MomentApp.ApiKey"]);
            var job = a.ScheduleJob(new Job()
            {
                at = DateTime.Now.AddMinutes(1),
                method = "GET",
                uri = testUri
            });
            Assert.IsNotNull(job.id);
        }
    }
}
