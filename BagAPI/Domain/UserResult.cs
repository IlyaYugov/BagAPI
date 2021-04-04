using DTO;

namespace Domain
{
    public class UserResult
    {
        public UserDto User { get; set; }
        public string ExceptionNessage { get; set; }
    }
}
