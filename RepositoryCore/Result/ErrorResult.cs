using System;
using System.Collections.Generic;
using System.Text;

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
    public class ResponseData
    {
        public object result { get; set; }
        public int code { get; set; }
        public object error { get; set; }
    }

}
