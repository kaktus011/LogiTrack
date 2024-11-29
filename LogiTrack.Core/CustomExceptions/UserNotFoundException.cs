using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
namespace LogiTrack.Core.CustomExceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base(UserNotFoundErrorMessage)
        {
        }
    }
}
