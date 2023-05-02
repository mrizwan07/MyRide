using System;

namespace Locations
{
    public class Location
    {
        float latitude;
        float longitude;

        //Functions
        public float LocationLatitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
        public float LocationLongitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        public void setLocation(float latitude, float longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
     }       
}