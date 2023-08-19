using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCoreLite.Results.Bases
{
    public abstract class Result
    {

        public bool IsSuccessfully { get; }

        public string? Message { get; set; }

        public Result(bool isSuccessful, string message)
        {
            IsSuccessfully = isSuccessful;
            Message = message;
        }

    }
}
