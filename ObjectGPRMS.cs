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
    class ObjectGPRMC : ObjectGP
    {
        string timeUTC;
        char status;
        string latitude;
        char posNorS;
        string longitude;
        char posEorW;
        string speed;
        string cap;
        string date;
        string magnetic;
        char posEorWMagnetic;
       // bool checksum; 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="var"></param>
        public ObjectGPRMC(string[] var){

        this.timeUTC = var[1];
        this.status = char.Parse(var[2]);
        this.latitude = var[3];
        this.posNorS = char.Parse(var[4]);
        this.longitude = var[5];
        this.posEorW = char.Parse(var[6]);
        this.speed = var[7];
        this.cap = var[8];
        this.date = var[9];
        this.magnetic = var[10];
        if(var[11].Substring(0,1) == "*")
            this.posEorWMagnetic = ' ';
        else this.posEorWMagnetic = char.Parse(var[11].Substring(0,1));
        //this checksum; 

        }
    }
}