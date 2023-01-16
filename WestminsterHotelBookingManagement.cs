using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq.Expressions;


namespace UniCourseWork
{
    public static class WestminsterHotelBookingManagement
    {
        public static void Main(String[] args)
        {
            WestministerHotel hotel = new WestministerHotel();

            bool loop = false;

            while (loop == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor. White;
                Console.WriteLine("Welcome to Westminster Hotel Booking Management! Get ready to experience the ultimate luxury stay. What would you like to do today? \n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. View Available Rooms");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("2. Select from our Range of Attractive Rooms");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("3. View Rooms within your Price Range");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("4. Administration Portal");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("5. Exit\n");
                Console.ResetColor();
                Console.Write("Enter from the following Option: \n");
                int alt = Convert.ToInt32(Console.ReadLine()); 
                // create a loop to ensure that users input is not a string but it's a int value. 

                



                switch (alt)
                {
                    case 1:
                        Size size = askForSize();
                        Booking booking = askForBooking();

                        if (booking == null)
                        {
                            break;
                        }
                        //// declare a switch statement that references to a ask.forSize method ( either a singe, triple or deluxe room).
                        // if these conditions are met it will continue to AskforBooking Method. Check-in and Check-out
                        // It will prompt the user to pick either a single, double or deluxe room. 
                        // AskforBooking method will prompt the user to enter a Date and time. If this condition are met it will continue.
                        Console.WriteLine("We have something special waiting for you, View available rooms and pick the one that best suits your needs");
                        hotel.ListAvailableRooms(booking, size);
                        Console.WriteLine("\n");
                        break;
                    case 2:
                        Console.WriteLine("Please enter the Room number you would like to book, We are here to make your stay comfortable: (only digits):\n");
                        int roomNum = Convert.ToInt32(Console.ReadLine());
                        Booking booking1 = askForBooking();
                        // ...
                        if (booking1 == null)
                        {
                            continue;
                        }
                        hotel.BookRoom(roomNum, booking1);
                        break;
                    case 3:
                        Size roomsize = askForSize();
                        Booking book = askForBooking();

                        while (book == null)
                        {
                            continue;
                        }

                        Console.WriteLine("We want to ensure that you have a comfortable stay within your budget, Please enter your maximum budget: (only digits):\n");
                        int maxPrice = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Great news! Our rooms are ready for you to book and experience a comfortable stay ");
                        hotel.ListAvailableRooms(book, roomsize, maxPrice);
                        Console.WriteLine("\n");
                        break;

                    case 4:
                        adminMenu(hotel);
                        break;

                    case 5:
                        Console.WriteLine("Goodbye, we hope you had a pleasant experience.");
                        Console.WriteLine("   \r\n                        ██████        ██          ██        ██████                      \r\n                        ██  ████████    ██      ██    ████████  ██                      \r\n                      ██████        ██    ██  ██    ██        ██████                    \r\n                    ████              ██  ██████  ██              ████                  \r\n                    ██                  ██████████                  ██                  \r\n                  ██                      ██████                      ██                \r\n                ██          ██████        ██  ██        ██████          ██              \r\n              ██          ██  ██████    ████  ████    ██████  ██          ██            \r\n            ██          ██  ██      ██████      ██████      ██  ██          ██          \r\n          ████        ██    ██            ██████            ██    ██        ████        \r\n        ████          ██  ██                                  ██  ██          ████      \r\n      ██  ██        ██    ██                                  ██    ██        ██  ██    \r\n      ██                ██                                      ██                ██    \r\n    ████                  ██                                  ██                  ████  \r\n  ████                    ██  ░░    ░░              ░░      ░░██                    ████\r\n██  ██              ██      ██████████              ██████████      ██              ██  \r\n██  ██              ██                ████      ████                ██              ██  \r\n██    ██          ██                      ██  ██                      ██          ██  ██\r\n  ██    ██████  ██                          ██                          ██  ██████    ██\r\n  ██      ██                  ██████        ██        ██████                  ██      ██\r\n    ██      ██          ████████    ██      ██      ██    ████████          ██      ██  \r\n      ██      ██████████              ██    ██    ██              ██████████      ██    \r\n        ██        ██                    ████  ████                    ██        ██      "
);

                        return;

                    default:
                        Console.WriteLine("Oops, the option selected is not valid. Please select a valid option and try again.");
             
                        break;
                }



            }



        }

