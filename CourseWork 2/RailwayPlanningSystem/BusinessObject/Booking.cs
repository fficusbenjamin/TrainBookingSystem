using System;
using System.Collections.Generic;
using System.Text;

///-------------------------------------------------------------------
///   Class:          Booking
///   Description:    This is a class that holds all the properties
///                   and methods necessary to the creation of a booking.
///                   
///   Author:         Francesco Fico (40404272)     Date: 06/12/2018
///-------------------------------------------------------------------


namespace BusinessObject
{
    public class Booking
    {
        //declaration of all the booking properties and their getters and setters
        private string _custName;

        public string Name {

            get {
                return _custName;
            }
            set {
                _custName = value;
            }
        }

        private string _trainID;

        public string trainID
        {

            get
            {
                return _trainID;
            }
            set
            {
                _trainID = value;
            }
        }
        private string _departure;

        public string Departure {

            get {
                return _departure;
            }
            set {
                _departure = value;
            }

        }

        private string _arrival;

        public string Arrival
        {

            get
            {
                return _arrival;
            }
            set
            {
                _arrival = value;
            }

        }
        private bool hasFirst;

        public bool FirstClass
        {

            get
            {
                return hasFirst;
            }
            set
            {
                hasFirst = value;
            }

        }

        private bool hasBerth;

        public bool SleepBerth
        {

            get
            {
                return hasBerth;
            }
            set
            {
                hasBerth = value;
            }

        }


        private string _coach;

        public string Coach {

            get {
                return _coach;
            }

            set {
                _coach = value;
            }
        }

        private string _seat;

        public string Seat
        {

            get
            {
                return _seat;
            }

            set
            {
                _seat = value;
            }
        }

        //method to calculate a train fare returning an integer and taking in as parameters the train's deprture, 
        //arrival, if it has first class, what type of train it is, and whether it has a berth or not
        public int trainFare(int departure, int arrival, bool hasFirst, string type, bool hasBerth) {

            //declaring the local variable price
            int price = 0;

            //setting basic fares depending on the indexes of the locations
            //based on their position in the combobox:

            //If departure is the first station and arrival is the last station
            if (departure == 0 && arrival == 5) {
                //charge full price
                price = 50;
            }
            else if (departure == 5 && arrival == 0)
            {
                price = 50;
            }
            //if departure and arrival are from and/or to any intermediate stations
            else if (departure >= 0 && arrival <= 4)
            {
                //charge 25 pounds
                price = 25;
            }
            else if (departure <= 4  && arrival >= 0)
            {
                price = 25;
            }

            //if train has first class
            if (hasFirst == true) {
                //add ten extra pounds
                price = price + 10;
            }
            //if train is a sleeper
            if (type == "Sleeper")
            {
                //charge ten extra pounds
                price = price + 10;
            }
            //if booking as a sleeping berth
            if (hasBerth == true)
            {
                //charge twenty extra pounds
               price = price + 20;
            }

            //return the final price
            return price;

        }

    }
}
