using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///----------------------------------------------------------------------------
///   Class:          Sleeper (that inherit from the Train abstract class)
///   Description:    This is an inherited class that hold all the properties
///                   and methods necessary to the creation of a sleeper train.
///                   
///   Author:         Francesco Fico (40404272)     Date: 06/12/2018
///----------------------------------------------------------------------------

namespace BusinessObject
{
    class Sleeper : Train
    {
        //declare a readonly string that contains the train type
        private readonly string _trainType;
        //declare the strings for all the train properties
        private string _trainID, _dep, _dest, _type, _nc, _yk, _dg, _pb, _day,_hour,_minute;
        //declare the boolean for the train properties
        private bool _berth, _fClass;

        //create a new instance of the class that needs all this properties to be created
        public Sleeper(string trainID, string departure, string destination, string type, string nc, string yk, string dg, string pb, string hour,string minute, string day, bool berth, bool fClass)
        {
            _trainType = "Sleeper";
            _trainID = trainID;
            _dep = departure;
            _dest = destination;
            _type = type;
            _nc = nc;
            _yk = yk;
            _dg = dg;
            _pb = pb;
            _hour = hour;
            _minute = minute;
            _day = day;
            _berth = berth;
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
            get { return _nc; }
            set { _nc = value; }
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
