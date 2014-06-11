//----------------------------------------------------------------------------- 
// <copyright file="Program.cs" company="PAHUD Maxime"> 
// Copyright (c) Pahud Maxime. All rights reserved. 
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Base_DTrack_Nav
{
    class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            //[$GPGGA],[0-9]*.[0-9]*,[0-9]*.[0-9]*,[N|S],[0-9]*.[0-9]*,[E|W],[0-2],[0-1][0-9],[0-9]*.[0-9]*,[0-9]*.[0-9]*,[M]*,[0-9]*.[0-9]*,[M|]*,[0-9]*,[0-9]*[*][0-9|A-F]{2}
          /*  string t;
           List<Object> list = new List<Object>();

            t = initGPS();
            list = splitMessage(t,list);
            printData(list);*/
            
            dtnav_test.test_ListObject();
            sTOP_CMD();
        }

        /// <summary>
        /// Used to calculate checksum
        /// </summary>
        /// <param name="trame">trame which we calculate the checksum</param>
        public static bool checksumCalculator(string trame) {
            int checksum = 0;
            string baseChecksum;
            int Output=0;

            for (int i = 0; i < trame.Length -3; i++)
                checksum ^= Convert.ToByte(trame[i]);
          
            if (trame.Length != 0)
                baseChecksum = trame.Substring(trame.Length -2, 2);
            else baseChecksum = "00";

            Output = int.Parse(baseChecksum, System.Globalization.NumberStyles.HexNumber);

           /// Returns
            if (checksum.Equals(Output))
                return true;
            else
            {
                Console.WriteLine("Wrong Checksum");
                return false;
            }
        }

        /// <summary>
        /// Used to parse frames (DGPS) in array of string
        /// </summary>
        /// <param name="t">String to parse</param>
        /// <returns>Return array parsed</returns>
       public static List<Object> splitMessage(string t, List<Object> list) {
            string[] split;
            string[][] split2;

            t = t.Substring(1, t.Length-1);
            split= t.Split('$');
            split2 = new string[split.Length][];

           for(int i=1; i<split.Length;i++)
            {
                if (checksumCalculator(split[i]))
                    split2[i] = split[i].Split(',');

                if (split2[i][0] == "GPGGA")
                {
                    objGPGGA = new ObjectGPGGA(split2[i]);
                    list.Add(objGPGGA);
                }
                else if (split2[i][0] == "GPRMC")
                {
                    objGPRMC = new ObjectGPRMC(split2[i]);
                    list.Add(objGPRMC);
                }
                //else Console.WriteLine(split2[i][0]);
             
                            
            }

           return list;
        }


        /// <summary>
        /// Used to initialize string to parse
        /// </summary>
        /// <returns>Return the string to parse </returns>
       public static string initGPS()
        {
            string message = "$GPGSA,A,3,08,07,04,10,05,02,23,13,,,,,2.4,1.0,2.1*38$GPRMC,105957.918,A,3401.3667,N,00649.6145,W,0.00,,050510,,*0E$GPGGA,105958.918,3401.3667,N,00649.6144,W,1,08,1.0,99.9,M,45.3,M,0.0,0000*5C$GPGSA,,,,,,,,,,,,,,,,,*6E$GPRMC,105958.918,A,3401.3667,N,00649.6144,W,0.00,,050510,,*00$GPGGA,105959.917,3401.3667,N,00649.6143,W,1,08,1.0,100.0,M,45.3,M,0.0,0000*6D$GPGSA,A,3,08,07,04,10,05,02,23,13,,,,,2.4,1.0,2.1*38$GPRMC,105959.917,A,3401.3667,N,00649.6143,W,0.00,,050510,,*09$GPGGA,110000.917,3401.3666,N,00649.6143,W,1,08,1.0,100.2,M,45.3,M,0.0,0000*6F$GPGSA,A,3,08,07,04,10,05,02,23,13,,,,,2.4,1.0,2.1*38$GPRMC,110000.917,A,3401.3666,N,00649.6143,W,0.00,,050510,,*09$GPGGA,110001.917,3401.3667,N,00649.6142,W,1,08,1.0,100.4,M,45.3,M,0.0,0000*68$GPGSA,A,3,08,07,04,10,05,02,23,13,,,,,2.4,1.0,2.1*38$GPGSV,2,1,08,04,62,198,43,07,61,102,43,02,49,296,42,10,47,318,46*7F$GPGSV,2,2,08,08,46,166,42,13,35,042,37,05,20,303,39,23,13,053,41*77$GPRMC,110001.917,A,3401.3667,N,00649.6142,W,0.00,,050510,,*08$GPGGA,110002.917,3401.3667,N,00649.6142,W,1,08,1.0,100.5,M,45.3,M,0.0,0000*6A";
            //string message = "$GPGGA,064036.289,4836.5375,N,00740.9373,E,1,04,3.2,200.2,M,,,,0000*0E";
            message = message.Substring(0);
            return message;
        }

        /// <summary>
        /// Used to don't close console without human intervention
        /// </summary>
       public static void sTOP_CMD() {
            Console.WriteLine("\n\t\t --- \tECHAP to quit\t ---");
            do
            {
                while (!Console.KeyAvailable)
                { }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

      public  static void printData(List<Object> list) {
            for(int i=0; i < list.Count; i++)
            {
                
                if (list[i].ToString().Contains("GPGGA"))
                    printGPGGA((ObjectGPGGA)list[i]);
                else if (list[i].ToString().Contains("GPRMC"))
                     printGPRMC((ObjectGPRMC)list[i]);
            }

        }

        public static void printGPGGA(ObjectGPGGA p)
        {
            Console.WriteLine(p.type + "  -  " + p.timeUTC + "  -  " + p.latitude + "  -  " + p.longitude + "  -  " + p.gpsQuality + "  -  " + p.nSat + "  -  " +
               p.dilution + "  -  " + p.altitude + "  -  " + p.altUnit + "  -  " + p.geoidal + "  -  " + p.geoUnit + "  -  " + p.dGPSTime + "  -  " + p.stationRef + "  -  " + p.checksum);
        }

        public static void printGPRMC(ObjectGPRMC p)
        {
            Console.WriteLine(p.type + "  -  " + p.timeUTC + "  -  " + p.status + "  -  " + p.latitude + "  -  " + p.longitude + "  -  " + p.speed + "  -  " + p.cap + "  -  " + p.date + "  -  " +
             p.magnetic + "  -  " + p.posEorWMagnetic + "  -  " + p.checksum);
        }

        public static ObjectGPRMC objGPRMC { get; set; }
        public static ObjectGPGGA objGPGGA { get; set; }
    }
}


/*
 * 
 *  System.Threading.Thread.Sleep(100); // used to simulate D-GPS frequency (10 per second)

*/


