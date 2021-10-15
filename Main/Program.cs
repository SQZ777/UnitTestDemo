using System;
using Microsoft.Extensions.DependencyInjection;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class MemberCalculator
    {
        private ICustomerService _customerService;

        public MemberCalculator(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public int GetMemberLevel(string customerName)
        {
            int consumptionAmount = _customerService.GetConsumptionAmount(customerName);
            if (consumptionAmount >= 10000)
            {
                return 2;
            }
            else if (consumptionAmount >= 1000)
            {
                return 1;
            }

            return 0;
        }
    }

    public interface ICustomerService
    {
        int GetConsumptionAmount(string customerName);
    }

    public class CustomerService : ICustomerService
    {
        public int GetConsumptionAmount(string customerName)
        {
            // dependence with data base.
            return 0;
        }
    }
}