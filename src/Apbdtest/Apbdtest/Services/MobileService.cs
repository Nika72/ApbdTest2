using Apbdtest.Data;
using ApbdTest.Data;
using ApbdTest.Models;

namespace ApbdTest.Services
{
    public class MobileService
    {
        private MobileRepository _mobileRepository = new MobileRepository();

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