        public static void adminMenu(WestministerHotel hotel)
        {
            //variable to control the while loop 
            bool adminLoop = true;
            // loop that runs while admin loop is true 
            while (adminLoop)
            {
                //Display the admin menu to the user 
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n \n \n");
                Console.WriteLine("Welcome to the Admin Portal! How can we help you today? \n");
                Console.ResetColor();

                Console.Write("    1. ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Increase Rooms ");
                Console.ResetColor();
                Console.Write("\n    2. ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Delete or Decrease Rooms");
                Console.ResetColor();
                Console.Write("\n    3. ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Manage your Rooms Inventory");
                Console.ResetColor();
                Console.Write("\n    4. ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Browse Rooms by Cost");
                Console.ResetColor();
                Console.Write("\n    5. ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Produce a Room Data Report");
                Console.ResetColor();
                Console.Write("\n    6. ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Exit to Main Menu \n");
                Console.ResetColor();
                Console.Write("\n \"Please select an option from the menu below by entering the corresponding number: \": ");
                int alt = Convert.ToInt32(Console.ReadLine());

                //grab the user's choice

                // switch statement will determine code block to excecute based on the user's choice
                switch (alt)
                {
                    case 1: // propmt the user to enter information about new room 
                        Console.WriteLine("Specify the Room Number: ");
                        int roomNo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\"Kindly indicate the floor number of the room:\"");
                        int roomFloor = Convert.ToInt32(Console.ReadLine());
                        // get the size of the room
                        Size size = askForSize();

                        Console.WriteLine("What is the cost of the Room?(only digits):\n");
                        int price = Convert.ToInt32(Console.ReadLine());
                        //variable to track if the room was added successfully 
                        bool addedRoom = false;

                        Console.WriteLine(" Choose your desired room category by entering the corresponding number: (enter only the number):\n");
                        Console.WriteLine("1. Standard Room");
                        Console.WriteLine("2. Deluxe Room");
                        int roomType = Convert.ToInt32(Console.ReadLine());
                        // creates an instance of the standardroom class 
                        if (roomType == 1)
                        {
                            Console.WriteLine("Kindly specify the number of windows desired in the room (Minimum 1): \n ");
                            int windows = Convert.ToInt32(Console.ReadLine());
                            //checks the number of windows is less than 1 
                            if (windows < 1)
                            {
                                Console.WriteLine("Invalid input: Please enter a number greater than 0 for the number of windows.");
                                // break out of the loop if windows is less than
                                break;
                            }
                            // create a new standard room object with the given parameters 

                            Room standardRoom = new StandardRoom(roomNo, roomFloor, price, size, windows);
                            // add the room to the hotel and store the result in addedRoom
                            addedRoom = hotel.AddRoom(standardRoom);
                        }
                        else if (roomType == 2)
                        {
                            Console.WriteLine("Kindly Provide  the balcony size in  (m^2):\n");
                            Double balcony = Convert.ToDouble(Console.ReadLine());
                            View view = askForView();
                            // create a new deluxe room object with the given parameters 
                            Room deluxeRoom = new DeluxeRoom(roomNo, roomFloor, size, price, balcony, view);
                            //add the room to the hotel and store the result in added room 
                            addedRoom = hotel.AddRoom(deluxeRoom);

                        }
                        else
                        {
                            Console.WriteLine("\"If you please, kindly make your selection by entering either '1' or '2'.\".\n");
                            //break out of the loop if roomtype is not 1 or 2
                            break;
                        }

                        if (addedRoom)
                        {
                            Console.WriteLine("Room has been successfully added to the system\n");
                        }
                        else
                        {
                            Console.Error.WriteLine("Error: Room already exist.\n");

                        }
                        break;
                    case 2:
                        Console.WriteLine("What's the room number? (e.g. 102, 203)\n");
                        int roomToDelete = Convert.ToInt32(Console.ReadLine());
                        // delete room and store the results in a variable. 
                        if (hotel.DeleteRoom(roomToDelete))
                        {
                           
                        }
                        else
                        {
                            Console.WriteLine("Room has not been deleted. \n");
                        }
                        break;
                    case 3:
                        hotel.ListRooms();
                        break;
                    case 4:
                        hotel.ListRoomsOrderedByPrice();
                        break;
                    case 5:
                        Console.WriteLine("Please enter a file name to save the report as:\n");
                        String filename = Console.ReadLine();
                        hotel.GenerateReport(filename);
                        break;
                    case 6:
                        adminLoop = false;
                        break;
                    default:
                        Console.WriteLine("Please enter an option number from 1-6.");
                        break;
                }

            }


        }

