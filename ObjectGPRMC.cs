using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base_DTrack_Nav
{
    #region ObjectGPRMC Class
    /// <summary>
    /// This is a decendant of ObjectGP used to initialize ObjectGPRMC with a trame
    /// </summary>
    class ObjectGPRMC : ObjectGP
    {
        #region fields
        public string type;
        public DateTime timeUTC;
        public char status;
        public string latitude;
        public string longitude;
        public double speed;
        public string cap;
        public DateTime date;
        public string magnetic;
        public string checksum;
        #endregion

        #region ObjectGPRMC Constructor
        /// <summary>
        /// ObjectGPRMC constructor
        /// </summary>
        /// <param name="var">Used to initialize an instance of ObjectGPRMC</param>
        public ObjectGPRMC(string[] var)
        {
            string separator = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;
            char a;
            this.type = "GPRMC";
            if (var[1] != "")
            {
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;
                int h = int.Parse(var[1].Substring(0, 2));
                int m = int.Parse(var[1].Substring(2, 2));
                int s = int.Parse(var[1].Substring(4, 2));
                int ms;
                if (var[1].Length > 6)
                    ms = int.Parse(var[1].Substring(7, 3));
                else ms = 0;
                this.timeUTC = new DateTime(year, month, day, h, m, s, ms);
            }
            else this.timeUTC = new DateTime(1, 1, 1);
            if (var[2] == "")
                this.status = '\0';
            else this.status = char.Parse(var[2]);
            if (var[3]!="")
                this.latitude = toLatitude(var[3]) + " "+ char.Parse(var[4]);
            else this.latitude = "0°0'0.0\" N";
            if (var[5] != "")
                this.longitude = toLongitude(var[5]) + " " + char.Parse(var[6]);
            else this.longitude = "0°0'0.0\" E";
            if (var[7] != "")
                this.speed = Convert.ToDouble(var[7].Replace(".", separator))*1.852;
            else this.speed = 0;
            if (var[8] != "")
                this.cap = var[8];
            else this.cap = "";
            if ( var[9] != "")
                this.date = new DateTime(int.Parse(var[9].Substring(4, 2))+2000,int.Parse(var[9].Substring(2,2)),int.Parse(var[9].Substring(0,2)));
            else this.date = new DateTime(1,1,1);
            if (var[11].Substring(0, 1) == "*")
                a = '\0';
            else a = char.Parse(var[11].Substring(0, 1));
            if (var[10] != "")
                this.magnetic = var[10]+a;
            else this.magnetic = ""+a;
            this.checksum = var[11].Substring(var[11].Length - 2 , 2);
        }
        #endregion
        
        /// <summary>
        /// Print informations of an ObjectGPGGA
        /// </summary>
        /// <param name="p">Object to string</param>
        public static void printGPRMC(ObjectGPRMC p)
        {
            Console.WriteLine(p.type + "  -  " + p.timeUTC + "  -  " + p.status + "  -  " + p.latitude + "  -  " + p.longitude + "  - km/h : " + p.speed + "  -  " + p.cap + "  -  " + p.date + "  -  " +
             p.magnetic + "  -  " + p.checksum);
        }
    }
        #endregion
}