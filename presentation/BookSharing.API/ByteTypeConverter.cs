using System;
using AutoMapper;

namespace BookSharing.API
{
    public class ByteTypeConverter : ITypeConverter<byte[], string>
    {
        public string Convert(byte[] source, string destination, ResolutionContext context)
        {
            destination = String.Empty;

            if (source != null)
            {
                destination = System.Convert.ToBase64String(source);
            }
            
            return destination;
        }
    }
}