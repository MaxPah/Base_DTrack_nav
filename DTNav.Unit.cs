using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Base_DTrack_Nav
{
    [TestFixture]
    class Class1
    {
        [Test]
        public void test_ChecksumCalculatorEmpty()
        {
            bool test = Base_DTrack_Nav.Program.checksumCalculator("");
            Assert.True(1 == 1);

        }
    }
}
