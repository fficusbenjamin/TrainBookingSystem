using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///-------------------------------------------------------------------
///   Class:          Train
///   Description:    This is an abstract class hold all the properties
///                   and methods necessary to the creation of a trains.
///                   
///   Author:         Francesco Fico (40404272)     Date: 06/12/2018
///-------------------------------------------------------------------


namespace BusinessObject 
{
    public abstract class Train
    {
        //declaration of all the train properties
        public abstract string TrainType { get; }
        public abstract string ID { get; set; }
        public abstract string Departure { get; set; }
        public abstract string Destination { get; set; }
        public abstract string Type { get; set; }
        public abstract string IntermediateNC { get; set; }
        public abstract string IntermediateYK { get; set; }
        public abstract string IntermediateDG { get; set; }
        public abstract string IntermediatePB { get; set; }
        public abstract string Hour { get; set; }
        public abstract string Minute { get; set; }
        public abstract string Day { get; set; }
        public abstract bool Berth { get; set; }
        public abstract bool FirstClass { get; set; }


        //method to get departure string from the user choice
        public string getDeparture()
        {
            switch (Departure)
            {
                case "Edinburgh (Waverley)":
                    Departure = "Edinburgh(Waverley)";
                    break;

                case "London (Kings Cross)":
                    Departure = "London(Kings Cross)";
                    break;
            }
            return Departure;

        }
        //method to get destination string from the user choice
        public string getDestination()
        {
            switch (Destination)
            {
                case "Edinburgh (Waverley)":
                    Destination = "Edinburgh(Waverley)";
                    break;

                case "London (Kings Cross)":
                    Destination = "London(Kings Cross)";
                    break;
            }
            return Destination;

        }
        //method to get train type string from the user choice
        public string getType()
        {
            switch (Type)
            {
                case "Express":
                    Type = "Express";
                    break;

                case "Stopping":
                    Type = "Stopping";
                    break;

                case "Sleeper":
                    Type = "Sleeper";
                    break;
            }

            return Type;

        }
        //method to get hour string from the user choice
        public string getHour()
        {
            switch (Hour)
            {
                case "05":
                    Hour = "05";
                    break;

                case "06":
                    Hour = "06";
                    break;

                case "07":
                    Hour = "07";
                    break;

                case "08":
                    Hour = "08";
                    break;

                case "09":
                    Hour = "09";
                    break;

                case "10":
                    Hour = "10";
                    break;

                case "11":
                    Hour = "11";
                    break;

                case "12":
                    Hour = "12";
                    break;

                case "13":
                    Hour = "13";
                    break;

                case "14":
                    Hour = "14";
                    break;

                case "15":
                    Hour = "15";
                    break;

                case "16":
                    Hour = "16";
                    break;

                case "17":
                    Hour = "17";
                    break;

                case "18":
                    Hour = "18";
                    break;

                case "19":
                    Hour = "19";
                    break;

                case "20":
                    Hour = "20";
                    break;

                case "21":
                    Hour = "21";
                    break;

                case "22":
                    Hour = "22";
                    break;

                case "23":
                    Hour = "23";
                    break;

                case "00":
                    Hour = "00";
                    break;

            }
            return Hour;
        }
        //method to get minute string from the user choice
        public string getMinute()
        {
            switch (Minute)
            {
                case "00":
                    Minute = "00";
                    break;

                case "15":
                    Minute = "15";
                    break;

                case "30":
                    Minute = "30";
                    break;

                case "45":
                    Minute = "45";
                    break;
            }

            return Minute;

        }




    }


}
