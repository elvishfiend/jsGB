using System;
using System.Reflection;
using csGB;
using NUnit.Framework;

namespace csGB.Tests
{
    [TestFixture]
    public class CpuInstructions
    {
        public void RunTestRom(string romPath)
        {
            GB.ResetAll();
            MMU.load(romPath);
            GB.Run();
        }

        [Test]
        public void CpuInstr()
        {
            var path = @"C:\Users\Zachary\Dropbox\Programming\jsGB\csGB\TestRoms\cpu_instrs\cpu_instrs.gb";

            RunTestRom(path);

            ValidateRomResults();
        }

        public void ValidateRomResults()
        {
            Assert.AreEqual(0, MMU.rb(0xFF01));
        }

    }
}
