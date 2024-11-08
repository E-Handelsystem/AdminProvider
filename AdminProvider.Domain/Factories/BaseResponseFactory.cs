using AdminProvider.Domain.Models;

namespace AdminProvider.Domain.Factories;

public abstract class BaseResponseFactory //Abstract klass så behöver använda oss av ResponseFactory när vi ska använda oss av ResponseResult.
{
    public static ResponseResult Success(int statusCode = 200, string? message = null!)
    {
        return new ResponseResult
        {
            Success = true,
            StatusCode = statusCode, 
            Message = message
        };
            
    }

    public static ResponseResult Failed(int statusCode = 400, string? message = null!)
    {
        return new ResponseResult
        {
            Success = false,
            StatusCode = statusCode,
        };

    }

    public static ResponseResult NotFound(int statusCode = 404, string? message = null!)
    {
        return new ResponseResult
        {
            Success = false,
            StatusCode = statusCode, 
        
        };

    }

    public static ResponseResult AlreadyExists(int statusCode = 409, string? message = null!)
    {
        return new ResponseResult
        {
            Success = false,
            StatusCode = statusCode,
        
        };

    }

}




