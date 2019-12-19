
namespace RepositoryCore.Exceptions
{
    public class MyException : System.Exception
    {
        public MyException(string message):base(message)
        {
            Message = message;
        }
        public MyException(string message, int id):base(message)
        {
            Id = id;
        }
        public MyException(int id)
        {
            Id = id;
        }
        public MyException(string message, string token):base(message)
        {
            Token = token;
        }
    public string Message { get; }
        public int Id { get; }
        public string Token { get; }
    }
    public class RestException : System.Exception
    {
        public RestException(string message)
        {

        }
        public RestException(string url, object request, object response)
        {

        }
        public RestException(string url, object request, string message) { }
    }
}
