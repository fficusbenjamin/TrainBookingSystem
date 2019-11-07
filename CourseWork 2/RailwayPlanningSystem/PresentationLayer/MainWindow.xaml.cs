using DataLayer;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;

///-------------------------------------------------------------------
///   Class:          MainWindow (Window)
///   Description:    This class hold all the properties and 
///                   actions/methods required to interact with the 
///                   form on the window in order to: read valued 
///                   that the user has entered; validate them; 
///                   create a train from them; add train to 
///                   the trains list; clear the form; display a 
///                   list of all trains and clear the aforementioned 
///                   list.
///   Author:         Francesco Fico (40404272)     Date: 06/12/2018
///-------------------------------------------------------------------



namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Declaring a private saveTrains object
        private static TrainsList saveTrains = new TrainsList();
        //Declaring a public _saveTrains object that gets information from the private store object in order to pass it to other windows when needed

        public static TrainsList _saveTrains { get { return saveTrains; } }
        //Declaring variables of type String that hold temporarily user's inputs and selected content
        private string idInput, depInput, depChoice, destInput, destChoice, typeInput, typeChoice, ctNC, ctYK, ctPB, ctDT, hourInput, hourChoice, minuteInput, minuteChoice, dateInput, dateChoice;
        //Declaring a variables of type bool to be used in methods to validate the user's entries
        private bool isNC, isYK, isDT, isPB, isEntryValid, isBerth, isFirstClass, isListClear;                          
        //Declaring an array of strings that holds the content of the file specified in the path
        private string[] file = File.ReadAllLines(@"..\..\..\..\RailwayPlanningSystem\Trains.csv");


        //Method to initialize all components in the window
        public MainWindow()
        {
            InitializeComponent();
            //Call the method the initialize the Test train for the actual demonstration when the program starts
            createDemonstrationTrains();
        }
        //Method that validates all the entries given by the user
        private void validateEntry()
        {
            //Setting the bool variable as true so that the entry is accepted to start with
            isEntryValid = true;
            //Try/Catch method to validate the ID entry
            try
            {
                //if the user has not entered an ID
                if (_txtTrainID.Text == "")
                {
                    //set the validation bool to false
                    isEntryValid = false;
                    //Throw argument exception to prompt the user with the error that has been compiled
                    throw new ArgumentException("Field cannot be blank", "Train ID");
                }
                //Otherwise set the ID entered by the user as an ID value temporarily
                idInput = _txtTrainID.Text;
                //Try/Catch method to validate the departure entry
                try
                {
                    //if the user has not chosen a departure
                    if (_cmbTrainDep.SelectedIndex < 0)
                    {
                        //set the validation bool to false
                        isEntryValid = false;
                        //Throw argument exception to prompt the user with the error that has been compiled
                        throw new ArgumentException("Please choose a departure for the train, Field cannot be blank", "Departure");
                    }
                    //Otherwise set the departure choosen by the user as an input value temporarily
                    depInput = depChoice;
                    //Try/Catch method to validate the destination entry
                    try
                    {
                        //if the user has not chosen a destination
                        if (_cmbTrainDest.SelectedIndex < 0)
                        {
                            //set the validation bool to false
                            isEntryValid = false;
                            //Throw argument exception to prompt the user with the error that has been compiled
                            throw new ArgumentException("Please choose a destination for the train, Field cannot be blank", "Destination");
                        } else 
                        //if the departure has the same value has the destination
                        if (depInput == destChoice)
                        {
                            //set the validation bool to false
                            isEntryValid = false;
                            //Throw argument exception to prompt the user with the error that has been compiled
                            throw new ArgumentException("The Departure and the Destination must be different", "Destination");
                        }
                        //Otherwise set the destination choosen by the user as an input value temporarily
                        destInput = destChoice;
                        //Try/Catch method to validate the train type entry
                        try
                        {
                            //if the user has not chosen a type
                            if (_cmbTrainType.SelectedIndex < 0)
                            {
                                //set the validation bool to false
                                isEntryValid = false;
                                //Throw argument exception to prompt the user with the error that has been compiled
                                throw new ArgumentException("Please choose a type of train, Field cannot be blank", "Type");
                            }
                            //Otherwise set the type choosen by the user as an input value temporarily
                            typeInput = typeChoice;
                            //Try/Catch method to validate the various stops entry
                            try
                            {
                                //if the choosen type is not "Express"
                                if (_cmbTrainType.SelectedIndex >= 1)
                                {
                                    //if the checkbox is checked
                                    if (_chkTrainNewCastle.IsChecked == true)
                                    {
                                        //ToString of the checkbox into a input value temporarily
                                        ctNC = _chkTrainNewCastle.Content.ToString();
                                    }else
                                    //if the checkbox is checked
                                    if (_chkTrainYork.IsChecked == true)
                                    {
                                        //ToString of the checkbox into a input value temporarily
                                        ctYK = _chkTrainYork.Content.ToString();
                                    }else
                                    //if the checkbox is checked
                                    if (_chkTrainDarlington.IsChecked == true)
                                    {
                                        //ToString of the checkbox into a input value temporarily
                                        ctDT = _chkTrainDarlington.Content.ToString();
                                    }else
                                    //if the checkbox is checked
                                    if (_chkTrainPeterborough.IsChecked == true)
                                    {
                                        //ToString of the checkbox into a input value temporarily
                                        ctPB = _chkTrainPeterborough.Content.ToString();
                                    }
                                    //if the choosen type is "Express"
                                    if (_cmbTrainType.SelectedIndex == 1)
                                    {
                                        //if the checkbox is unchecked
                                        if (_chkTrainNewCastle.IsChecked == false)
                                        {
                                            //if the checkbox is unchecked
                                            if (_chkTrainYork.IsChecked == false)
                                            {
                                                //if the checkbox is unchecked
                                                if (_chkTrainDarlington.IsChecked == false)
                                                {
                                                    //if the checkbox is unchecked
                                                    if (_chkTrainPeterborough.IsChecked == false)
                                                    {
                                                        //set the validation bool to false
                                                        isEntryValid = false;
                                                        //Throw argument exception to prompt the user with the error that has been compiled
                                                        throw new ArgumentException("Please choose some stops, Field cannot be blank", "Stops");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                //Try/Catch method to validate the hour entry
                                try
                                {
                                    //if the user has not chosen a hour
                                    if (_cmbTrainHour.SelectedIndex < 0)
                                    {
                                        //set the validation bool to false
                                        isEntryValid = false;
                                        //Throw argument exception to prompt the user with the error that has been compiled
                                        throw new ArgumentException("Please choose the time, Field cannot be blank", "Time");
                                    }
                                    //if the type choosen is "Sleeper" the hour choosen cannot be minor than "21"
                                    if (typeChoice == "Sleeper" && _cmbTrainHour.SelectedIndex < 16)
                                    {
                                        //set the validation bool to false
                                        isEntryValid = false;
                                        //Throw argument exception to prompt the user with the error that has been compiled
                                        throw new ArgumentException("Sleeper Trains can depart after 21:00", "Time");
                                    }
                                    //Otherwise set the hour choosen by the user as an input value temporarily
                                    hourInput = hourChoice;
                                    //if the user has not chosen a minute is automatically set as "00"
                                    if (_cmbTrainMin.SelectedIndex < 0)
                                    {
                                        minuteChoice = "00";
                                    }
                                    //Otherwise set the minute choosen by the user as an input value temporarily
                                    minuteInput = minuteChoice;
                                    //Try/Catch method to validate the date entry
                                    try
                                    {
                                        //if the user has not chosen a date
                                        if (_dateTrain.SelectedDate == null)
                                        {
                                            //set the validation bool to false
                                            isEntryValid = false;
                                            //Throw argument exception to prompt the user with the error that has been compiled
                                            throw new ArgumentException("Please choose the date, Field cannot be blank", "Date");
                                        }
                                        //Otherwise set the date choosen by the user as an input value temporarily
                                        dateInput = dateChoice;
                                    }
                                    //Setting the message box containing the error message
                                    catch (Exception execMsg)
                                    {
                                        MessageBox.Show(execMsg.Message);
                                    }
                                }
                                //Setting the message box containing the error message
                                catch (Exception execMsg)
                                {
                                    MessageBox.Show(execMsg.Message);
                                }
                            }
                            //Setting the message box containing the error message
                            catch (Exception execMsg)
                            {
                                MessageBox.Show(execMsg.Message);
                            }
                        }
                        //Setting the message box containing the error message
                        catch (Exception execMsg)
                        {
                            MessageBox.Show(execMsg.Message);
                        }
                    }
                    //Setting the message box containing the error message
                    catch (Exception execMsg)
                    {
                        MessageBox.Show(execMsg.Message);
                    }
                }
                //Setting the message box containing the error message
                catch (Exception execMsg)
                {
                    MessageBox.Show(execMsg.Message);
                }
            }
            //Setting the message box containing the error message
            catch (Exception execMsg)
            {
                MessageBox.Show(execMsg.Message);
            }
        }
        //method that creates an object of the type train for the validated user entry
        private void addTrain()
        {
            //declaring a new TrainFactory object and set it as null
            TrainFactory factory = null;
            /*Switch case to determine which object of which abstract Train inherited 
              class should be created with the type choosen by the user*/
            switch (typeChoice)
            {
                case "Express":
                    factory = new ExpressFactory(typeChoice);
                    break;
                case "Stopping":
                    factory = new StoppingFactory(typeChoice);
                    break;
                case "Sleeper":
                    factory = new SleeperFactory(typeChoice);
                    break;
                default:
                    break;
            }
            //Try/Catch method to validate if the train can be created
            try
            {
                //if the train id is already in the file
                if (duplId(file) == true)
                {
                    //set the validation bool to false
                    isEntryValid = false;
                    //Throw argument exception to prompt the user with the error that has been compiled
                    throw new ArgumentException("The Train ID is already present, must be unique", "Train ID");
                }
                //creating an empty train object based on the method in the factory class
                Train train = factory.GetTrainType();
                //Assign the ID and departure
                train.ID = idInput;
                train.Departure = depInput;
                //Based on the departure that the user has chosen, run the getDeparture method
                depInput = train.getDeparture();
                //Assign the destination
                train.Destination = destInput;
                //Based on the destination that the user has chosen, run the getDestination method
                destInput = train.getDestination();
                //Assign the type
                train.Type = typeInput;
                //Based on the type that the user has chosen, run the getType method
                typeInput = train.getType();
                //Assign the stops
                train.IntermediateNC = ctNC;
                train.IntermediateYK = ctYK;
                train.IntermediateDG = ctDT;
                train.IntermediatePB = ctPB;
                //Assign the hour
                train.Hour = hourInput;
                //Based on the hour that the user has chosen, run the getHour method
                hourInput = train.getHour();
                //Assign the minute
                train.Minute = minuteInput;
                //Based on the minute that the user has chosen, run the getMinute method
                minuteInput = train.getMinute();
                //Assign the minute
                train.Day = dateInput;
                //Assign the cabin
                train.Berth = isBerth;
                //Assign the firstclass
                train.FirstClass = isFirstClass;
                //add the train to the trainlist
                saveTrains.add(train);
                //add the train that has just been added to the listbox in the form
                _lstAllTrains.Items.Add(train.ID + ", " + train.Departure + ", " + train.Destination + ", " + train.Type + ", " + train.IntermediateNC + ", " + train.IntermediateYK + ", " + train.IntermediateDG + ", " + train.IntermediatePB + ", " + train.Hour + ":" + train.Minute + ", " + train.Day + ", has cabin " + train.Berth + ", has first " + train.FirstClass);
            }
            //Setting the message box containing the error message
            catch (Exception execMsg)
            {
                MessageBox.Show(execMsg.Message);
            } 
        }

        //Method to automatically create the 3 trains given in the pdf for the demonstration
        private void createDemonstrationTrains()
        {
            //creates the 3 train and set all the given properties
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
            saveTrains.add(train1);

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
            saveTrains.add(train2);

            train3.Departure = "Edinburgh (Waverley)";
            train3.Destination = "London (Kings Cross)";
            train3.Type = "Sleeper";
            train3.Hour = "21";
            train3.Minute = "30";
            train3.Day = "01/11/18";
            train3.Berth = true;
            train3.FirstClass = false;
            saveTrains.add(train3);
            //run the duplTrain method to check if the trains are already in the list
            saveTrains.duplTrain(file);
        }
        //method that trigger the ListAll button in the form to show all the train in the list in the form listbox
        private void _btnListAll_Click(object sender, RoutedEventArgs e)
        {
            //if the list is empty
            if (isListClear == true)
            {
                //runs the method to show the list in the listbox
                showList(saveTrains.trainList);
            }
            //set the validation bool as false
            isListClear = false;
           
           
        }
        //method that load the trains in the list when the listbox in the form is initialized
        private void _lstAllTrains_Loaded(object sender, RoutedEventArgs e)
        {
            //runs the method to show the list in the listbox
            showList(saveTrains.trainList);
            //set the validation bool as false
            isListClear = false;
        }
        //method that trigger the Clear button in the form to clear the train in the list in the form listbox

        private void _btnClearTrain_Click(object sender, RoutedEventArgs e)
        {
            //set the validation bool as true
            isListClear = true;
            //clears all the items in the form listbox
            _lstAllTrains.Items.Clear();
        }
        //method to clear all the user input choice from the form
        public void clearAll()
        {
            _txtTrainID.Clear();
            _cmbTrainDep.SelectedIndex = -1;
            _cmbTrainDest.SelectedIndex = -1;
            _cmbTrainType.SelectedIndex = -1;
            _chkTrainNewCastle.IsChecked = false;
            _chkTrainYork.IsChecked = false;
            _chkTrainDarlington.IsChecked = false;
            _chkTrainPeterborough.IsChecked = false;
            _cmbTrainHour.SelectedIndex = -1;
            _cmbTrainMin.SelectedIndex = -1;
            _dateTrain.SelectedDate = null;
            _chkTrainBerth.IsChecked = false;
            _chkTrainFirst.IsChecked = false;
            _chkTrainNewCastle.IsEnabled = false;
            _chkTrainPeterborough.IsEnabled = false;
            _chkTrainYork.IsEnabled = false;
            _chkTrainDarlington.IsEnabled = false;
        }
        //method that trigger the clear button
        private void _btnClear_Click(object sender, RoutedEventArgs e)
        {
            //run the clearall method
            clearAll();
        }
        //method that trigger the add button
        private void _btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //run the validation method
            validateEntry();
            //if the validation go through
            if (isEntryValid == true)
            {
                //runs the addTrain method
                addTrain();
                //runs the clearAll method
                clearAll();
            }
        }
        //method that triggers the selection in the form combobox
        private void _cmbTrainDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try to enforce the ToString method to get the line selected in the form combobox            
            try { depChoice = ((ComboBoxItem)_cmbTrainDep.SelectedItem).Content.ToString(); }
            //there is no catch, it only serves to force the aforementioned ToString method 
            //(gives me a weird error if I don't enforce it this way)
            catch { }
        }
        //method that triggers the selection in the form combobox
        private void _cmbTrainDest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try to enforce the ToString method to get the line selected in the form combobox
            try { destChoice = ((ComboBoxItem)_cmbTrainDest.SelectedItem).Content.ToString(); }
            //there is no catch, it only serves to force the aforementioned ToString method 
            //(gives me a weird error if I don't enforce it this way)
            catch { }
        }
        //method that triggers the selection in the form combobox
        private void _cmbTrainType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try to enforce the ToString method to get the line selected in the form combobox
            try { typeChoice = ((ComboBoxItem)_cmbTrainType.SelectedItem).Content.ToString(); }
            //there is no catch, it only serves to force the aforementioned ToString method 
            //(gives me a weird error if I don't enforce it this way)
            catch { }
            //runs the enStops method
            enStops();
            //if the type is "Sleeper"
            if (typeChoice == "Sleeper")
            {
                //enable the berth checkbox
                _chkTrainBerth.IsEnabled = true;
            }else
            //if the type is "Stopping"
            if (typeChoice == "Stopping")
            {
                //disable the berth checkbox
                _chkTrainBerth.IsEnabled = false;
            }else
            //if the type is "Express"
            if (typeChoice == "Express")
            {
                //disable the berth checkbox
                _chkTrainBerth.IsEnabled = false;
            }            
        }
        //method that triggers the checkbox selection
        private void _chkTrainNewCastle_Checked(object sender, RoutedEventArgs e)
        {
            //set the validation boolean as true
            isNC = true;
            //if the validation boolean is true
            if (isNC == true)
            {
                //stores the checkbox value as string
                ctNC = _chkTrainNewCastle.Content.ToString();
            }         
        }
        //method that triggers the checkbox selection
        private void _chkTrainYork_Checked(object sender, RoutedEventArgs e)
        {
            //set the validation boolean as true
            isYK = true;
            //if the validation boolean is true
            if (isYK == true)
            {
                //stores the checkbox value as string
                ctYK = _chkTrainYork.Content.ToString();
            }            
        }
        //method that triggers the checkbox selection
        private void _chkTrainDarlington_Checked(object sender, RoutedEventArgs e)
        {
            //set the validation boolean as true
            isDT = true;
            //if the validation boolean is true
            if (isDT == true)
            {
                //stores the checkbox value as string
                ctDT = _chkTrainDarlington.Content.ToString();
            }            
        }
        //method that triggers the checkbox selection
        private void _chkTrainPeterborough_Checked(object sender, RoutedEventArgs e)
        {
            //set the validation boolean as true
            isPB = true;
            //if the validation boolean is true
            if (isPB == true)
            {
                //stores the checkbox value as string
                ctPB = _chkTrainPeterborough.Content.ToString();
            }            
        }
        //method that triggers the selection in the form datepicker
        private void _dateTrain_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //try to enforce the ToString method to get the line selected in the form datepicker       
            try { dateChoice = _dateTrain.SelectedDate.Value.ToString("dd/MM/yy"); }
            //there is no catch, it only serves to force the aforementioned ToString method 
            //(gives me a weird error if I don't enforce it this way)
            catch { }
        }
        //method that triggers the selection in the form combobox
        private void _cmbTrainHour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try to enforce the ToString method to get the line selected in the form datepicker      
            try { hourChoice = ((ComboBoxItem)_cmbTrainHour.SelectedItem).Content.ToString(); }
            //there is no catch, it only serves to force the aforementioned ToString method 
            //(gives me a weird error if I don't enforce it this way)
            catch { }
        }
        //method that triggers the selection in the form combobox
        private void _cmbTrainMin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try to enforce the ToString method to get the line selected in the form datepicker
            try { minuteChoice = ((ComboBoxItem)_cmbTrainMin.SelectedItem).Content.ToString(); }
            //there is no catch, it only serves to force the aforementioned ToString method 
            //(gives me a weird error if I don't enforce it this way)
            catch { }
        }
        //method that trigger the selection in the checkbox
        private void _chkTrainBerth_Checked(object sender, RoutedEventArgs e)
        {
            //set the berth bool as true
            isBerth = true;
        }
        //method that trigger the selection in the checkbox
        private void _chkTrainFirst_Checked(object sender, RoutedEventArgs e)
        {
            //set the firstclass bool as true
            isFirstClass = true;
        }
        //method that trigger the book button
        private void _btnBook_Click(object sender, RoutedEventArgs e)
        {
            //creates a new instance of the book class in a window form 
            Book newWin = new Book();
            //shows the new window
            newWin.Show();
            //close the MainWindow
            this.Close();            
        }
        //method that enable the stop checkboxes in the form related to the train type
        private void enStops()
        {
            //if the train it of the type "Stopping"
            if (typeChoice == "Stopping")
            {
                //enable all the checkboxes
                _chkTrainNewCastle.IsEnabled = true;
                _chkTrainPeterborough.IsEnabled = true;
                _chkTrainYork.IsEnabled = true;
                _chkTrainDarlington.IsEnabled = true;
            }else
            //if the train it of the type "Sleeper"
            if (typeChoice == "Sleeper")
            {
                //enable all the checkboxes
                _chkTrainNewCastle.IsEnabled = true;
                _chkTrainPeterborough.IsEnabled = true;
                _chkTrainYork.IsEnabled = true;
                _chkTrainDarlington.IsEnabled = true;
            }else
            //if the train it of the type "Express"
            if (typeChoice == "Express")
            {
                //disable all the checkboxes
                _chkTrainNewCastle.IsEnabled = false;
                _chkTrainPeterborough.IsEnabled = false;
                _chkTrainYork.IsEnabled = false;
                _chkTrainDarlington.IsEnabled = false;
            }
        }
        //method that check duplicate train in the array from the trainID
        private bool duplId(string[] file)
        {        
            //for loop that checks inside the array
            for (int i =0; i < file.Length; i++)
            {
                //integer that trim the first four character of the string
                int StringLenght = _txtTrainID.Text.Trim().Length > 4 ? 4 : _txtTrainID.Text.Trim().Length;
                //string that store only the first four character of the string
                string lineSub = file[i].Substring(0,StringLenght);
                //if the four first character are equal to the user input
                if (lineSub == _txtTrainID.Text)
                {                   
                   //set the boolean value to true
                   return true;
                }
               
            }
            //otherwise set it as false
            return false;
        }
        //method that show all the elements inside the array of string created from the file
        private void showList(string[] file)
        {
            //for loop that checks inside the array
            for (int i = 0; i < file.Length; i++)
            {
                //creates a string for each array element
                string line = file[i].ToString();
                //add the string in the form listbox
                _lstAllTrains.Items.Add(line);
            }
        }
        //method that show all the element inside the .csv file
        private void showList(List<Train> list2)
        {
            //creates an empty string
            string line2;
            //creates a variable with the content of the .csv file
            var file2 = new System.IO.StreamReader(@"..\..\..\..\RailwayPlanningSystem\Trains.csv");
            //while loop to check if the string is different than null
            while ((line2 = file2.ReadLine()) != null)
            {
                //add the string in the form listbox
                _lstAllTrains.Items.Add(line2);
            }
        }
    }
}