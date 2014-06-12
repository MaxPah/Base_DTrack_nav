//----------------------------------------------------------------------------- 
// <copyright file="Program.cs" company="PAHUD Maxime"> 
// Copyright (c) Pahud Maxime. All rights reserved. 
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base_DTrack_Nav
{
    #region ObjectGPGGA Class
    /// <summary>
    /// This is a decendant of ObjectGP used to initialize ObjectGPGGA with a trame
    /// </summary>
    class ObjectGPGGA : ObjectGP
    {
        #region fields
            public string type;
            public DateTime timeUTC;
            public string latitude;
            public string longitude;
            public byte gpsQuality;
            public byte nSat;
            public double dilution;
            public double altitude;
            public char altUnit;
            public double geoidal;
            public char geoUnit;
            public DateTime dGPSTime;
            public string stationRef;
            public string checksum; // value.ToString("X");
        #endregion

        #region ObjectGPGGA Constructor
        /// <summary>
            /// ObjectGPGGA Constructor
        /// </summary>
        /// <param name="var">Used to initialize an instance of ObjectGPGGA</param>
        public ObjectGPGGA(string[] var)
        {
            string separator = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;

            this.type = "GPGGA";
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            if (var[1] != "")
            {
                int h = int.Parse(var[1].Substring(0, 2));
                int m = int.Parse(var[1].Substring(2, 2));
                int s = int.Parse(var[1].Substring(4, 2));
                int ms = int.Parse(var[1].Substring(7, 3));
                this.timeUTC = new DateTime(year, month, day, h, m, s, ms);
            }
            else this.timeUTC = new DateTime(1, 1, 1);
            if(var[2] != "")
                this.latitude = toLatitude(var[2]) + " " + char.Parse(var[3]);
            else this.latitude = "0°0'0.0\" N";
            if(var[4] != "")
                this.longitude = toLongitude(var[4]) + " " + char.Parse(var[5]);
            else this.longitude = "0°0'0.0\" E";
            if(var[6] != "")
                this.gpsQuality = byte.Parse(var[6]);
            else this.gpsQuality = 0;
            if(var[7] != "")
                this.nSat = byte.Parse(var[7]);
            else this.nSat = 0;
            if (var[8] != string.Empty || var[8] != "")
                this.dilution = Convert.ToSingle(var[8].Replace(".", separator));
            else this.dilution = 0;
            if(var[9] != "")
                this.altitude = Convert.ToSingle(var[9].Replace(".",separator)); 
            else this.altitude = 0;
            if (var[10].Equals(""))
                this.altUnit = '\0';
            else this.altUnit = char.Parse(var[10]);
            if (var[11] != "")
                this.geoidal = Convert.ToSingle(var[11].Replace(".", separator));
            else this.geoidal = 0;
            if(var[12].Equals(""))
                this.geoUnit = '\0';
            else this.geoUnit = char.Parse(var[12]);
            if (var[13] == "0.0" || var[13] == "")
                this.dGPSTime = new DateTime();
            else this.dGPSTime = new DateTime(year, month, day, int.Parse(var[13].Substring(0, 2)), int.Parse(var[13].Substring(2, 2)), int.Parse(var[13].Substring(4, 2)), int.Parse(var[13].Substring(7, 3)));
            if (var[14].Length > 3)
                this.stationRef = var[14].Substring(0, 4);
            else this.stationRef = "0000";
            this.checksum = var[14].Substring(var[14].Length - 2, 2);
        }
        #endregion

        /// <summary>
        /// Print informations of an ObjectGPGGA
        /// </summary>
        /// <param name="p">Object to string</param>
        public static void printGPGGA(ObjectGPGGA p)
        {
            Console.WriteLine(p.type + "  -  " + p.timeUTC + "  -  " + p.latitude + "  -  " + p.longitude + "  -  " + p.gpsQuality + "  -  " + p.nSat + "  -  " +
               p.dilution + "  -  " + p.altitude + "  -  " + p.altUnit + "  -  " + p.geoidal + "  -  " + p.geoUnit + "  -  " + p.dGPSTime + "  -  " + p.stationRef + "  -  " + p.checksum);
        }
    }
    #endregion
}