using System;
using System.Collections.Generic;
using System.Text;
using Pso.BackEnd.Command.Request;

namespace Pso.BackEnd.Command.Responses
{
    public class EntityResponse
    {
        public string Message { get; private set; }      

        public EntityResponse(string message = "")
        {
            Message = message;
        }
    }
}
