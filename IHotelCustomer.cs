using System;
using System.Drawing;

namespace UniCourseWork
{
    //// Interface for the hotel customer
    public interface IHotelCustomer
	{
        // Method to list all available rooms that match the given size and do not overlap with the given booking
        void ListAvailableRooms(Booking wantedBooking, Size roomSize);
        
        // Method to list all available rooms that match the given size, do not overlap with the given booking and are within the given price range
        void ListAvailableRooms(Booking wantedBooking, Size roomSize, int maxPrice);
        
        // Method to book a room with the given room number and booking details
        bool BookRoom(int roomNumber, Booking wantedBooking);
    }
}

