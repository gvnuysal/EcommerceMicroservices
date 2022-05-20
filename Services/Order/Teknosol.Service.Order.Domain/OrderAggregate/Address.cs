using System.Collections.Generic;
using Teknosol.Services.Order.Domain.Core;

namespace Teknosol.Service.Order.Domain.OrderAggregate
{
    public class Address : ValueObject
    {
        public string Provience { get; private set; }
        public string District { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public string AddressLine { get; private set; }

        public Address()
        {
            
        }
        
        public Address(string provience, string district, string street, string zipCode, string addressLine)
        {
            Provience = provience;
            District = district;
            Street = street;
            ZipCode = zipCode;
            AddressLine = addressLine;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Provience;
            yield return District;
            yield return Street;
            yield return ZipCode;
            yield return AddressLine;
        }
    }
}