using System;
using System.Diagnostics.Metrics;

namespace UniCourseWork
{
	public class Booking : Overlapped
    {
		   DateTime checkIn;
          DateTime checkOut;

        //// constructor that accepts the checkin and checkout dates
        public Booking(DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                Console.WriteLine("The check-out date must be later than the check-in date. Please enter a valid check-out date:");
                checkOut = askForDate("Enter check-out date (in format DD/MM/YYYY):");
            }
            this.checkIn = checkIn;
            this.checkOut = checkOut;
        }

        private DateTime askForDate(string v)
        {
            throw new NotImplementedException();
        }

        // // getter method for check in date 
        public DateTime getCheckIn()
        {
            return checkIn.Date;
        }
        //// getter method for check out date 
        public DateTime getCheckOut()
        {
            return checkOut.Date;
        }
        // method to return a string representation of the booking
        public String printInfo()
        {
            return "Check-In Date: " + this.getCheckIn() + ",    Check-Out Date: " + this.getCheckOut();
        }
        //// method that checks if a given booking overlaps with the current one
        public bool Overlaps(Booking other)
        {
            /* Returns True if:
              the checkin date of Other booking is less than the checkout date of this booking, And 
              the checkout date of Other booking is greater than the checkin date of this booking.
           
            
             */

            if (other.getCheckIn() < this.getCheckOut() && other.getCheckOut() > this.getCheckIn())
            {
                return true;
            }
            return false;
        }
    }
}

