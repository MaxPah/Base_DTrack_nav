using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base_DTrack_Nav
{

    class ObjectGPRMC : ObjectGP
    {

        public string type;
        public DateTime timeUTC;
        public char status;
        public string latitude;
        public string longitude;
        public string speed;
        public string cap;
        public DateTime date;
        public string magnetic;
        public char posEorWMagnetic;
        public string checksum; 


        public ObjectGPRMC(string[] var)
        {
            string separator = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;

            this.type = "GPRMC";
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;
                int h = int.Parse(var[1].Substring(0, 2));
                int m = int.Parse(var[1].Substring(2, 2));
                int s = int.Parse(var[1].Substring(4, 2));
                int ms = int.Parse(var[1].Substring(7, 3));
            this.timeUTC = new DateTime(year, month, day, h, m, s, ms);
            if (var[2] == "")
                this.status = '\0';
            this.status = char.Parse(var[2]);
            this.latitude = toLatitude(var[3]) + " "+ char.Parse(var[4]);
            this.longitude = toLongitude(var[5]) + "" + char.Parse(var[6]);
            this.speed = var[7];
            this.cap = var[8];
            this.date = new DateTime(int.Parse(var[9].Substring(4, 2))+2000,int.Parse(var[9].Substring(2,2)),int.Parse(var[9].Substring(0,2)));
            this.magnetic = var[10];
            if (var[11].Substring(0, 1) == "*")
                this.posEorWMagnetic = '\0';
                  
            else this.posEorWMagnetic = char.Parse(var[11].Substring(0, 1));
            this.checksum = var[11].Substring(var[11].Length - 2 , 2);

        }
    }
}