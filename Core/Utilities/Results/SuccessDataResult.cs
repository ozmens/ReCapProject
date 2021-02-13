using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult<T>:DataResult<T>
    {
        public SuccessResult(T data, string message):base(data,true,message)
        {

        }

        public SuccessResult(T data):base(data,true)
        {

        }

        public SuccessResult(string message):base(default,true,message)
        {

        }
        public SuccessResult():base(default,true)
        {

        }
    }
}
