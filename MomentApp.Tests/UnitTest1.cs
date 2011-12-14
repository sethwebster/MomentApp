using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MomentApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestScheduleJob()
        {
            Uri testUri = new Uri("http://google.com?q=momenttest");
            Moment a = new Moment("");
            var job = a.ScheduleJob(new Job()
                {
                    at = DateTime.Now.AddMinutes(1),
                    method = "POST",
                    uri = testUri
                });
            Assert.IsNotNull(job.id);
        }
    }
}
