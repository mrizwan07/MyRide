using System;

namespace Vehicles
{
   public class Vehicle
    {
        string type;
        string model;
        string license_plate;

        //Functions
        public string VehicleType
        {
            get { return type; }
            set { type = value; }
        }
        public string VehicleModel
        {
            get { return model; }
            set { model = value; }
        }
        public string VehicleLicenseplate
        {
            get { return license_plate; }
            set { license_plate = value; }
        }

    }
}