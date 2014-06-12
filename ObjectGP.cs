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
    #region ObjectGP class
    /// <summary>
    /// ObjectGP father of ObjectGPGGA and Object GPRMC
    /// </summary>
    class ObjectGP
    {
        #region ObjectGP Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ObjectGP()
        {     
        }
        #endregion

        /// <summary>
        /// Used to initilize latitude from string parameter
        /// </summary>
        /// <param name="lat">string to latitude</param>
        /// <returns>latitude</returns>
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

        /// <summary>
        /// Used to initilize longitude from string parameter
        /// </summary>
        /// <param name="lon">string to latitude</param>
        /// <returns>longitude</returns>
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

        /// <summary>
        /// Used to print every element of the list in function's parameter
        /// </summary>
        /// <param name="list">list of Object element (ObjectGPGGA or ObjectGPRMC)</param>
        public static void printData(List<Object> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ToString().Contains("GPGGA"))
                   Base_DTrack_Nav.ObjectGPGGA.printGPGGA((ObjectGPGGA)list[i]);
                else if (list[i].ToString().Contains("GPRMC"))
                    Base_DTrack_Nav.ObjectGPRMC.printGPRMC((ObjectGPRMC)list[i]);
            }
        }
    }
        #endregion
}
