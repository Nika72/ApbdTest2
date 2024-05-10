using ApbdTest.Data;
using ApbdTest.Models;
using Microsoft.Extensions.Configuration;

namespace ApbdTest.Services
{
    public class MobileService
    {
        private MobileRepository _mobileRepository;

        public MobileService(IConfiguration configuration)
        {
            // Assuming MobileRepository needs IConfiguration to access connection strings
            _mobileRepository = new MobileRepository(configuration);
        }

        public Client CreateOrUpdateClient(Client clientData)
        {
            return _mobileRepository.CreateOrUpdateClient(clientData);
        }

        public Client GetClientByMobileNumber(string mobileNumber)
        {
            return _mobileRepository.GetClientByMobileNumber(mobileNumber);
        }

        public bool DeleteClientByMobileNumber(string mobileNumber)
        {
            return _mobileRepository.DeleteClientByMobileNumber(mobileNumber);
        }
    }
}