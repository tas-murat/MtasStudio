
namespace MtasStudio.Domain.Models.Result.Concrete
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {
        }

        public SuccessResult( string message) : base(true, message)
        {
        }
    }
}
