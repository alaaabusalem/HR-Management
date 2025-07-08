using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public class ResponseHeader
    {
        public ResultType Status { set; get; }
        public List<Message> MessagesList { set; get; } = new();
    }
    public class Message
    {
        public string? MessageCode { set; get; }
        public string? MessageDesc { set; get; }
    }
}
