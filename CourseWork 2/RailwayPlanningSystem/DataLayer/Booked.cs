using System;
using BusinessObject;
using System.Collections.Generic;
using System.IO;


///-------------------------------------------------------------------
///   Class:          Booked
///   Description:    This class hold all the methods that are 
///                   necessary to store the list of bookings on a file.
///                   
///   Author:         Francesco Fico (40404272)     Date: 06/12/2018
///-------------------------------------------------------------------

namespace DataLayer
{
    public class Booked
    {
        //declare a private list of bookings
        private List<Booking> _bookingList = new List<Booking>();
        //declare a public list that other files can refer to and that gets its properties from the private one
        public List<Booking> bookingList
        {
            get
            {
                return _bookingList;
            }
        }
        //declare an array of strings that is populated from the bookings file
        private string[] file = File.ReadAllLines(@"..\..\..\..\RailwayPlanningSystem\Bookings.csv");
        //declare an empty string to be used for each element in the list
        public string line = "";        

        //method that returns a string to then be used to write on the csv file
        public string createFile()
        {
            //foreach loop that iterates through all the bookings in the list 
            foreach (Booking b in bookingList)
                {
                    //for each booking in the list save its properties in a string
                    line = b.Name + ", " + b.trainID + ", " + b.Departure + ", " + b.Arrival + ", " + b.FirstClass + ", " + b.SleepBerth + ", " + b.Coach + ", " + b.Seat + Environment.NewLine;
                }
            //return the string
            return line;
        }     
        //method that adds a booking to the booking list (takes in a Booking object as a parameter)
        public void add(Booking newBooking)
        {
            bookingList.Add(newBooking);
            //create the string line from that booking
            createFile();
            //append the new string line to the csv file
            File.AppendAllText(@"..\..\..\..\RailwayPlanningSystem\Bookings.csv", createFile());
        }

    }
}
