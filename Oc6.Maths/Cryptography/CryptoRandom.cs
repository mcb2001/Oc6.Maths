using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Oc6.Maths.Cryptography
{
    public sealed class CryptoRandom : IDisposable
    {
        private readonly RandomNumberGenerator randomNumberGenerator;
        private readonly bool doNotDispose;

        public CryptoRandom()
        {
            randomNumberGenerator = RandomNumberGenerator.Create();
            doNotDispose = false;
        }

        public CryptoRandom(RandomNumberGenerator randomNumberGenerator, bool doNotDispose = false)
        {
            this.randomNumberGenerator = randomNumberGenerator;
            this.doNotDispose = doNotDispose;
        }

        public bool TryNext<T>(out T t)
            where T : struct
        {
            return TryNextInternal(out t);
        }

        private unsafe bool TryNextInternal<T>(out T t)
        {
            t = default;

            try
            {
                byte[] buffer = new byte[Marshal.SizeOf<T>()];

                randomNumberGenerator.GetBytes(buffer);

                fixed (byte* packet = buffer)
                {
                    var intPtr = new IntPtr(packet);
                    t = Marshal.PtrToStructure<T>(intPtr);
                    return true;
                }
            }
            catch (MissingMethodException)
            {

            }
            catch (ArgumentException)
            {
            }

            return false;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            if (!doNotDispose)
            {
                randomNumberGenerator?.Dispose();
            }
        }

        ~CryptoRandom()
        {
            Dispose();
        }
    }
}