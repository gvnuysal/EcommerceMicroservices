namespace Teknosol.Services.Order.Application.Dtos
{
    public class AddressDto
    {
        public string Provience { get; private set; }
        public string District { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public string AddressLine { get; private set; }
    }
}