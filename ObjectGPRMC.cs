using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base_DTrack_Nav
{

    class ObjectGPRMC : ObjectGP
    {
        DateTime timeUTC;
        char status;
        public string latitude;
        public string longitude;
        string speed;
        string cap;
        string date;
        string magnetic;
        char posEorWMagnetic;
        //string checksum; 


        public ObjectGPRMC(string[] var)
        {
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;
                int h = int.Parse(var[1].Substring(0, 2));
                int m = int.Parse(var[1].Substring(2, 2));
                int s = int.Parse(var[1].Substring(4, 2));
                int ms = int.Parse(var[1].Substring(7, 3));
            this.timeUTC = new DateTime(year, month, day, h, m, s, ms);
           
            this.status = char.Parse(var[2]);
            this.latitude = toLatitude(var[3]) + " "+ char.Parse(var[4]);
            this.longitude = toLongitude(var[5]) + "" + char.Parse(var[6]);

            this.speed = var[7];
            this.cap = var[8];
            this.date = var[9];
            this.magnetic = var[10];
            if (var[11].Substring(0, 1) == "*")
                this.posEorWMagnetic = '\0';
            else this.posEorWMagnetic = char.Parse(var[11].Substring(0, 1));
            //this.checksum = var[12]; 

        }
    }
}