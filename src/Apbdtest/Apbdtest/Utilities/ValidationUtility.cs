namespace ApbdTest.Utilities
{
    public static class ValidationUtility
    {
        // Validates that a mobile number starts with +48
        public static bool IsValidMobileNumber(string mobileNumber)
        {
            return mobileNumber.StartsWith("+48");
        }
    }
}