using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;

namespace MomentApp
{
    public class Moment
    {
        private readonly string _momentAppUrl = "https://momentapp.com/jobs.json?apikey={0}";
        private string _apiKey = string.Empty;

        public Moment(string apiKey)
        {
            _apiKey = apiKey;
        }

        public Job ScheduleJob(Job job)
        {
            var req = (HttpWebRequest)WebRequest.Create(
                string.Format(_momentAppUrl, _apiKey));
            req.Method = "POST";
            req.ContentType = "application/json";
            byte[] data = Encoding.UTF8.GetBytes
            (
                "{'job':" + JsonConvert.SerializeObject(job, new IsoDateTimeConverter()) + "}"
            );
            req.ContentLength = data.Length;
            using (var stream = req.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            using (var response = req.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var responseData = reader.ReadToEnd();
                    dynamic jobData = JsonConvert.DeserializeObject(responseData);
                    if (jobData.success != null)
                    {
                        job.id = jobData.success.job.id;
                        return job;
                    }
                    throw new Exception("Failed: " + jobData.error);
                }
            }

        }
    }

}
