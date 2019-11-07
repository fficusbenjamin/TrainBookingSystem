using DataLayer;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;


///-----------------------------------------------------------------------
///   Class:          Book (Window)
///   Description:    This class hold all the properties and 
///                   actions/methods required to interact with the 
///                   form on the window in order to: read valued 
///                   that the user has entered; validate them; 
///                   create a book from them; add book to 
///                   the booked list; clear the form; display a 
///                   list of all booking, display a list of all the trains.
///   Author:         Francesco Fico (40404272)     Date: 06/12/2018
///-------------------------------------------------------------------------


namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Book.xaml
    /// </summary>

    public partial class Book : Window
    {
        //Declaring a private Booked object called saveBookings 
        private static Booked saveBookings = new Booked();
        //Declaring variables of type String that hold temporarily user's inputs and selected content
        private string nameInput, idInput, depInput, depChoice, destInput, destChoice, coachInput, seatInput;
        //Declaring variables of type bool to be used in methods to validate the user's entries and set them all as false
        private bool isEntryValid = false;
        private bool isBerth = false;
        private bool isFirstClass = false;
        private bool isFcAvail = false;
        private bool isBthAvail = false;
        private bool isSeatTaken = false;
        private bool isAlrThere = false;
        private bool isEdinbDp = false;
        private bool isLondonDp = false;
        private bool isEdinbDt = false;
        private bool isLondonDt = false;
        private bool noStops = false;
        private bool isNewC = false;
        private bool isYk = false;
        private bool isDg = false;
        private bool isPb = false;
        //declaring a variable of type int to store the ticket price
        private int price;
        //Declaring an array of strings that holds the content of the file specified in the path
        private string[] file = File.ReadAllLines(@"..\..\..\..\RailwayPlanningSystem\Trains.csv");

        //Method to initialize all components in the window
        public Book()
        {
            InitializeComponent();
        }

        //Method that validates all the entries given by the user
        private void validateEntry()
        {
            //Setting the bool variable as true so that the entry is accepted to start with
            isEntryValid = true;
            //TryParse the seat entered by the user and store it in a variable
            int.TryParse(_txtBkSeat.Text, out int seatTest);
            //Try/Catch method to validate the Name entry
            try
            {
                //if the user han not entered a name
                if (_txtBkName.Text == "")
                {
                    //set the validation bool as false
                    isEntryValid = false;
                    //Throw argument exception to prompt the user with the error that has been compiled
                    throw new ArgumentException("Field cannot be blank", "Name");
                }
                //Otherwise set the Name entered by the user as an Name value temporarily
                nameInput = _txtBkName.Text;
                //Try/Catch method to validate the ID entry
                try
                {
                    //if the user han not entered a ID
                    if (_txtBkTrID.Text == "")
                    {
                        //set the validation bool as false
                        isEntryValid = false;
                        //Throw argument exception to prompt the user with the error that has been compiled
                        throw new ArgumentException("Field cannot be blank", "Train ID");
                    }
                    //Otherwise set the ID entered by the user as an ID value temporarily
                    idInput = _txtBkTrID.Text;
                    //Try/Catch method to validate the departure entry
                    try
                    {
                        //if the user han not entered a departure
                        if (_cmbBkDep.SelectedIndex < -1)
                        {
                            //set the validation bool as false
                            isEntryValid = false;
                            //Throw argument exception to prompt the user with the error that has been compiled
                            throw new ArgumentException("Please choose a departure for the train, Field cannot be blank", "Departure");
                        }
                        //runs the findDep method
                        findDep();
                        //if the train depart from Edinburgh
                        if (isEdinbDp == true)
                        {
                            //if the selection is London
                            if (_cmbBkDep.SelectedIndex == 5)
                            {
                                //set the validation bool as false
                                isEntryValid = false;
                                //Throw argument exception to prompt the user with the error that has been compiled
                                throw new ArgumentException("This train depart from Edinburgh (Waverley)", "Departure");
                            }
                        }else
                        //if the train depart from London
                        if (isLondonDp == true)
                        {
                            //if the selection in  edinburgh
                            if (_cmbBkDep.SelectedIndex == 0)
                            {
                                //set the validation bool as false
                                isEntryValid = false;
                                //Throw argument exception to prompt the user with the error that has been compiled
                                throw new ArgumentException("This train depart from London (Kings Cross)", "Departure");
                            }
                        }
                        //if the boolean that determine that the train is an express is true
                        if (noStops == true)
                        {
                            //if all the entry other than the two main one (Edinburgh/London) are selected
                            if (_cmbBkDep.SelectedIndex == 1 || _cmbBkDep.SelectedIndex == 2 || _cmbBkDep.SelectedIndex == 3 || _cmbBkDep.SelectedIndex == 4)
                            {
                                //set the validation bool as false
                                isEntryValid = false;
                                //Throw argument exception to prompt the user with the error that has been compiled
                                throw new ArgumentException("This is an express train, it doesn't have intermediate stops", "Departure");
                            }
                        }
                        //runs the method findStops
                        findStops();
                        //if the newcastle bool is false
                        if (isNewC == false)
                        {
                            //if the departure selection is newcastle
                            if (_cmbBkDep.SelectedIndex == 4)
                            {
                                //set the validation bool as false
                                isEntryValid = false;
                                //Throw argument exception to prompt the user with the error that has been compiled
                                throw new ArgumentException("This train doesn't stop at New Castle", "Departure");
                            }
                        }else
                        //if the york bool is false
                        if (isYk == false)
                        {
                            //if the departure selection is york
                            if (_cmbBkDep.SelectedIndex == 3)
                            {
                                //set the validation bool as false
                                isEntryValid = false;
                                //Throw argument exception to prompt the user with the error that has been compiled
                                throw new ArgumentException("This train doesn't stop at York", "Departure");
                            }
                        }else 
                        //if the darlington bool is false
                        if (isDg == false)
                        {
                            //if the departure selection id darlington
                            if (_cmbBkDep.SelectedIndex == 2)
                            {
                                //set the validation bool as false
                                isEntryValid = false;
                                //Throw argument exception to prompt the user with the error that has been compiled
                                throw new ArgumentException("This train doesn't stop at Darlington", "Departure");
                            }
                        }else 
                        //if the peterborough bool is false
                        if (isPb == false)
                        {
                            //if the departure selection is peterborough
                            if (_cmbBkDep.SelectedIndex == 1)
                            {
                                //set the validation bool as false
                                isEntryValid = false;
                                //Throw argument exception to prompt the user with the error that has been compiled
                                throw new ArgumentException("This train doesn't stop at Peterborough", "Departure");
                            }
                        }
                        //Otherwise set the departure choosen by the user is stored value temporarily
                        depInput = depChoice;
                        //Try/Catch method to validate the destination entry
                        try
                        {
                            //if the user has not chosen a destination
                            if (_cmbBkDest.SelectedIndex < -1)
                            {
                                //set the validation bool to false
                                isEntryValid = false;
                                //Throw argument exception to prompt the user with the error that has been compiled
                                throw new ArgumentException("Please choose a destination for the train, Field cannot be blank", "Destination");
                            }
                            else 
                            //if the departure is equal to the destination
                            if (depInput == destChoice)
                            {
                                //set the validation bool to false
                                isEntryValid = false;
                                //Throw argument exception to prompt the user with the error that has been compiled
                                throw new ArgumentException("The Departure and the Destination must be different", "Destination");
                            }
                            //if the boolean that determine that the train is an express is true
                            if (noStops == true)
                            {
                                //if all the entry other than the two main one (Edinburgh/London) are selected
                                if (_cmbBkDest.SelectedIndex == 1 || _cmbBkDest.SelectedIndex == 2 || _cmbBkDest.SelectedIndex == 3 || _cmbBkDest.SelectedIndex == 4)
                                {
                                    //set the validation bool to false
                                    isEntryValid = false;
                                    //Throw argument exception to prompt the user with the error that has been compiled
                                    throw new ArgumentException("This is an express train, it doesn't have intermediate stops", "Destination");
                                }
                            }
                            //runs the findDest method
                            findDest();
                            //if the destination id edinburgh
                            if (isEdinbDt == true)
                            {
                                //if the selection is london
                                if (_cmbBkDest.SelectedIndex == 5)
                                {
                                    //set the validation bool to false
                                    isEntryValid = false;
                                    //Throw argument exception to prompt the user with the error that has been compiled
                                    throw new ArgumentException("This train depart from London (Kings Cross)", "Destination");
                                }
                            }
                            else 
                            //if the destination is london
                            if (isLondonDt == true)
                            {
                                //if the selection is edinburgh
                                if (_cmbBkDest.SelectedIndex == 0)
                                {
                                    //set the validation bool to false
                                    isEntryValid = false;
                                    //Throw argument exception to prompt the user with the error that has been compiled
                                    throw new ArgumentException("This train depart from Edinburgh (Waverley))", "Destination");
                                }
                            }
                            //runs the findStops method exactly like it does for the departures
                            findStops();

                            if (isNewC == false)
                            {
                                if (_cmbBkDest.SelectedIndex == 4)
                                {
                                    //set the validation bool to false
                                    isEntryValid = false;
                                    //Throw argument exception to prompt the user with the error that has been compiled
                                    throw new ArgumentException("This train doesn't stop at New Castle", "Destination");
                                }
                            }
                            else if (isYk == false)
                            {
                                if (_cmbBkDest.SelectedIndex == 3)
                                {
                                    //set the validation bool to false
                                    isEntryValid = false;
                                    //Throw argument exception to prompt the user with the error that has been compiled
                                    throw new ArgumentException("This train doesn't stop at York", "Destination");
                                }
                            }
                            else if (isDg == false)
                            {
                                if (_cmbBkDest.SelectedIndex == 2)
                                {
                                    //set the validation bool to false
                                    isEntryValid = false;
                                    //Throw argument exception to prompt the user with the error that has been compiled
                                    throw new ArgumentException("This train doesn't stop at Darlington", "Destination");
                                }
                            }
                            else if (isPb == false)
                            {
                                if (_cmbBkDest.SelectedIndex == 1)
                                {
                                    //set the validation bool to false
                                    isEntryValid = false;
                                    //Throw argument exception to prompt the user with the error that has been compiled
                                    throw new ArgumentException("This train doesn't stop at Peterborough", "Destination");
                                }
                            }
                            //Otherwise set the destination choosen by the user is stored value temporarily
                            destInput = destChoice;
                            //Try/Catch method to validate the coach entry
                            try
                            {
                                //declare two regex, the first to check that the coach is between A and H and the second one
                                //to check that the coach is not a number
                                System.Text.RegularExpressions.Regex rCouch = new System.Text.RegularExpressions.Regex("[a-hA-H]*[a-hA-H]");
                                System.Text.RegularExpressions.Regex rCouchNmb = new System.Text.RegularExpressions.Regex("[0-9]");
                                //if the user doesn't input a coach
                                if (_txtBkCoach.Text == "")
                                {
                                    //set the validation bool to false
                                    isEntryValid = false;
                                    //Throw argument exception to prompt the user with the error that has been compiled
                                    throw new ArgumentException("Field cannot be blank", "Coach");
                                }else
                                //if the input is not matched 
                                if (!rCouch.IsMatch(_txtBkCoach.Text))
                                {
                                    //set the validation bool to false
                                    isEntryValid = false;
                                    //Throw argument exception to prompt the user with the error that has been compiled
                                    throw new ArgumentException("Choose a coach between A and H", "Coach");
                                } else
                                //if the input is not matched 
                                if (rCouchNmb.IsMatch(_txtBkCoach.Text))
                                {
                                    //set the validation bool to false
                                    isEntryValid = false;
                                    //Throw argument exception to prompt the user with the error that has been compiled
                                    throw new ArgumentException("Choose a coach between A and H", "Coach");
                                }
                                //Otherwise set the coach choosen by the user is stored value temporarily
                                coachInput = _txtBkCoach.Text;
                                //Try/Catch method to validate the seat entry
                                try
                                {
                                    //declare a regex to check that the seat is not a letter
                                    System.Text.RegularExpressions.Regex rSeat = new System.Text.RegularExpressions.Regex("[a-zA-Z]");
                                    //if the seat form is blank
                                    if (_txtBkSeat.Text == "")
                                    {
                                        //set the validation bool to false
                                        isEntryValid = false;
                                        //Throw argument exception to prompt the user with the error that has been compiled
                                        throw new ArgumentException("Field cannot be blank", "Seat");
                                    }else
                                    //if the seat number is not between 1 and 60 
                                    if ((seatTest < 1) ||  (seatTest > 60 ))
                                    {
                                        //set the validation bool to false
                                        isEntryValid = false;
                                        //Throw argument exception to prompt the user with the error that has been compiled
                                        throw new ArgumentException("Seat number does not exist", "Seat");
                                    }else
                                    //if the regex is match
                                    if (rSeat.IsMatch(_txtBkSeat.Text))
                                    {
                                        //set the validation bool to false
                                        isEntryValid = false;
                                        //Throw argument exception to prompt the user with the error that has been compiled
                                        throw new ArgumentException("Seat must be a number", "Seat");
                                    }                                
                                    //Otherwise set the coach choosen by the user is stored value temporarily
                                    seatInput = _txtBkSeat.Text;
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
        //method that find a train in the list, it returns a train and takes in as a parameter a string id
        public Train find(string id)
        {
            //foreach train in the list
            foreach (Train t in MainWindow._saveTrains.trainList)
            {
                //if the id is in the list
                if (id == t.ID)
                {
                    //return the train
                    return t;
                }
            }
            //otherwise return null
            return null;
        }
        //method that triggers the selection in the form listbox
        private void _lstBkTrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            //declare a string that stores the toString on the selection
            string selTrain = _lstBkTrains.SelectedItem.ToString();
            //declare a string that stores the first4 character of that string
            string selId = selTrain.Substring(0, 4);
            //runs the find method
            find(selId);
            //display the selected ID and type
            _txtBkTrID.Text = selId;
            _txtBkType.Text = find(selId).Type;
            //if type "express"
            if (find(selId).Type == "Express")
            {
                //nostop boolean true
                noStops = true;
            }
            else
            {
                //otherwise false
                noStops = false;
            }
            //runs findfirstclass method
            findFC(); 
            //if firstclass true
            if (isFcAvail == true)
            {
                //enable the checkbox
                _chkBkFcl.IsEnabled = true;
            } else 
            //if firstclass false
            if (isFcAvail == false)
            {
                //disable the checkbox
                _chkBkFcl.IsEnabled = false;
            }
            //runs the findberth method
            findBth();
            //if berth true
            if (isBthAvail == true)
            {
                //enable the berth checkbox
                _chkBkSlpBrth.IsEnabled = true;
            }
            else 
            //if false
            if (isBthAvail == false)
            {
                //disable the checkbox
                _chkBkSlpBrth.IsEnabled = false;
            }
            //runs the methods for the departure,the stops and the destination
            findDep();
            findStops();
            findDest();            
        }
        //triggers the button back
        private void _btnBack_Click(object sender, RoutedEventArgs e)
        {
            //create a new instance of the MainWindow class
            MainWindow newWin = new MainWindow();
            //open the window
            newWin.Show();
            //close the book one
            this.Close();
        }
        //when the window book is created load the trainslist into the form listbox
        private void _lstBkTrains_Loaded(object sender, RoutedEventArgs e)
        {
            showList(MainWindow._saveTrains.trainList);
        }
        //when the window book is created load the bookings into the form listbox
        private void _lstBkBookings_Loaded(object sender, RoutedEventArgs e)
        {
            showBookings(Book.saveBookings.bookingList);
        }
        //method that triggers the selection in the form combobox
        private void _cmbBkDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try to enforce the ToString method to get the line selected in the form combobox            
            try { depChoice = ((ComboBoxItem)_cmbBkDep.SelectedItem).Content.ToString(); }
            //there is no catch, it only serves to force the aforementioned ToString method 
            //(gives me a weird error if I don't enforce it this way)
            catch { }
        }
        //method that triggers the selection in the form combobox
        private void _cmbBkDest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try to enforce the ToString method to get the line selected in the form combobox            
            try { destChoice = ((ComboBoxItem)_cmbBkDest.SelectedItem).Content.ToString(); }
            //there is no catch, it only serves to force the aforementioned ToString method 
            //(gives me a weird error if I don't enforce it this way)
            catch { }
        }
        //method that triggers the selection in the form checkbox
        private void _chkBkFcl_Checked(object sender, RoutedEventArgs e)
        {
            //when checked the bool firstclass is true
            isFirstClass = true;
        }
        //method that triggers the selection in the form checkbox
        private void _chkBkSlpBrth_Checked(object sender, RoutedEventArgs e)
        {
            //when checked the bool berth is true
            isBerth = true;
        }
        //method that triggers the book button in the form 
        private void _btnBkBook_Click(object sender, RoutedEventArgs e)
        {
            //runs the bookTrain method
            bookTrain();
        }
        //method that triggers the book button in the form 
        private void _btnBkPrice_Click(object sender, RoutedEventArgs e)
        {
            //runs the validation method
            validateEntry();
            //if the inputs are valid
            if (isEntryValid == true)
            {
                //runs the priceQuotation method
                priceQuotation();
            }
            
        }
        //same method of the mainWindow with the addition of the book file
        private void showList(List<Train> list2)
        {
            string line2;
            var file2 = new StreamReader(@"..\..\..\..\RailwayPlanningSystem\Trains.csv");
            while ((line2 = file2.ReadLine()) != null)
            {
                _lstBkTrains.Items.Add(line2);
            }
        }
        private void showBookings(List<Booking> list2)
        {
            string line2;
            var file2 = new StreamReader(@"..\..\..\..\RailwayPlanningSystem\Bookings.csv");
            while ((line2 = file2.ReadLine()) != null)
            {
                _lstBkBookings.Items.Add(line2);
            }
        }
        //same method to check the duplicate train in the file
        private void isNotThere(string[] file)
        {
            for (int i = 0; i < file.Length; i++)
            {
                int StringLenght = _txtBkTrID.Text.Trim().Length > 4 ? 4 : _txtBkTrID.Text.Trim().Length;
                string lineSub = file[i].Substring(0, StringLenght);
                if (lineSub == _txtBkTrID.Text)
                {
                    isAlrThere = true;
                }
            }
        }
        //method that check if the train in the list has first class
        private void findFC()
        {
            //set a firstclass bool to false
            isFcAvail = false;
            //convert the selected item in a string
            string selTrain1 = _lstBkTrains.SelectedItem.ToString();
            //look if the string has the first class
            bool selFc = selTrain1.Contains("has first True");
            //if the bool is true
            if (selFc == true)
            {
                //set the firstclass as true
                isFcAvail = true;
            }
        }
        //method that check if the train in the list has berth (same as firstclass)
        private void findBth()
        {
            isBthAvail = false;
            string selTrain2 = _lstBkTrains.SelectedItem.ToString();
            bool selBth = selTrain2.Contains("has cabin True");
            if (selBth == true)
            {
                isBthAvail = true;
            }
        }
        //method that check where the selected train depart(same as firstclass)

        private void findDep()
        {
            isEdinbDp = false;
            isLondonDp = false;
            string selTrain3 = _lstBkTrains.SelectedItem.ToString();
            bool selEdin = selTrain3.Contains("Dep: Edinburgh(Waverley)");            
            if (selEdin == true)
            {
                isEdinbDp = true;
                isLondonDp = false;
            }
            else
            {
                isLondonDp = true;
                isEdinbDp = false;
            }
        }
        //method that check where the selected train stop (same as firstclass)
        private void findStops()
        {
            isNewC = false;
            isYk = false;
            isDg = false;
            isPb = false;
            string selTrain5 = _lstBkTrains.SelectedItem.ToString();
            bool selNewC = selTrain5.Contains("Stop: New Castle");
            bool selYk = selTrain5.Contains("Stop: York");
            bool selDg = selTrain5.Contains("Stop: Darlington");
            bool selPb = selTrain5.Contains("Stop: Peterborough");
            if (selNewC == true)
            {
                isNewC = true;
            }else 
            if (selYk == true)
            {
                isYk = true;
            }else 
            if (selDg == true)
            {
                isDg = true;
            }else 
            if (selPb == true)
            {
                isPb = true;
            }
        }
        //method that check where the selected train arrives(same as firstclass)
        private void findDest()
        {
            isEdinbDt = false;
            isLondonDt = false;
            string selTrain4 = _lstBkTrains.SelectedItem.ToString();
            bool selEdin = selTrain4.Contains("Dest: Edinburgh(Waverley)");
            if (selEdin == true)
            {
                isEdinbDt = true;
                isLondonDt = false;
            }
            else
            {
                isLondonDt = true;
                isEdinbDt = false;
            }
        }
        //method that creates a new booking. it returns a booking objects
        private Booking createBooking()
        {
            //create an empty booking object
            Booking aBooking = new Booking();
            //it fills it with all the properties
            aBooking.trainID = idInput;
            aBooking.Name = nameInput;
            aBooking.Departure = depInput;
            aBooking.Arrival = destInput;
            aBooking.FirstClass = isFirstClass;
            aBooking.SleepBerth = isBerth;
            aBooking.Coach = coachInput;
            aBooking.Seat = seatInput;
            //it return the complete booking
            return aBooking;
        }
        //method that check the availability of seats in the train, takes in a string id as a parameter
        public void checkTrain(string id)
        {
            //foreach bookings in the list
            foreach (Booking b in saveBookings.bookingList) {
                //if the the train ID is the same as the one in the ticket
                if (id == b.trainID) 
                {
                    //runs checkcoach method
                    checkCoach(createBooking().Coach);
                }
                else
                {
                    //otherwise set the boolean as false
                    isSeatTaken = false;
                }
            }
        }
        //method that checks the availability in the coaches, takes in a string coach as a parameter
        public void checkCoach(string coach)
        {
            //foreach bookings in the list
            foreach (Booking b in saveBookings.bookingList)
            {
                //if the input coach is the same as the one in list
                if (coach == b.Coach)
                {
                    //runs checkcoach method
                    checkSeat(createBooking().Seat);
                }
                else
                {
                    //otherwise set the boolean as false
                    isSeatTaken = false;
                }
            }
        }
        //method that checks the availability of seat in coaches takes in a string seat as a parameter
        public void checkSeat(string seat)
        {
            //foreach bookings in the list
            foreach (Booking b in saveBookings.bookingList)
            {
                //if the input seat is the same as the one in list
                if (seat == b.Seat)
               {
                 //set the boolean as true
                 isSeatTaken = true;
                 //prompt an error message
                 MessageBox.Show("Sorry this seat is taken, please select another one");
               }
               else
               {
                    //otherwise set the boolean as false
                    isSeatTaken = false;
               }  
            }
        }
        //method that check and display the pricequotation in the form listview
        private void priceQuotation()
        {
            //if the firstclass box is not checked
            if (_chkBkFcl.IsChecked == false)
            {
                //set the bool to false
                isFirstClass = false;
            }
            //if the cabin box is not checked
            if (_chkBkSlpBrth.IsChecked == false)
            {
                //set the bool to false
                isBerth = false;
            }
            //Try/Catch method to validate the existence of a train
            try
            {
                //runs the isnothere method
                isNotThere(file);
                //if not here
                if (isAlrThere == false)
                {
                    //set the validation bool to false
                    isEntryValid = false;
                    //Throw argument exception to prompt the user with the error that has been compiled
                    throw new ArgumentException("This train doesn't exist! Please input the correct Train ID", "Train ID");
                } 
                //define what the train fare is by running the trainFare() method on the booking returned in createBooking()
                price = createBooking().trainFare(_cmbBkDep.SelectedIndex, _cmbBkDest.SelectedIndex, isFirstClass, _txtBkType.Text, isBerth);
                //declare two empty strings
                string showFC = "";
                string showCabin = "";
                //if the check of the firstclass is true
                if (createBooking().FirstClass == true)
                {
                    //the string contains the firstclass
                    showFC = " in First Class ";
                }
                //if the check of the cabin is true
                if (createBooking().SleepBerth == true)
                {
                    //the string contains the firstclass
                    showCabin = " in Cabin ";
                }
                //show the entire string in the listview
                _txtSummary.Text = "Passenger Name: " + createBooking().Name + Environment.NewLine + "Train: " + createBooking().trainID + Environment.NewLine + "Departing from: " + createBooking().Departure + Environment.NewLine + "Arriving at: " + createBooking().Arrival + Environment.NewLine + "Seat Booked: " + createBooking().Coach + createBooking().Seat + showFC + showCabin + Environment.NewLine + "Price: £"+ price ;        
            }
            //Setting the message box containing the error message
            catch (Exception execMsg)
            {
                MessageBox.Show(execMsg.Message);
            }
        }
        //method that confirm and save the booking in the list
        private void bookTrain()
        {
            //runs the validation method
            validateEntry();
            //if valid
            if (isEntryValid == true)
            {
                //runs the checking
                checkTrain(createBooking().trainID);
                //if seat available
                if (isSeatTaken == false)
                {
                    //shows the price in a messagebox
                     MessageBoxResult dialogResult = MessageBox.Show("Train fare: £" + price + Environment.NewLine + "Book the ticket?", "Train Ticket", MessageBoxButton.OKCancel);
                    //if click ok
                    if (dialogResult == MessageBoxResult.OK)
                    {
                        //save to booking in the list
                        saveBookings.add(createBooking());
                        //add the booking in the form listbox
                        _lstBkBookings.Items.Add(createBooking().Name + ", " + createBooking().trainID + ", " + createBooking().Departure + ", " + createBooking().Arrival + ", " + createBooking().FirstClass + ", " + createBooking().SleepBerth + ", " + createBooking().Coach + ", " + createBooking().Seat);
                        //messagevbox that confirm the booking
                        MessageBox.Show("Booking placed, total spent: £"+ price);
                    }else                    
                    //if cancel is clicked just go back
                    if (dialogResult == MessageBoxResult.Cancel){}                       
                }                
            }                     
        }
    }
}