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
    class ObjectGP
    {
        public ObjectGP()
        {

         
        }

        public string toLatitude(string lat)
        {
            if (lat != "")
            {
                int deg = int.Parse(lat.Substring(0, 2));
                int min = int.Parse(lat.Substring(2, 2));
                float sec = float.Parse(lat.Substring(5, 4))*6/1000;
                
                return deg+"°"+min+"'"+sec+"\"";
            }
            else return "\0";
        }

        public string toLongitude(string lon)
        {
            if (lon != "")
            {
                int deg = int.Parse(lon.Substring(0, 3));
                int min = int.Parse(lon.Substring(3, 2));
                float sec = float.Parse(lon.Substring(6, 4)) * 6 / 1000;

                return deg+"°"+min+"'"+sec+"\"";
            }
            else return "\0";
        }

    }
}
