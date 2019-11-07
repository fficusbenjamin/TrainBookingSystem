using System;
using BusinessObject;
using System.Collections.Generic;
using System.IO;


///-------------------------------------------------------------------
///   Class:          TrainsList
///   Description:    This class hold all the methods that are 
///                   necessary to store the list of trains on a file.
///                   
///   Author:         Francesco Fico (40404272)     Date: 06/12/2018
///-------------------------------------------------------------------

namespace DataLayer
{
    public class TrainsList
    {
        //declare a private list of trains
        private List<Train> _trainsList = new List<Train>();
        //declare a public list that other files can refer to and that gets its properties from the private one
        public List<Train> trainList
        {
            get
            {
                return _trainsList;
            }
        }
        //declare an array of strings that is populated from the trains file
        private string[] file = File.ReadAllLines(@"..\..\..\..\RailwayPlanningSystem\Trains.csv");
        //declare an empty string to be used for each element in the list
        public string line = "";
        //bool to check a train duplicate
        bool isAlrThere = false;

        //method that returns a string to then be used to write on the csv file
        public string createFile()
        {   
            //boolean that maes sure that two trains with the same id can't exist
            if (isAlrThere == true)
            {
                //foreach loop that iterates through all the trains in the list 
                foreach (Train t in trainList)
                {
                    //for each train in the list save its properties in a string
                    line = t.ID + ", Dep: " + t.Departure + ", Dest: " + t.Destination + ", " + t.Type + ", Stop: " + t.IntermediateNC + ", Stop: " + t.IntermediateYK + ", Stop: " + t.IntermediateDG + ", Stop: " + t.IntermediatePB + ", " + t.Hour + ":" + t.Minute + ", " + t.Day + ", has cabin " + t.Berth + ", has first " + t.FirstClass + Environment.NewLine;
                }
            }
            return line;
        }
        //method that adds a train to the train list (takes in a Train object as a parameter)
        public void add(Train newTrain)
        {
            //add the new train to the List
            trainList.Add(newTrain);
            //create the string line from that train
            createFile();
            //append the new string line to the csv file
            File.AppendAllText(@"..\..\..\..\RailwayPlanningSystem\Trains.csv", createFile());

        }
        //method that checks if there are duplicate trains in the array
        public void duplTrain(string[] file)
        {
            //foreach loop that iterates through all the trains in the list 
            foreach (Train t in trainList)
            {
                //set the bool to false
                isAlrThere = false;
                //for statement for any element of the array
                for (int i = 0; i < file.Length; i++)
                {

                    int StringLenght = t.ID.Trim().Length > 4 ? 4 : t.ID.Trim().Length;
                    //create a substring to store the first for letters of a train (so to say its id)
                    string lineSub = file[i].Substring(0, StringLenght);
                    //compare the substring to each train id:
                    //if the substring equals an existing id
                    if (lineSub == t.ID)
                    {
                        //set the boolean to true
                        isAlrThere = true;
                    }
                }
            }
        }

    }
}
