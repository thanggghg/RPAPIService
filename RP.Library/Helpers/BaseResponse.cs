using System.Net;

namespace RP.Library.Helpers
{
    public class BaseResponse
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }

        public BaseResponse() { }

        public BaseResponse(HttpStatusCode code, string message)
        {
            Code = code;
            Message = message;
        }
    }

    public class GenericResponse<T> : BaseResponse
    {
        public T Data { get; set; }

        public GenericResponse() { }

        public GenericResponse(HttpStatusCode code, string message, T data = default(T))
        {
            Code = code;
            Message = message;
            Data = data;
        }
    }

    public class BaseResponseCode
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public dynamic Data { get; set; }

        public BaseResponseCode() { }

        public BaseResponseCode(int code, string message, dynamic data = default)
        {
            Code = code;
            Message = message;
            Data = data;
        }
    }
}
