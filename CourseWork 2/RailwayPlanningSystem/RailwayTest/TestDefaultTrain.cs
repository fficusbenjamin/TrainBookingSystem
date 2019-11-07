using System;
using DataLayer;
using System.IO;
using BusinessObject;
using PresentationLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RailwayTest
{
    [TestClass]
    public class TestDefaultTrain
    {
        //declare an array from the file
        private string[] file = File.ReadAllLines(@"..\..\..\..\RailwayPlanningSystem\Trains.csv");
        [TestMethod]
        //runs the creation of the default trains just to check if everything works
        public void TestMethod1()
        {

            ExpressFactory factory1 = new ExpressFactory("1S45");
            Train train1 = factory1.GetTrainType();
            StoppingFactory factory2 = new StoppingFactory("1E05");
            Train train2 = factory2.GetTrainType();
            SleeperFactory factory3 = new SleeperFactory("1E99");
            Train train3 = factory3.GetTrainType();

            train1.Departure = "London (Kings Cross)";
            train1.Destination = "Edinburgh (Waverley)";
            train1.Type = "Express";
            train1.Hour = "10";
            train1.Minute = "00";
            train1.Day = "01/11/18";
            train1.Berth = false;
            train1.FirstClass = true;
            MainWindow.saveTrains.add(train1);

            train2.Departure = "Edinburgh (Waverley)";
            train2.Destination = "London (Kings Cross)";
            train2.Type = "Stopping";
            train2.IntermediateYK = "York";
            train2.IntermediateDG = "Darlington";
            train2.IntermediatePB = "Peterborough";
            train2.Hour = "12";
            train2.Minute = "00";
            train2.Day = "01/11/18";
            train2.Berth = false;
            train2.FirstClass = true;
            MainWindow._saveTrains.add(train2);

            train3.Departure = "Edinburgh (Waverley)";
            train3.Destination = "London (Kings Cross)";
            train3.Type = "Sleeper";
            train3.Hour = "21";
            train3.Minute = "30";
            train3.Day = "01/11/18";
            train3.Berth = true;
            train3.FirstClass = false;
            MainWindow._saveTrains.add(train3);

            MainWindow._saveTrains.duplTrain(file);

        }
    }
}
