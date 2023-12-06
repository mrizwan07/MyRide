using System;
using Locations;
using Drivers;
using Passengers;
using Admins;
using System.Data.Common;
using System.Collections.Generic;
//Rides Class
namespace Rides
{
    public class Ride
    {
        Location start_location;
        Location end_location;
        int price;
        Driver driver;
        Passenger passenger;

        //Functions
        public Location RideStartLocation
        {
            get { return start_location; }
            set { start_location = value; }
        }
        public Location RideEndLocation
        {
            get { return end_location; }
            set{ end_location = value; }
        }
        public int RidePrice
        {
            get { return price; }
            set { price = value; }
        }
        public Driver RideDriver
        {
            get { return driver; }
            set { driver = value; }
        }
        public Passenger RidePassenger
        {
            get { return passenger; }
            set { passenger = value; }
        }
      
        public void assignPassenger(Passenger newPassenger)


        {
            this.passenger = newPassenger;
        }
        public List<Driver> assignDriver(string vehicleType, List<Driver> drivers)
        {
            float minimumDistance = 0;
            Driver specificDriver=new Driver();
            foreach(Driver driver in drivers)
            {
                if(driver.DriverVehicle.VehicleType==vehicleType && driver.DriverAvailability==true)
                {
                    if (minimumDistance == 0)
                    {
                        //Eucilidean distance between Driver current location and Passenger start location
                        minimumDistance = (float)Math.Sqrt(((driver.DriverLocation.LocationLatitude - start_location.LocationLatitude) *
                             (driver.DriverLocation.LocationLatitude - start_location.LocationLatitude)) + ((driver.DriverLocation.LocationLongitude -
                             start_location.LocationLongitude) * (driver.DriverLocation.LocationLongitude -
                             start_location.LocationLongitude)));
                        specificDriver = driver;
                        Console.WriteLine("here now in to calculate distance");
                    }
                    else
                    {
                        float temp = 0;
                        //Eucilidean distance between Driver current location and Passenger start location 
                        temp = (float)Math.Sqrt(((driver.DriverLocation.LocationLatitude - start_location.LocationLatitude) *
                            (driver.DriverLocation.LocationLatitude - start_location.LocationLatitude)) + ((driver.DriverLocation.LocationLongitude -
                            start_location.LocationLongitude) * (driver.DriverLocation.LocationLongitude -
                            start_location.LocationLongitude)));
                        specificDriver = driver;
                        if (temp < minimumDistance)
                        {
                            minimumDistance=temp;
                            specificDriver = driver;
                        }
                    }
                }
            }
            calculatePrice(minimumDistance,vehicleType);
            Console.WriteLine("Price for this ride is:" + price);
            Console.WriteLine("Enter ‘Y’ if you want to Book the ride, enter ‘N’ if you want to cancel operation:");
            char choice=char.Parse(Console.ReadLine());
            if(choice == 'y'||choice=='Y')
            {
                foreach (Driver driver in drivers)
                {
                    if (driver.DriverPhoneNumber == specificDriver.DriverPhoneNumber)
                    {
                        driver.updateAvailability(false);
                    }
                }
                Console.Write("Give rating out of 5:");
                int rating = int.Parse(Console.ReadLine());
                specificDriver.DriverRating=rating;
            }
            return drivers;
        }
        public void setLocations(Location start,Location end)
        {
            this.start_location = start;
            this.end_location = end;
        }
        public void calculatePrice(float distance,string vehicleType)
        {
            if(vehicleType=="bike")
            {
                this.price = (int)(distance * 270) / 50;
                this.price = (int)(this.price + (this.price * 0.05));
            }
            if (vehicleType == "rickshaw")
            {
                this.price = (int)(distance * 270) / 35;
                this.price = (int)(this.price + (this.price * 0.1));
            }
            if (vehicleType == "car")
            {
                this.price = (int)(distance * 270) / 15;
                this.price = (int)(this.price + (this.price * 0.2));
            }
        }
        public void giveRating(int rating)
        {
            driver.rating.Add(rating);
        }

    }
}
