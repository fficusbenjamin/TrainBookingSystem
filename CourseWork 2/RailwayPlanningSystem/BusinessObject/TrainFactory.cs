using System;
using System.Collections.Generic;
using System.Text;

///-------------------------------------------------------------------
///   Class:          TrainFactory
///   Description:    This is a factory class that runs the method to 
///                   create the object of the various train subclasses.
///                   
///   Author:         Francesco Fico (40404272)     Date: 06/12/2018
///-------------------------------------------------------------------

namespace BusinessObject
{
    public abstract class TrainFactory
    {
        //runs the getTrainType method
        public abstract Train GetTrainType();
    } 
}
