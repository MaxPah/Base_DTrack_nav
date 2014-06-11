using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Mocks;

namespace Base_DTrack_Nav
{
    [TestFixture]
    class dtnav_test
    {
        [Test]
        public static void test_ListObject()
        {
            List<Object> list3 = new List<Object>();
            string[] tab1 = new string[15];
            tab1[0] = "GPGGA";
            tab1[1] = "154654.215";
            tab1[2] = "4428.2011";
            tab1[3] = "N";
            tab1[4] = "00440.5161";
            tab1[5] = "W";
            tab1[6] = "0";
            tab1[7] = "00";
            tab1[8] = string.Empty;
            tab1[9] = "00044.7";
            tab1[10] = "M";
            tab1[11] = "051.6";
            tab1[12] = "M";
            tab1[13] = "0.0";
            tab1[14] = "*73";
            string msg = "$GPGGA,154654.215,4428.2011,N,00440.5161,W,0,00,,00044.7,M,051.6,M,,*73$";
            
            list3 = Program.splitMessage(msg, list3);
            Console.WriteLine(list3.Count);
            ObjectGPGGA i1 = new ObjectGPGGA(tab1);
            //list3.Add(i1);
            //Assert.AreEqual(i1, list3.First());
        }
    }
}