using System;

namespace AssignmentOne
{
    class UnderstandingTypes
    {
        public void PrintOne()
        {
            Console.WriteLine("sbyte memory size: {0} byte, minimum value: {1}, maximum value: {2}", sizeof(sbyte),
            sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine("byte memory size: {0} byte, minimum value: {1}, maximum value: {2}", sizeof(byte),
            byte.MinValue, byte.MaxValue);
            Console.WriteLine("short memory size: {0} byte, minimum value: {1}, maximum value: {2}", sizeof(short),
            short.MinValue, short.MaxValue);
            Console.WriteLine("ushort memory size: {0} byte, minimum value: {1}, maximum value: {2}", sizeof(ushort),
            ushort.MinValue, ushort.MaxValue);
            Console.WriteLine("int memory size: {0} byte, minimum value: {1}, maximum value: {2}", sizeof(int),
            int.MinValue, int.MaxValue);
            Console.WriteLine("uint memory size: {0} byte, minimum value: {1}, maximum value: {2}", sizeof(uint),
            uint.MinValue, uint.MaxValue);
            Console.WriteLine("long memory size: {0} byte, minimum value: {1}, maximum value: {2}", sizeof(long),
            long.MinValue, long.MaxValue);
            Console.WriteLine("ulong memory size: {0} byte, minimum value: {1}, maximum value: {2}", sizeof(ulong),
            ulong.MinValue, ulong.MaxValue);
            Console.WriteLine("float memory size: {0} byte, minimum value: {1}, maximum value: {2}", sizeof(float),
            float.MinValue, float.MaxValue);
            Console.WriteLine("double memory size: {0} byte, minimum value: {1}, maximum value: {2}", sizeof(double),
            double.MinValue, double.MaxValue);
            Console.WriteLine("decimal memory size: {0} byte, minimum value: {1}, maximum value: {2}", sizeof(decimal),
            decimal.MinValue, decimal.MaxValue);
        }

        public void PrintTwo(int yr)
        {
            Console.WriteLine($"Output: {yr} centuries = {100*yr} years = {36524*yr} days = {876576*yr} hours = "
                + $"{52594560*yr} minutes = {3155673600*yr} seconds = {3155673600000*yr} milliseconds = "
                + $"{3155673600000000*yr} microseconds = {(ulong)3155673600000000000*(ulong)yr} nanosecond");
        
        }
    }
}
