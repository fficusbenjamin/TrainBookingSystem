using System;
using System.Collections.Generic;
using System.Text;


///----------------------------------------------------------------------------
///   Class:          Express (that inherit from the Train abstract class)
///   Description:    This is an inherited class that hold all the properties
///                   and methods necessary to the creation of a express train.
///                   
///   Author:         Francesco Fico (40404272)     Date: 06/12/2018
///----------------------------------------------------------------------------

namespace BusinessObject
{
    class  Express : Train
    {
        //declare a readonly string that contains the train type
        private readonly string _trainType;
        //declare the strings for all the train properties
        private string _trainID, _dep, _dest,_type,_nc,_yk,_dg,_pb,_day,_hour,_minute;
        //declare the boolean for the train properties
        private bool _berth, _fClass;

        //create a new instance of the class that needs all this properties to be created
        public Express(string trainID,string departure, string destination,string type, string nc,string yk,string dg, string pb, string hour, string minute, string day,bool berth,bool fClass)
        {
            _trainType = "Express";
            _trainID = trainID;
            _dep = departure;
            _dest = destination;
            _type = type;
            //express train have all their stops as null
            _nc = null;
            _yk = null;
            _dg = null;
            _pb = null;
            _hour = hour;
            _minute = minute;
            _day = day;
            //express train don't have a sleeper berth
            _berth = false;
            _fClass = fClass;

        }

        //methods to ovverride the abstract class Train's getters and setters
        public override string TrainType
        {
            get { return _trainType; }
        }
        public override string ID
        {
            get { return _trainID; }
            set { _trainID = value; }
        }

        public override string Departure
        {
            get { return _dep; }
            set { _dep = value; }
        }
        public override string Destination
        {
            get { return _dest; }
            set { _dest = value; }
        }
        public override string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public override string IntermediateNC
        {
            get {return _nc; }
            set {_nc = value; }
        }
        public override string IntermediateYK
        {
            get { return _yk; }
            set { _yk = value; }
        }
        public override string IntermediateDG
        {
            get { return _dg; }
            set { _dg = value; }
        }
        public override string IntermediatePB
        {
            get { return _pb; }
            set { _pb = value; }
        }
        public override string Hour
        {
            get { return _hour; }
            set { _hour = value; }
        }

        public override string Minute
        {
            get { return _minute; }
            set { _minute = value; }
        }
        public override string Day
        {
            get { return _day; }
            set { _day = value; }
        }
        public override bool Berth 
        {
            get { return _berth; }
            set { _berth = value; }
        }
        public override bool FirstClass
        {
            get { return _fClass; }
            set { _fClass = value; }
        }     
    }
}
