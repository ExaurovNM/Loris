using System;

namespace Lori.Domain.DataAccess
{
    public class RequestLog
    {
        public Guid Id { get; set; }

        public string Url { get; set; }

        public string Method { get; set; }

        public string Body { get; set; }

        public DateTime Time { get; set; }
    }
}
