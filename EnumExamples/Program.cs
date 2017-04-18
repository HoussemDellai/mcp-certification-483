using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumExamples
{
    class Program
    {
        [Flags]
        public enum EBitwiseEnum
        {
            NONE = 0x0,
            Bit1 = 0x1,
            Bit2 = 0x2,
            Bit3 = 0x4
        }

        static void Main(string[] args)
        {
            EBitwiseEnum bitTest = EBitwiseEnum.Bit1 | EBitwiseEnum.Bit3;

            //check a flag
            if(bitTest.HasFlag(EBitwiseEnum.Bit1))
            {
                Console.WriteLine("Bit 1 is set");
            }

            // unset a flag: bitTest = EBitwiseEnum.Bit1
            bitTest &= ~EBitwiseEnum.Bit3;

            // set a flag: bitTest = EBitwiseEnum.Bit1 | EBitwiseEnum.Bit2
            bitTest |= EBitwiseEnum.Bit2;

            //combine two Flag Enums
            EBitwiseEnum bitTest2 = EBitwiseEnum.Bit1 | EBitwiseEnum.Bit3;
            // both combined have all flags:
            EBitwiseEnum bitTestCombined = bitTest | bitTest2;

            ;
        }
    }
}