        public static Booking askForBooking()
        {
            DateTime checkInDate;
            DateTime checkOutDate;
            do
            {
                checkInDate = askForDate("Please enter the check-in date (in format DD/MM/YYYY):");
                checkOutDate = askForDate("Please enter the check-out date (in format DD/MM/YYYY):");
                if (checkOutDate <= checkInDate)
                {
                    Console.WriteLine("The check-out date must be later than the check-in date. Please enter a valid check-out date:");
                }
            } while (checkOutDate <= checkInDate);

            return new Booking(checkInDate, checkOutDate);
        }


        public static Size askForSize()
        {
            //prints list of room sizes and options 
            Console.WriteLine("\nROOM SIZE:");
            Console.WriteLine("1. Single");
            Console.WriteLine("2. Double");
            Console.WriteLine("3. Triple\n");
            // request user to select an option
            Console.WriteLine("Please select an option (enter only the number):\n");
            //read user's input, convert it to int and store in variable sizeNo
            int sizeNo = Convert.ToInt32(Console.ReadLine());
            //Intitialize size as single variable accordingly 
            Size size;

            switch (sizeNo)
            {
                case 1:
                    size = Size.Single;
                    break;
                case 2:
                    size = Size.Double;
                    break;
                case 3:
                    size = Size.Triple;
                    break;
                default:
                    size = Size.Single;
                    break;
            }

            return size;
        }


        public static View askForView()
        {
            // Print list of room view options
            Console.WriteLine("\nROOM VIEW:");
            Console.WriteLine("1. Seaview");
            Console.WriteLine("2. Landmark View");
            Console.WriteLine("3. Mountain View\n");

            // Request user to select an option
            Console.WriteLine("Please select an option (enter only the number):\n");

            // Read user's input, convert it to int and store in variable viewNo
            int viewN = Convert.ToInt32(Console.ReadLine());

            // Initialize view as Seaview (default value)
            View scenery = View.Seaview;

            // Check user's input and set the scenery variable accordingly
            switch (scenery)
            {
                case (View)1:
                    scenery= View.Seaview;
                    break;
                case (View)2:
                    scenery = View.Landmark_View;
                    break;
                case (View)3:
                    scenery = View.Mountain_View;
                    break;
                default:
                    scenery = View.Seaview;
                    break;
            }
            // return the selected view
            return scenery;
        }


        public static DateTime askForDate(String msg)
        {
            // prints the message passsed to the method 
            Console.WriteLine("\n");
            Console.WriteLine(msg);
            // read user input
            String dateString = Console.ReadLine() ?? "ERROR !! NULL FOUND!!";
            //Parse the input to Datetime with GB time format 
            DateTime dateParsed = DateTime.Parse(dateString, new CultureInfo("GB-EN"));
            //return the parsed date
            return dateParsed;

        }
    }
}
