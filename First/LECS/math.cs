using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Diagnostics;

using System.Text;

namespace LECS
{


    [System.Serializable]
    public struct uint4
    {
        public uint x;
        public uint y;
        public uint z;
        public uint w;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4(uint x,uint y,uint z,uint w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;

        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public uint4 operator + (uint4 lhs,uint rhs)
        {
            return new uint4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public uint4 operator * (uint4 lhs,uint rhs)
        {
            return new uint4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public uint4 operator +(uint4 lhs,uint4 rhs)
        {
            return new uint4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.y, lhs.w + rhs.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator ++(uint4 val) { return new uint4(++val.x, ++val.y, ++val.z, ++val.w); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator <<(uint4 x, int n) { return new uint4(x.x << n, x.y << n, x.z << n, x.w << n); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator >>(uint4 x, int n) { return new uint4(x.x >> n, x.y >> n, x.z >> n, x.w >> n); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator |(uint4 lhs, uint4 rhs) { return new uint4(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z, lhs.w | rhs.w); }



    }


    static unsafe public class math
    {
        /// <summary>Returns the result of rotating the bits of a uint left by bits n.</summary> 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint rol(uint x, int n) { return (x << n) | (x >> (32 - n)); }

        public static unsafe uint hash(void* pBuffer, int numBytes, uint seed = 0)
        {
            unchecked
            {
                const uint Prime1 = 2654435761;
                const uint Prime2 = 2246822519;
                const uint Prime3 = 3266489917;
                const uint Prime4 = 668265263;
                const uint Prime5 = 374761393;

                uint4* p = (uint4*)pBuffer;
                uint hash = seed + Prime5;
                if (numBytes >= 16)
                {
                    uint4 state = new uint4(Prime1 + Prime2, Prime2, 0, (uint)-Prime1) + seed;

                    int count = numBytes >> 4;
                    for (int i = 0; i < count; ++i)
                    {
                        state += *p++ * Prime2;
                        state = (state << 13) | (state >> 19);
                        state *= Prime1;
                    }

                    hash = rol(state.x, 1) + rol(state.y, 7) + rol(state.z, 12) + rol(state.w, 18);
                }

                hash += (uint)numBytes;

                uint* puint = (uint*)p;
                for (int i = 0; i < ((numBytes >> 2) & 3); ++i)
                {
                    hash += *puint++ * Prime3;
                    hash = rol(hash, 17) * Prime4;
                }

                byte* pbyte = (byte*)puint;
                for (int i = 0; i < ((numBytes) & 3); ++i)
                {
                    hash += (*pbyte++) * Prime5;
                    hash = rol(hash, 11) * Prime1;
                }

                hash ^= hash >> 15;
                hash *= Prime2;
                hash ^= hash >> 13;
                hash *= Prime3;
                hash ^= hash >> 16;

                return hash;
            }
        }

    }
}
