using System;

namespace Passengers
{
    public class Passenger
    {
        string name;
        string phoneNumber;
        //Functions
        public string PassengerName
        {
            get { return name; }
            set { name = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
    }
}
