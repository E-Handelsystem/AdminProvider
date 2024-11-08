using AdminProvider.Domain.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdminProvider.Domain.Factories;

public class ResponseFactory<T> : ResponseFactory //Single responsibility och DRY - har en factory för responseresult så dessa kan återanvändas i andra delar i programmet på sikt.
                                                  //T innebär att vi kan välja vilken typ av Respons vi vill ha. Har i och med detta en generisk responsklass.
{
    public static ResponseResult<T> Success(T data, int statusCode = 200, string? message = "Allt har gått bra!")
    {
        return new ResponseResult<T>
        {
            Success = true,
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }

    public static ResponseResult<T> NotFound(T data, int statusCode = 404, string? message = null!)
    {
        return new ResponseResult<T>
        {
            Success = true,
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }
    public static ResponseResult<T> Failed(T data, int statusCode = 400, string? message = "Har inte gått bra")
    {
        return new ResponseResult<T>
        {
            Success = false,
            StatusCode = statusCode,
            Message = message,
           Data = data
        };

    }
}

public class ResponseFactory : BaseResponseFactory
{

}


