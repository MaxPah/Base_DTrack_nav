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

    /// <summary>
    /// 
    /// </summary>
    class ObjectGPGGA : ObjectGP
    {
        string timeUTC;
        string latitude;
        char posNorS;
        string longitude;
        char posEorW;
        byte gpsQuality;
        byte nSat;
        string dilution;
        string altitude;
        char altUnit;
        string geoidal;
        char geoUnit;
        string dGPSTime;
        string stationRef;
        // bool checksum; 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="var"></param>
        public ObjectGPGGA(string[] var)
        {
            this.timeUTC = var[1];
            this.latitude = var[2];
           /* if( var[3] == "N")
                posNorS = 'N';
            else posNorS ='S';*/

            this.posNorS = char.Parse(var[3]);
            this.longitude = var[4];
            this.posEorW = char.Parse(var[5]);
            this.gpsQuality = byte.Parse(var[6]);
            this.nSat = byte.Parse(var[7]);
            this.dilution = var[8];
            this.altitude = var[9];
            this.altUnit = char.Parse(var[10]);
            this.geoidal = var[11];
            this.geoUnit = char.Parse(var[12]);
            this.dGPSTime = var[13];
            this.stationRef = var[14];
            // bool checksum = var[]; 

        }
    }
}