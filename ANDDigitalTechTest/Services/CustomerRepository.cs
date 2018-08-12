using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANDDigitalTechTest.Models;

namespace ANDDigitalTechTest.Services
{
    public class CustomerRepository
    {
        private const string CacheKey = "ContactStore";

        public CustomerRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var contacts = new[]
                    {
                        new Customer
                        {
                            Id = 1, Name = "Tomas Adams", PhoneNumbers =
                                new List<PhoneNumber>
                                {
                                    new PhoneNumber{TelephoneNumber = "07123456789", Active = true}
                                }
                        },
                        new Customer
                        {
                            Id = 2, Name = "Hannah Cooper", PhoneNumbers =
                                new List<PhoneNumber>
                                {
                                    new PhoneNumber{TelephoneNumber = "07123456788", Active = true}
                                }
                        },
                        new Customer
                        {
                            Id = 3, Name = "James Dean", PhoneNumbers =
                                new List<PhoneNumber>
                                {
                                    new PhoneNumber
                                    {
                                        TelephoneNumber = "07123456787", Active = true
                                    },
                                    new PhoneNumber
                                    {
                                        TelephoneNumber = "07123456786", Active = true
                                    },
                                    new PhoneNumber
                                    {
                                        TelephoneNumber = "07123456785", Active = true
                                    }
                                }
                        }
                    };

                    ctx.Cache[CacheKey] = contacts;
                }
            }
        }

        public Customer[] GetAllCustomers()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Customer[])ctx.Cache[CacheKey];
            }

            return new[]
            {
                new Customer
                {
                    Id = 0,
                    Name = "Placeholder"
                }
            };
        }

        public Customer GetCustomerById(int id)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Customer[])ctx.Cache[CacheKey]).ToList();

                    Customer cust = currentData.SingleOrDefault(c => c.Id == id);

                    return cust;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }

            return null;
        }


        public bool UpdateCustomer(Customer customer)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Customer[])ctx.Cache[CacheKey]).ToList();
                    Customer cust = currentData.SingleOrDefault(c => c.Id == customer.Id);

                    if (cust != null)
                    {
                        cust.Name = customer.Name;
                        cust.PhoneNumbers = customer.PhoneNumbers;


                        ctx.Cache[CacheKey] = currentData.ToArray();
                        return true;
                    }
                    // return customer not found
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}