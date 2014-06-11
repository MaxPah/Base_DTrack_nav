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
        public void test_ListObject()
        {
            List<Object> list = new List<Object>();
            List<Object> list2 = new List<Object>();

            Program.splitMessage("$GPGGA,154654,4428.2011,N,00440.5161,W,0,00,,-00044.7,M,051.6,M,,*6B", list);


            string[] tab1 = new string[10];

            tab1[0]="GPGGA";
            tab1[1]="154654";
            tab1[2]="4428.2011";
            tab1[3]="N";
            tab1[4]="00440.5161";
            tab1[5]="W";
            tab1[6]="0";
            tab1[7]="00";
            tab1[8]="\0";
            tab1[9]="-00044.7";
            tab1[10]="M";
            tab1[11]="051.6";
            tab1[12]="M";
            tab1[13]="";
            tab1[14]="*6B";



            ObjectGPGGA i1 = new ObjectGPGGA(tab1);
            list2.Add(i1);

            Assert.AreSame(list, list2);
            


        }
    }
}
