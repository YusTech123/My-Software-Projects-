using System;
namespace UniCourseWork
{

	public enum Size { Single=0, Double=1, Triple=2};

	public class Room : IComparable
    {
	
        private int floor; // store room floor 
        private int number; //store room number 
        private int price; // store room price 
        private Size size; // store room size 
        private List<Booking> bookings; // list of bookings of the room 

        // constructor to intialize room details 
        public Room(int number, int floor, Size size, int price)
		{
            this.number = number;
            this.floor = floor;
            this.size = size;
            this.price = price;
            bookings = new List<Booking>();
        }
        // function to return the room details in string format 
        public virtual String roomInfoString()
        {
            String info = "Room " + this.getNumber() + ", Floor " + this.getFloor() + ", Size = "
                + this.getSize() + ", Price (per night) = " + this.getPrice();

            
            return info;
            
        }

        public String bookingInfoString()
        {
            String bookingInfo = "Bookings Count: " + this.bookings.Count + "\n";
            int counter = 1;
            // loop through the bookings of the room 
            int i = 0;
            while (i < this.bookings.Count)
            {
                var booking = this.bookings[i];
                
                i++;
                // append each booking details to the final booking detils string 
             bookingInfo = bookingInfo + "Booking " + i + " =>    " +
                    booking.printInfo() + "\n";

                
            }

            return bookingInfo;

        }

        //function to add new booking to the room 
        public bool addBooking(Booking wantedBooking)
        {
            // check if the new booking overlap with existing  bookings 
            if (this.checkIfBookingOverlaps(wantedBooking))
            {
                Console.WriteLine("Sorry, the room is not available for the requested dates due to a conflicting booking.");
                return false;
            }

            bookings.Add(wantedBooking);
            Console.WriteLine("Room No " + this.getNumber() + " has been booked from " + wantedBooking.getCheckIn()
                + " to " + wantedBooking.getCheckOut() + "\n");
            
            return true;
        }
        // function to check if the new booking overlaps with exsting bookings 
        public bool checkIfBookingOverlaps(Booking wantedBooking)
        {
            int i = 0;
            while (i < this.bookings.Count)
            {
                var booking = this.bookings[i];

                i++;
                // call the 'Overlaps' function of the booking class to check if the new booking overlaps with existing bookings 
                if (wantedBooking.Overlaps(booking))
                {
                    return true;
                }
            }
            return false;
        }
        // Getter function to get the room number 
        public int getFloor()
        {
            return this.floor;
		}
        public int getNumber()
        {
            return this.number;
        }
        public int getPrice()
        {
            return this.price;
        }
        public Size getSize()
        {
            return this.size;
        }


        public int CompareTo(Room other)
        {
            return other.getPrice().CompareTo(this.getPrice());
        }

        public int CompareTo(object? obj)
        {
            Room? room = obj as Room;
            return room.getPrice().CompareTo(this.getPrice());
        }
    }
}

