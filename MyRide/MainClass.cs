using System;
using Passengers;
using Admins;
using Drivers;
using Locations;
using Rides;
using Vehicles;

namespace MyRide
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine(" MAIN MENU ");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("                              WELLCOME TO MYRIDE                                     ");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("1. Book a Ride");
                Console.WriteLine("2. Enter as Driver");
                Console.WriteLine("3. Enter as Admin");
                Console.WriteLine("4. To Exit");
                Console.WriteLine();
                Console.Write("Press 1 to 3 to select an option:");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1 || choice == 2 || choice == 3 || choice == 4)
                {
                    Admin admin = new Admin();

                    if (choice == 1)
                    {
                        Console.WriteLine("Book a Ride ");
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();


                        Console.Write("Enter Phone no: ");
                        string phoneNo = Console.ReadLine();
                        Passenger passenger = new Passenger
                        {
                            PassengerName = name,
                            PhoneNumber = phoneNo
                        };
                       

                       

                        Console.Write("Enter Start Location: ");
                        float startLatitude = float.Parse(Console.ReadLine());
                        Console.Write(",");
                        float startLongitude = float.Parse(Console.ReadLine());
                        Location startLocation = new Location();
                        startLocation.setLocation(startLatitude, startLongitude);


                        Console.WriteLine("Enter End Location: ");
                        float endLatitude = float.Parse(Console.ReadLine());
                        Console.Write(",");
                        float endLongitude = float.Parse(Console.ReadLine());
                        Location endLocation = new Location();
                        endLocation.setLocation(endLatitude, endLongitude);


                        Console.Write("Enter Ride Type: ");
                        string rideType = Console.ReadLine();
                        List<Driver> drivers = admin.getList();
                        Ride ride = new Ride();
                        ride.setLocations(startLocation, endLocation);
                        ride.assignPassenger(passenger);
                        List<Driver> updateDrivers = ride.assignDriver(rideType, drivers);
                        admin.updateDriverList(updateDrivers);
                        Console.WriteLine("--------------------THANK YOU--------------------");
                    }

                    if (choice == 2)
                    {
                        int yourChoice;
                        Console.WriteLine("Enter as Driver: ");
                        Console.Write("Enter Your Phone Number : ");
                        string phoneNo = Console.ReadLine();
                        if (admin.searchDriver(phoneNo))
                        {
                            Console.WriteLine("1. Change Availability");
                            Console.WriteLine("2. Change Location");
                            Console.WriteLine("3. To Exit");
                            Console.WriteLine();
                            Console.Write("Press 1 to 3 to select an option:");
                            yourChoice = int.Parse(Console.ReadLine());
                            if (yourChoice == 1 || yourChoice == 2 || yourChoice == 3)
                            {
                                if (yourChoice == 1)
                                {
                                    Console.WriteLine("Enter your Availability");
                                    bool availability = bool.Parse(Console.ReadLine());
                                    admin.changeAvailability(phoneNo, availability);
                                }
                                if (yourChoice == 2)
                                {

                                    Console.Write("Enter current Location: ");
                                    float curr_Latitude = float.Parse(Console.ReadLine());
                                    Console.Write(",");
                                    float curr_Longitude = float.Parse(Console.ReadLine());
                                    Location curr_Location = new Location();
                                    curr_Location.setLocation(curr_Latitude, curr_Longitude);
                                    admin.changeLocation(phoneNo, curr_Location);
                                }
                                if (yourChoice == 3)
                                {
                                    continue;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Invalid choice. Please enter a number from 1 to 3.");
                            }

                        }
                    }
                    if (choice == 3)
                    {
                        int yourChoice;
                        do
                        {
                            Console.WriteLine("Enter as Admin: ");
                            Console.WriteLine("1. Add Driver");
                            Console.WriteLine("2. Remove Driver");
                            Console.WriteLine("3. Update Driver");
                            Console.WriteLine("4. Search Driver");
                            Console.WriteLine("5. Exit as Admin");
                            yourChoice = int.Parse(Console.ReadLine());
                            if (yourChoice == 1 || yourChoice == 2 || yourChoice == 3 || yourChoice == 4 || yourChoice == 5)
                            {

                                if (yourChoice == 1)
                                {
                                    Console.Write("Enter Driver's Name: ");
                                    string name = Console.ReadLine();


                                    Console.Write("Enter Driver's Age: ");
                                    int age = int.Parse(Console.ReadLine());


                                    Console.Write("Enter Driver's Gender: ");
                                    string gender = Console.ReadLine();


                                    Console.Write("Enter Driver's Address: ");
                                    string address = Console.ReadLine();


                                    Console.Write("Enter Driver's Phone Number: ");
                                    string phoneNo = Console.ReadLine();


                                    Console.Write("Enter current Location: ");
                                    float curr_Latitude = float.Parse(Console.ReadLine());
                                    Console.Write(",");
                                    float curr_Longitude = float.Parse(Console.ReadLine());
                                    Location curr_Location = new Location();
                                    curr_Location.setLocation(curr_Latitude, curr_Longitude);


                                    Console.Write("Enter Driver's Vehicle Type: ");
                                    string type = Console.ReadLine();

                                    Console.Write("Enter Driver's Vehicle Model: ");
                                    string model = Console.ReadLine();

                                    Console.Write("Enter Driver's Vehicle License Plate: ");
                                    string license_plate = Console.ReadLine();

                                    //Object Initializer Syntax.
                                    Vehicle vehicle = new Vehicle
                                    {
                                        VehicleType = type,
                                        VehicleModel = model,
                                        VehicleLicenseplate = license_plate
                                    };

                                    Console.Write("Enter Driver's availability: ");
                                    bool availability = bool.Parse(Console.ReadLine());

                                    Driver driver = new Driver
                                    {
                                        DriverName = name,
                                        DriverAge = age,
                                        DriverGender = gender,
                                        DriverAddress = address,
                                        DriverPhoneNumber = phoneNo,
                                        DriverLocation = curr_Location,
                                        DriverVehicle = vehicle,
                                        DriverRating = 0,
                                        DriverAvailability = availability
                                    };
                                    admin.addDriver(driver);
                                    admin.displayDrivers();

                                }
                                if (yourChoice == 2)
                                {
                                    Console.Write("Enter Phone no, So that you can remove the Driver  : ");
                                    string phoneNo = Console.ReadLine();
                                    admin.removeDriver(phoneNo);
                                }
                                if (yourChoice == 3)
                                {

                                    Console.Write("Enter Phone Number of Driver, Whose data you wants to update : ");
                                    string contact = Console.ReadLine();


                                    Console.Write("Enter Driver's Name: ");
                                    string name = Console.ReadLine();


                                    Console.Write("Enter Driver's Age: ");
                                    int age = int.Parse(Console.ReadLine());


                                    Console.Write("Enter Driver's Gender: ");
                                    string gender = Console.ReadLine();


                                    Console.Write("Enter Driver's Address: ");
                                    string address = Console.ReadLine();


                                    Console.Write("Enter Driver's Phone Number: ");
                                    string phoneNo = Console.ReadLine();


                                    Console.Write("Enter current Location: ");
                                    float curr_Latitude = float.Parse(Console.ReadLine());
                                    Console.Write(",");
                                    float curr_Longitude = float.Parse(Console.ReadLine());
                                    Location curr_Location = new Location();
                                    curr_Location.setLocation(curr_Latitude, curr_Longitude);


                                    Console.Write("Enter Driver's Vehicle Type: ");
                                    string type = Console.ReadLine();

                                    Console.Write("Enter Driver's Vehicle Model: ");
                                    string model = Console.ReadLine();

                                    Console.Write("Enter Driver's Vehicle License Plate: ");
                                    string license_plate = Console.ReadLine();

                                    //Object Initializer Syntax.
                                    Vehicle vehicle = new Vehicle
                                    {
                                        VehicleType = type,
                                        VehicleModel = model,
                                        VehicleLicenseplate = license_plate
                                    };

                                    Console.Write("Enter Driver's availability: ");
                                    bool availability = bool.Parse(Console.ReadLine());

                                    Driver driver = new Driver
                                    {
                                        DriverName = name,
                                        DriverAge = age,
                                        DriverGender = gender,
                                        DriverAddress = address,
                                        DriverPhoneNumber = phoneNo,
                                        DriverLocation = curr_Location,
                                        DriverVehicle = vehicle,
                                        DriverRating = 0,
                                        DriverAvailability = availability
                                    };
                                    admin.updateDriver(contact, driver);
                                    admin.displayDrivers();
                                }
                                if (yourChoice == 4)
                                {
                                    Console.Write("Enter Phone no to search the specific driver : ");
                                    string phoneNo = Console.ReadLine();
                                    admin.searchDriver(phoneNo);
                                }
                                if (yourChoice == 5)
                                {
                                    
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                              
                            }

                        } while (true);


                    }
                    if(choice == 4)
                    {
                        continue;
                    }
                }
                else
                {

                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
                   
                }

            } while (true);
        }
    
    }
}