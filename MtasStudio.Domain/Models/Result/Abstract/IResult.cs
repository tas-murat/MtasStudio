using System;
using System.Collections.Generic;
using System.Text;

namespace MtasStudio.Domain.Models.Result.Abstract
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
}
}
