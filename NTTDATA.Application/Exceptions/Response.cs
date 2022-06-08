using Microsoft.Extensions.Options;
using NTTDATA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NTTDATA.Application.Exceptions
{
    public class Response<T>
    {     
        public Response(T data, string code, IOptions<AppSettings> _config)
        {
           
            Data = data;           
            Code = code;
            
            var Msg = _config.Value.MensajesApp.Where(x => x.Codigo == code);
            if (Msg.Count() != 0)
            {
                Message = Msg.FirstOrDefault().Mensaje;
            }
        }

        public Response(T data, string code, string traceId, IOptions<AppSettings> _config)
        {


            Code = code;
            //Message = Startup.MensajesApp.GetSection(code).Value;
            var Msg = _config.Value.MensajesApp.Where(x => x.Codigo == code);
            if (Msg.Count() != 0)
            {
                Message = Msg.FirstOrDefault().Mensaje;
            }


            TraceId = traceId;
            Data = data;
        }

        public Response(string message)
        {
            //Succeeded = false;
            Message = message;
        }


        public string TraceId { get; set; }
        //public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
