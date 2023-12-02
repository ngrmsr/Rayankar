using PhoneNumbers;

namespace CustomerManagment.Web.Server.Helper
{
    public static class ValidationHelper
    {
        public static bool IsPhoneNumberValid(this string phoneNumber)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                PhoneNumber parsedPhoneNumber = phoneUtil.Parse(phoneNumber, null);
                return phoneUtil.IsValidNumberForRegion(parsedPhoneNumber, "98");
            }
            catch (NumberParseException)
            {
                return false;
            }
        }
    }
}
