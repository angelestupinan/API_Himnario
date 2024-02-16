using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class Response<T>
    {
        ///clase que se encarga de dar una respuesta uniforme
        public bool Succeeded { get; set; }

        public string Message { get; set; }

        public List<string> Errors { get; set; }

        public T Result { get; set; }

        public Response() { }

        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Result = data;
        }
    }
}