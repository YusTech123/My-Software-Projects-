using System;
namespace UniCourseWork
{
    //Enumeration of different views
	public enum View { Landmark_View, Seaview, Mountain_View };

    public class DeluxeRoom : Room
	{
       //private fields for balcony size view
        private View view;
        private Double balcony;

        // constructor with additional parameters for balcony size and view
        public DeluxeRoom(int number, int floor, Size size, int price, Double balcony, View view) : base(number, floor, size, price)
        {
            this.balcony = balcony;
            this.view = view;

        }

        ////overriding the method to add information about balcony size and view
        public override string roomInfoString()
        {
            return base.roomInfoString() + ", RoomType = Deluxe, Balcony size = "
                + this.getBalcony() + "m^2, View = " + this.getView();

        }
        // //Getter for Balcony size
        public Double getBalcony()
        {
            return this.balcony;
        }
        //Getter for View 
        public View getView()
        {
            return this.view;
        }
    }
}

