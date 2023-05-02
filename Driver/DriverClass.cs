using System;
using Locations;
using Vehicles;
using System.Collections.Generic;
using System.Data.Common;

namespace Drivers
{
    public class Driver
    {
        string name;
        int age;
        string gender;
        string address;
        string phoneNumber;
        Location curr_location;
        Vehicle vehicle;
       public  List<int> rating = new List<int>();
        bool availability;

        //Functions
        public string DriverName
        {
            get { return name; }
            set { name = value; }

        }
        public int DriverAge
        { 
            get { return age; } 
            set { age = value; } 
        }
        public string DriverGender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string DriverAddress
        {
            get { return address; }
            set { address = value; }
        }
        public string DriverPhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public bool DriverAvailability
        {
            get { return availability; }
            set { availability = value; }
        }
        public Location DriverLocation
        {
            get { return curr_location; }
            set { curr_location = value; }
        }
        public Vehicle DriverVehicle
        {
            get { return vehicle; }
            set { vehicle = value; }
        }
        public int DriverRating
        {
            get
            {
                int sumOfAllRating = 0;
                int count = 0;
                foreach (int rat in rating)
                {
                    sumOfAllRating = sumOfAllRating + rat;
                    count++;
                }
                return (int)sumOfAllRating / count;
            }
            set
            {
                rating.Add(value);
            }
        }
        public void updateAvailability(bool availability)
        {
            this.availability = availability;
        }
        public int getRating()
        {
            int sumOfAllRating = 0;
            int count = 0;
            foreach (int rat in rating)
            {
                sumOfAllRating = sumOfAllRating + rat;
                count++;
            }
            return (int)sumOfAllRating / count;
        }
        public void updateLocation(Location location)
        {
            this.curr_location = location;

        }

    }
}