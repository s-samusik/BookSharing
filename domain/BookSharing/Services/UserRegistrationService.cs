using System.ComponentModel.DataAnnotations;

namespace BookSharing.Services
{
    public static class UserRegistrationService
    {
        public static bool IsLoginIncorrect(string login)
        {
            if(IsEmail(login) || IsPhone(login))
            {
                return false;
            }

            return true;
        }

        public static bool IsEmail(string login)
        {
            return new EmailAddressAttribute().IsValid(login);
        }

        public static bool IsPhone(string login)
        {
            return new PhoneAttribute().IsValid(login);
        }
    }
}
