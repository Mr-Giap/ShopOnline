
using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Dtos
{
    public class RepontResult
    {
        public RepontResult()
        {
        }

        public RepontResult(bool success)
        {
            Success = success;
        }

        public RepontResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public RepontResult(bool success, object data)
        {
            Success = success;
            Data = data;
        }

        public object Data { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }

        public object Error { get; set; }
    }
}
