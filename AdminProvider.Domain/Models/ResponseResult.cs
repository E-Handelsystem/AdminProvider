
namespace AdminProvider.Domain.Models;


public class ResponseResult<T> : ResponseResult //Får i och med T möjlighet att välja en type(någon typ av data) när jag ska använda ResponseResult. Väljer att göra på detta vis för att kunna använda ResponseResult i flera områden i programmet. Kan välja att sätta en type eller inte.
{
    public T? Data { get; set; }
}
public class ResponseResult
{
    public bool Success { get; set; }

    public int StatusCode { get; set; }

    public string? Message { get; set; }

}