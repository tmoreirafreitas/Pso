using System;
using System.Collections.Generic;
using System.Text;

namespace Pso.BackEnd.Infra.CrossCutting.NotificationsAndFilters
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
