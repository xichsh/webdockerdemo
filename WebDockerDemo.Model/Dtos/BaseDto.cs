using System;
using System.Collections.Generic;
using System.Text;

namespace WebDockerDemo.Model.Dtos
{
    public class BaseDto<T>
    {
        public BaseDto(StatusCode code, string message)
        {
            Code = code;
            Message = message;
        }

        public BaseDto(StatusCode code, string message, T data)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        public StatusCode Code { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }

    public enum StatusCode
    {
        Success = 0,
        Error = 1,
    }
}