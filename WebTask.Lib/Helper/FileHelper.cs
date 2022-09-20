using System.IO;
using System.Threading.Tasks;

namespace WebTask.Lib.Helper
{
    public static class FileHelper
    {
        public static async Task<byte[]> GetByteAsync(string path)
        {
           return await File.ReadAllBytesAsync(path);
        }

        public static byte[] GetByte(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}
