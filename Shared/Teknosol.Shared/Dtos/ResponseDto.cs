using System.Collections.Generic; 
using Newtonsoft.Json;

namespace Teknosol.Shared.Dtos
{
    public class Response<T>
    {
        public T? Items { get; private set; }public int? TotalCount { get; set; }
        [JsonIgnore] public int StatusCode { get; private set; }

        public bool IsSuccessful { get; private set; }
        public List<string> Errors { get; set; } = null!;
        

        #region static factory methods

        public static Response<T> Success(T data, int statusCode,int? totalCount=1)
        {
            return new Response<T>()
            {
                Items = data,
                IsSuccessful = true,
                StatusCode = statusCode,
                TotalCount = totalCount
            };
        }

        public static Response<T?> Success(int statusCode)
        {
            return new Response<T?>()
            {
                Items = default(T),
                StatusCode = statusCode,
                IsSuccessful = true
            };
        }

        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T>()
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T>()
            {
                Errors = new List<string>() { error },
                IsSuccessful = false,
                StatusCode = statusCode
            };
        }

        #endregion
    }
}