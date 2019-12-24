namespace RepositoryCore.Models
{
   public class ResponseData
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public object Result { get; set; }
        public object Error { get; set; }
    }
}
