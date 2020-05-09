using System;

namespace NotificationApp.Model
{
    public class NotificationLog
    {
        public bool IsSuccess { get; set; }
        public string RequestId { get; set; }
        public string Message { get; set; }
        public string StatusCode { get; set; }
        public DateTime Date { get; set; }
    }
}