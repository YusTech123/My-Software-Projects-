using System;
namespace UniCourseWork
{
	public class StandardRoom : Room
	{
        // private field for the number of windows
        private int windows;

        //// constructor with additional parameter for the number of windows
        public StandardRoom( int floor, int number,  int price, Size size, int windows) : base(number, floor, size, price)
        {
            this.windows = windows;

        }
       
        public StandardRoom(int number, int floor, Size size, int price, int v) : base(number, floor, size, price)
        {
        }
         // overriding the method to add information about the number of windows
        public override string roomInfoString()
        {
            return base.roomInfoString() + ", RoomType = Standard, Windows = " + this.getWindows();

        }
        // // Getter for windows
        public int getWindows()
        {
            return this.windows;
        }

    }
}

