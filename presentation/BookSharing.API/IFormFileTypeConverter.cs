using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BookSharing.API
{
    public class IFormFileTypeConverter : ITypeConverter<IFormFile, byte[]>
    {
        public byte[] Convert(IFormFile source, byte[] destination, ResolutionContext context)
        {
            destination = null;

            using (var binaryReader = new BinaryReader(source.OpenReadStream()))
            {
                destination = binaryReader.ReadBytes((int)source.Length);
            }

            return destination;
        }
    }
}
