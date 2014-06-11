﻿//----------------------------------------------------------------------------- 
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

    /// <summary>
    /// 
    /// </summary>
    class ObjectGPGGA : ObjectGP
    {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="var"></param>
        public ObjectGPGGA(string[] var)
        {
            string separator = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;

            this.type = "GPGGA";
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;
                int h = int.Parse(var[1].Substring(0, 2));
                int m = int.Parse(var[1].Substring(2, 2));
                int s = int.Parse(var[1].Substring(4, 2));
                int ms = int.Parse(var[1].Substring(7, 3));
                this.timeUTC = new DateTime(year,month,day,h,m,s,ms);
                this.latitude = toLatitude(var[2]) + " " + char.Parse(var[3]); ;
                this.longitude = toLongitude(var[4]) + " " + char.Parse(var[5]);
                this.gpsQuality = byte.Parse(var[6]);
                this.nSat = byte.Parse(var[7]);
                if (var[8] != string.Empty || var[8] != "")
                    this.dilution = Convert.ToSingle(var[8].Replace(".", separator));
                else this.dilution = 0;
                this.altitude = Convert.ToSingle(var[9].Replace(".",separator)); 
            
            if (var[10].Equals(""))
                this.altUnit = '\0';
            else this.altUnit = char.Parse(var[10]);

            this.geoidal = Convert.ToSingle(var[11].Replace(".", separator));
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
    }
}