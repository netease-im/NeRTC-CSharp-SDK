using System;
using System.Runtime.InteropServices;

namespace nertc
{
    public static class MarshalExtension
    {
        public static T[] PtrToStructureArray<T>(IntPtr unmanagedArray, uint length)
        {
            if (length == 0)
            {
                return null;
            }

            var array = new T[length];
            var size = Marshal.SizeOf<T>();

            IntPtr current = unmanagedArray;
            for (int i = 0; i < length; i++)
            {
                array[i] = Marshal.PtrToStructure<T>(current);
                current += size;
            }

            return array;
        }
        public static void StructureArrayToPtr<T>(this T[] array, IntPtr unmanagedArray)
        {
            if (unmanagedArray == IntPtr.Zero)
            {
                return;
            }
            var size = Marshal.SizeOf(typeof(T));

            IntPtr current = unmanagedArray;
            for (int i = 0; i < array.Length; i++)
            {
                Marshal.StructureToPtr<T>(array[i], current, false);
                current += size;
            }
        }
    }
}
