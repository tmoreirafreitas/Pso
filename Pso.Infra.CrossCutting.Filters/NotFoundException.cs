using System;

namespace Pso.Infra.CrossCutting.Filters
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
