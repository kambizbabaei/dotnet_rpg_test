using System;

namespace pr.Models
{
    public class ServiceResponse<T>
    {
        public ServiceResponse()
        {
            Time = DateTime.UtcNow.ToString();
        }
        public T Data { get; set; }

        public bool isSuccessful { get; set; } = false;

        public string Message { get; set; } = null;

        public string Time { get; }
    }
}