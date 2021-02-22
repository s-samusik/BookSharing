using AutoMapper;

namespace BookSharing.API
{
    public class ByteTypeConverter : ITypeConverter<byte[], string>
    {
        public string Convert(byte[] source, string destination, ResolutionContext context)
        {
            destination = System.Convert.ToBase64String(source);
            return destination;
        }
    }
}
