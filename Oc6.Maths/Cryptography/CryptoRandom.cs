using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace Oc6.Maths.Cryptography
{
    public sealed class CryptoRandom : IDisposable
    {
        private readonly RandomNumberGenerator randomNumberGenerator;
        private readonly BinaryFormatter formatter = new BinaryFormatter();

        public CryptoRandom()
        {
            randomNumberGenerator = RandomNumberGenerator.Create();
        }

        public CryptoRandom(RandomNumberGenerator randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public T Next<T>()
            where T : struct
        {
            return NextInternal<T>();
        }

        private unsafe T NextInternal<T>()
        {
            byte[] buffer = new byte[Marshal.SizeOf<T>()];

            randomNumberGenerator.GetBytes(buffer);

            fixed (byte* packet = buffer)
            {
                var intPtr = new IntPtr(packet);
                return Marshal.PtrToStructure<T>(intPtr);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            randomNumberGenerator?.Dispose();
        }

        ~CryptoRandom()
        {
            Dispose();
        }
    }
}