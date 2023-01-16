using System;
namespace UniCourseWork
{
    // interface for the Hotel Manager 
	public interface IHotelManager
	{
        //Method to add a room 
        bool AddRoom(Room room);
        //Method to delete a room 
        bool DeleteRoom(int roomNumber);
        //Method to list all rooms 
        void ListRooms();
        // Method to list rooms ordered by price 
        void ListRoomsOrderedByPrice();
        //method to generate a report 
        void GenerateReport(string fileName);

    }
}

