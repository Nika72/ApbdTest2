namespace ApbdTest.Models
{
    public class MobileOperator
    {
        public int OperatorId { get; set; }

        // Name of the mobile operator.
        public string OperatorName { get; set; }

        // Optional: Country code if handling operators from different countries.
        public string CountryCode { get; set; }

        // Optional: Any additional details like contact info, description, etc.
        public string Description { get; set; }
        public string ContactInfo { get; set; }
    }
}