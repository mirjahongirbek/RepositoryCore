using System;


namespace RepositoryCore.Result
{
    public class ErrorResult
    {
       public int Code { get; set; }
        public string Message { get; set; }
        public ErrorResult()
        {

        }
         public ErrorResult (Exception ext)
        {

        }   
    }
  

}
