using System;
using System.Collections.Generic;
using System.Text;

///-------------------------------------------------------------------
///   Class:          StoppingFactory
///   Description:    This is a factory class that inherits from the
///                   TrainFactory class to create the stopping train
///                   object
///                   
///   Author:         Francesco Fico (40404272)     Date: 06/12/2018
///-------------------------------------------------------------------

namespace BusinessObject
{
    public class StoppingFactory : TrainFactory
    {
        //declaring the various variables the train needs
        private string _trainID, _dep, _dest, _type, _nc, _yk, _dg, _pb, _day, _hour, _minute;
        private bool _berth, _fClass;

        //method to call to create a stoppingFactory that requires inputting an id that
        //gets set as the train id
        public StoppingFactory(string trainID)
        {
            _trainID = trainID;
        }
        //overriding the method of the TrainFactory class to create the desired train
        public override Train GetTrainType()
        {
            //returning the desired train with all its variables
            return new Stopping(_trainID, _dep, _dest, _type, _nc, _yk, _dg, _pb, _hour,_minute, _day, _berth, _fClass);
        }
    }
}
