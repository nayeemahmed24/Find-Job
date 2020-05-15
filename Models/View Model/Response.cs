using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class Response
    {
        public Response(bool status)
        {
            Status = status;
        }
        public bool Status { get; set; }
    }
}
