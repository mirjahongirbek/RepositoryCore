
namespace RepositoryCore.Exceptions
{
    public class CoreException : System.Exception
    {
        public CoreException(string message):base(message)
        {
            Message = message;
        }
        public CoreException(string message, int id):base(message)
        {
            Id = id;
        }
        public CoreException(int id)
        {
            Id = id;
        }
        public CoreException(string message, string token):base(message)
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
