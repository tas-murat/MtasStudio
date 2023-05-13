using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Domain.Exceptions
{
    internal class MtasStudioDomainException : Exception
    {
        public MtasStudioDomainException()
        {

        }

        public MtasStudioDomainException(string message) : base(message)
        {
        }

        public MtasStudioDomainException(string? message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
