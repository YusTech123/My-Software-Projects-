using System;
namespace UniCourseWork
{

    using System.Collections.Generic;

    using System;

    namespace UniCourseWork
    {
        //Represents the interface for booking's overlap check 
        public interface IOverlappable
        {
            //Method to check if this booing overlaps with another booking 
            bool Overlaps(Booking other);
        }

        public class Booking : IOverlappable
        {
            //Property representing the check-in date of the booking 
            public DateTime CheckInDate { get; set; }
            // Property representing the check-out date of the booking 
            public DateTime CheckOutDate { get; set; }

          // Method to check if this booking overlaps with another booking
            public bool Overlaps(Booking other)
            {
                //// Check if the check-in date is earlier than the other booking's check-out date
                // and the check-out date is later than the other booking's check-in date
                return (CheckInDate < other.CheckOutDate && CheckOutDate > other.CheckInDate);
            }
        }
    }
}


