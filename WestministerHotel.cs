using System;
using System.Collections.Generic;
using System.Drawing;

namespace UniCourseWork
{
    public class WestministerHotel : IHotelManager, IHotelCustomer
    {
        // Key is Room Number and value is the Room object.
        private Dictionary<int, Room> roomsDict;

        public WestministerHotel()
        {
            // Initialize the dictionary to store rooms
            roomsDict = new Dictionary<int, Room>();
            //// Add some rooms to the hotel
            this.AddRoom(new StandardRoom(1, 1, Size.Single, 15, 10));
            this.AddRoom(new StandardRoom(2, 1, Size.Double, 20, 5));
            this.AddRoom(new DeluxeRoom(3, 2, Size.Double, 25, 5.5, View.Seaview));
            this.AddRoom(new DeluxeRoom(4, 2, Size.Triple, 35, 10.2, View.Mountain_View));

        }

        // // Method to add a room to the hotel
        public bool AddRoom(Room room)
        {
            // Check if the room number already exists in the dictionary
            if (roomsDict.ContainsKey(room.getNumber()))
            {
                // Return false if the room number already exists
                return false;
            }
            // // Add the room to the dictionary
            roomsDict.Add(room.getNumber(), room);
            return true;


        }
        // Method to book a room
        public bool BookRoom(int roomNumber, Booking wantedBooking)
        {
            // Check if the room number exists in the dictionary
            if (!roomsDict.TryGetValue(roomNumber, out var room))
            {
                // Return false if the room number does not exist
                return false;
            }
            // else room variable will contain the room object


            Room roomm= roomsDict[roomNumber];
            // Try to add the booking to the room
            return room.addBooking(wantedBooking);
        }

        // // Method to delete a room from the hotel
        public bool DeleteRoom(int roomNumber)
        {
            // Remove the room from the dictionary and return true if successful
            return roomsDict.Remove(roomNumber);
        }
        // Method to generate a report of all rooms and their bookings
        public void GenerateReport(string fileName)
        {
            // Convert the dictionary values to a list
            List<Room> roomsList = roomsDict.Values.ToList();
            // Get the path to the desktop
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // Print the path to the console
            Console.WriteLine(path);
            // Append the file name to the path
            fileName = path + "/" + fileName + ".txt";
            // Open the file for writing and append to it
            using (StreamWriter sw = File.AppendText(fileName))
            {
                // Write the room and booking information to the file for each
                foreach (var room in roomsList)
                {
                    sw.WriteLine(room.roomInfoString());
                    sw.WriteLine(room.bookingInfoString());
                }
            }
        }
        //// Method to list all available rooms that match the given size and do not overlap with the given booking
        public void ListAvailableRooms(Booking wantedBooking, Size roomSize)
        {
            // Get a list of all rooms in the hotel
            List<Room> roomsList = roomsDict.Values.ToList();
            // Initialize a counter to keep track of the number of available rooms
            int counter = 0;
            // Iterate through all rooms in the list
            foreach (Room room in roomsList)
            {
                // Check if the size of the room matches the given size and if the booking overlaps with the room
                if (room.getSize() != roomSize || room.checkIfBookingOverlaps(wantedBooking))
                {
                    // If either of the conditions is not met, skip the current
                    continue;
                }
                // Print the room information 
                Console.WriteLine(room.roomInfoString());
                //Increment the counter 
                counter++;
            }
            // if the counter is 0, it means no rooms were available
            if (counter == 0)
            {
                Console.WriteLine("No rooms available.");

            }

        }
        // // Method to list all available rooms that match the given size, price and do not overlap with the given booking
        public void ListAvailableRooms(Booking wantedBooking, Size roomSize, int maxPrice)
        {
            //Get a list of all rooms in the hotel 
            List<Room> roomsList = roomsDict.Values.ToList();
            // Sort the rooms by price
            roomsList.Sort((x, y) => x.getPrice().CompareTo(y.getPrice()));
            // Iterate through all rooms in the list
            foreach (Room room in roomsList)
            {
                // Check if the size of the room matches the given size, if the room price is less than maxPrice and if the booking overlaps with the room
                if (room.getSize() != roomSize || room.getPrice() >= maxPrice || room.checkIfBookingOverlaps(wantedBooking))
                {
                    // If any of the conditions is not met, skip the current room
                    continue;
                }
                //Print out the information
                Console.WriteLine(room.roomInfoString());
            }
        }

        // Method to list all rooms in the hotel
        public void ListRooms()
        {
            // Get a list of all rooms in the hotel
            List<Room> roomsList = roomsDict.Values.ToList();
            // Iterate through all rooms in the list
            foreach (var room in roomsList)
            {
                // print the room information 
                Console.WriteLine(room.roomInfoString());
                // Print the booking information of the room 
                Console.WriteLine(room.bookingInfoString());
            }
        }

        // Method to list all rooms in the hotel ordered by price
        public void ListRoomsOrderedByPrice()
        {
            // Get a list of all rooms in the hotel
            List<Room> roomsList = roomsDict.Values.ToList();
            // Sort the rooms by price
            roomsList.Sort();
            // Iterate through all rooms in the list
            foreach (var room in roomsList)
            {
                // Print the room information
                Console.WriteLine(room.roomInfoString());
                // Print the booking information of the room
                Console.WriteLine(room.bookingInfoString());
            }

        }

    }
}

