using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ExamBuilder.Shared
{
    public class OprationResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public static OprationResult Success(string message="")
        {
            message = string.Format(Messages.Success, message);
            return new OprationResult()
            {
                IsSuccess = true,
                Message = message
            };
        }
        public static OprationResult UnSuccess(string message="")
        {
            return new OprationResult()
            {
                IsSuccess = false,
                Message = message
            };
        }
        public static OprationResult RunTimeError()
        {
            return new OprationResult
            {
                IsSuccess = false,
                Message = Messages.RunTimeError
            };
        }
    }
    public class OprationResult<T> : OprationResult
    {
        public T Data { get; set; }
        public static OprationResult<T> Success(T data, string message = "")
        {
            if (message != null)
            {
                message = string.Format(Messages.Success, message);
            }
            return new OprationResult<T>()
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }
        public new static OprationResult<T> RunTimeError()
        {
            return new OprationResult<T>
            {
                IsSuccess = false,
                Message = Messages.RunTimeError
            };
        }
    }
}
