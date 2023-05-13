
namespace MtasStudio.Domain.Models.Result.Concrete
{
    public class ErrorResult:Result
    {
        public ErrorResult() : base(false)
        {
        }

        public ErrorResult(string message) : base(false, message)
        {
        }
    }
}
