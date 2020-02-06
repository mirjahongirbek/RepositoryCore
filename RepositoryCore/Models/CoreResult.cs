using RepositoryCore.Enums;

namespace RepositoryCore.Models
{
   public class ResponseData
    {
        public ResponseData()
        {
        }

        public ResponseData(StatusCore status)
        {
            StatusCore = status;
        }
        public string Message { get; set; }
        public int Code { get; set; }
        public object Result { get; set; }
        public object Error { get; set; }
        public StatusCore StatusCore { get; set; } = StatusCore.Success;
    }
}
