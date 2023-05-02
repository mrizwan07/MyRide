using System;
using Drivers;
using System.Collections.Generic;
using Locations;

namespace Admins
{
    public class Admin
    {
       public  List<Driver> drivers = new List<Driver>();
        //Function
        public List<Driver> getList()
        {
            return drivers;
        }
        public void addDriver(Driver addDriver)
        {
            foreach(Driver driver in drivers)
            {
                if(driver.DriverPhoneNumber==addDriver.DriverPhoneNumber)
                {
                    //Console.WriteLine(driver.DriverPhoneNumber);
                    return;
                }
            }
            drivers.Add(addDriver);
        }

        public void updateDriver(string phoneNo ,Driver updateDriver)
        {
            foreach(Driver driver in drivers)
            {
                if(driver.DriverPhoneNumber==phoneNo)
                {
                    Console.WriteLine("Now in update method");
                    driver.DriverName = updateDriver.DriverName;
                    driver.DriverAge=updateDriver.DriverAge;
                    driver.DriverGender=updateDriver.DriverGender;
                    driver.DriverAddress=updateDriver.DriverAddress;
                    driver.DriverPhoneNumber = updateDriver.DriverPhoneNumber;
                    driver.DriverLocation=updateDriver.DriverLocation;
                    driver.DriverVehicle=updateDriver.DriverVehicle;
                    driver.DriverAvailability=updateDriver.DriverAvailability;
                }
            }
        }
        public void removeDriver(string phoneNo)
        {
            int index = -1;
            foreach( Driver driver in drivers)
            {
                index++;
                if(driver.DriverPhoneNumber==phoneNo)
                {
                    Console.WriteLine("Here i am removing");
                    // Shifting elements
                    for (int i = index; i < drivers.Count-1; i++)
                    {
                        drivers[i] = drivers[i + 1];
                    }
                }
            }
        }
        public bool searchDriver(string phoneNo)
        {
            foreach (Driver driver in drivers)
            {
                if (driver.DriverPhoneNumber == phoneNo)
                {
                  Console.WriteLine("------------------------------------------------------------------------------------------------------");
                  Console.WriteLine("Name        Age        Gender        V.Type        V.Model        V.License");
                  Console.WriteLine("------------------------------------------------------------------------------------------------------");
                  Console.WriteLine(driver.DriverName+"        "+driver.DriverAge+"        "+driver.DriverGender+"        "+driver.DriverVehicle.VehicleType+"        "+
                  driver.DriverVehicle.VehicleModel+"        "+driver.DriverVehicle.VehicleLicenseplate);
                  Console.WriteLine("------------------------------------------------------------------------------------------------------");
                    return true;
                }
            }
            return false;
        }
        public void changeAvailability(string phoneNo,bool availability)
        {
            foreach (Driver driver in drivers)
            {
                if (driver.DriverPhoneNumber == phoneNo)
                {
                    driver.updateAvailability(availability);   
                }
            }
        }
        public void changeLocation(string phoneNo,Location location)
        {
            foreach (Driver driver in drivers)
            {
                if (driver.DriverPhoneNumber == phoneNo)
                {
                    driver.updateLocation(location);
                }
            }
        }
        public void displayDrivers()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------The Data of Driver is-------------------- :");
            Console.WriteLine();
            foreach (Driver driver in drivers)
            {
                Console.WriteLine("The name of Driver is  "+  driver.DriverName);
                Console.WriteLine("The age of Driver is  "+ driver.DriverAge);
                Console.WriteLine("The gender of Driver is  "+ driver.DriverGender);

                //1)  String Concatination:
                Console.WriteLine("The address of Driver is  "+ driver.DriverAddress);

                //OR
                //2)  Interpolated String:
                //Console.WriteLine($"The address of Driver is {driver.DriverAddress});
                Console.WriteLine("The phone number of Driver is  "+ driver.DriverPhoneNumber);
                Console.WriteLine("The availability of Driver is  "+ driver.DriverAvailability);
                Console.WriteLine("The rating of Driver is  "+ driver.getRating());
                Console.WriteLine("The vehicle type of Driver is  "+ driver.DriverVehicle.VehicleType);
                Console.WriteLine("The vehicle model of Driver is  "+ driver.DriverVehicle.VehicleModel);
                Console.WriteLine("The vehicle license plate of Driver is  "+ driver.DriverVehicle.VehicleLicenseplate);
                Console.WriteLine("The current location of Driver is  {"+ driver.DriverLocation.LocationLatitude + "," + driver.DriverLocation.LocationLongitude +"}");
            }

        }
        public void updateDriverList(List<Driver> updatedDrivers)
        {
            for(int i = 0; i < drivers.Count; i++)
            {
                drivers[i] = updatedDrivers[i];
            }
        }
    }
}