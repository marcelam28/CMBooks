
namespace CMBooks.Common.Response
{
    public class ResponseCode 
    {
        public const int ErrorInvalidPassword = -7;
        public const int ErrorCreatingEntity = -6;
        public const int ErrorInvalidInput = -5;
        public const int ErrorEmailInvalid = -4;
        public const int ErrorAnErrorOccurred = -3;
        public const int NotSet = -2;
        public const int Error = -1;

        public const int Success = 0;

        public const int SuccessEntityCreated = 1;
        public const int SuccessLoggedIn = 2;

        public ResponseCode()
        {

        }
    }
}