using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base_DTrack_Nav
{
   

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


        public ObjectGPRMC(string[] var){
        this.timeUTC = var[1];
        if(var[2].Equals("V"))
            this.status  ='V';
        else this.status = 'A';
        this.latitude = var[3];

        if(var[4].Equals("N"))
            this.posNorS  ='N';
        else this.posNorS = 'S';

        this.longitude = var[5];

        if (var[6].Equals("E"))
            this.posEorW = 'E';
        else this.posEorW = 'W';

        this.speed = var[7];
        this.cap = var[8];
        this.date = var[9];
        this.magnetic = var[10];

        if (var[11].Equals("E"))
            this.posEorWMagnetic = 'E';
        else this.posEorWMagnetic = 'W';
        //this checksum; 

        }
    }
}