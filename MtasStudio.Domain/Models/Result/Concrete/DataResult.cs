

using MtasStudio.Domain.Models.Result.Abstract;

namespace MtasStudio.Domain.Models.Result.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success) : base(success)
        {
            Data = data;
        }

        public DataResult(T data,bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
