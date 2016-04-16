using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VotingSystem
{
    /// <summary>
    /// FormsBasedUI class that initialize all the elements on the form and contains event listeners 
    /// on the different elements
    /// </summary>
    public partial class FormsBasedUI : Form, IUserInterface
    {

        /// <summary>
        /// Interface for the filereader
        /// </summary>
        /// <value>
        /// IOhandler
        /// </value>
        public IConstituencyFileReader IOhandler { get; set; }

        private ConfigData configData;
        private PartyList partylist;
        private ConstituencyList constituencyList;
        private int ShowMoreInfo = 0; // flag that indicates the type of information for the data grid view

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="IOhandler">File reader interface</param>
        public FormsBasedUI(IConstituencyFileReader IOhandler)
        {
            InitializeComponent();
            this.IOhandler = IOhandler;
            this.Width = 267;

        }

        /// <summary>
        /// Setup the xml files that should be read
        /// </summary>
        /// <value>
        /// SetupConfigData method
        /// </value>
        public bool SetupConfigData()
        {
            configData = new ConfigData();
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "XML Files|*.xml";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Multiselect = true;


            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    string path = Path.GetDirectoryName(file);
                    Console.WriteLine("-----" + Path.GetDirectoryName(file));
                    configData.configRecords.Add(new ConfigRecord(path, file)); 
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Initialize the producer and consumer 
        /// </summary>
        /// <value>
        /// RunProducerConsumer method
        /// </value>
        public void RunProducerConsumer()
        {
            //Create constituency and party list
            partylist = new PartyList();
            constituencyList = new ConstituencyList();

            ProgressManager progManager = new ProgressManager(configData.configRecords.Count);

            progressLbl.Text = "Creating and starting all producers and consumers";

            // Create a PCQueue instance, give it a capacity of 4
            var pcQueue = new PCQueue(4);

            // Create 2 Producer instances and 2 Consumer instances, these will begin executing on
            // their respective threads as soon as they are instantiated
            Producer[] producers = { new Producer("P1", pcQueue, configData, IOhandler),
                                     new Producer("P2", pcQueue, configData, IOhandler) };

            Consumer[] consumers = { new Consumer("C1", pcQueue, partylist,constituencyList, progManager),
                                     new Consumer("C2", pcQueue, partylist,constituencyList, progManager) };

            while (progManager.ItemsRemaining > 0) ;

            progressLbl.Text = "Shutting down all producers and consumers";

            // Deactivate the PCQueue so it does not prevent waiting producer and/or consumer threads
            // from completing
            pcQueue.Active = false;

            // Iterate through producers and signal them to finish
            foreach (var p in producers)
            {
                p.Finished = true;
            }

            // Iterate through consumers and signal them to finish
            foreach (var c in consumers)
            {
                c.Finished = true;
            }

            // Pulse enough the PCQueue to signal any waiting threads
            for (int i = 0; i < (Producer.RunningThreads + Consumer.RunningThreads); i++)
            {
                lock (pcQueue)
                {
                    Monitor.Pulse(pcQueue);

                    // Give a short break to the main thread so the pulses have time to be
                    // detected by any potentially waiting producer and/or consumer threads
                    Thread.Sleep(100);
                }
            }

           
            while ((Producer.RunningThreads > 0) || (Consumer.RunningThreads > 0)) ; // Wait by spinning

            Console.WriteLine();
            progressLbl.Text = "All producers and consumers shut down";
        }

        //METHODS FOR BUTTONS

        /// <summary>
        /// Print all constituency names in the lbx_data
        /// </summary>
        /// <value>
        /// DisplayConstituenciesInfo method
        /// </value>
        public void DisplayConstituencies()
        {
            // Form design options
            lbx_data.Items.Clear();
            grdv_more_info.Visible = true;
            lbx_data.Visible = true;
            grdv_more_info.Location = new Point(251, 202);
            lbx_data.SelectionMode = SelectionMode.One;
            grdv_more_info.DataSource = null;
            lbl_help.Visible = true;
            lblPartyWinner.Visible = false;

            // Put each const name on the screen
            foreach (var consts in constituencyList.constituencyList){
                lbx_data.Items.Add(consts);
            }
        }


        /// <summary>
        /// Display the parties and the total number of votes for each party
        /// </summary>
        /// <value>
        /// DisplaySumParties method
        /// </value>
        public void DisplaySumParties()
        {
            // Form design options
            lbx_data.Items.Clear();
            grdv_more_info.Visible = true;
            grdv_more_info.Location = new Point(251,97);
            lbx_data.Visible = false;
            lbx_data.SelectionMode = SelectionMode.None;
            ShowMoreInfo = 0;
            lbl_help.Visible = false;
            lblPartyWinner.Visible = false;

            // Show the party's details
            var sortedParties =  partylist.SumParties();
            grdv_more_info.DataSource = sortedParties;
            foreach (var party in sortedParties)
            {
                    lbx_data.Items.Add(party);
            }


        }

        /// <summary>
        /// Show the party with maximun number of votes
        /// </summary>
        /// <value>
        /// DisplayWinnerParty method
        /// </value>
        public void DisplayWinnerParty()
        {
            // Form design options
            lbx_data.Items.Clear();
            grdv_more_info.Visible = false;
            lbx_data.Visible = false;
            grdv_more_info.Location = new Point(251, 202);
            lbx_data.SelectionMode = SelectionMode.None;
            grdv_more_info.DataSource = null;
            ShowMoreInfo = 0;
            lbl_help.Visible = false;
            lblPartyWinner.Visible = true;


            //Display the winner party
            var sortedParties = partylist.SumParties().First();          
            lbx_data.Items.Add(sortedParties);

            lblPartyWinner.Text = "And the election winner is the \n " + sortedParties.Name + " party \n  with \n" + sortedParties.PartyVotes + " votes.";

        }


        //BUTTONS EVENT LISTENERS

        private void configBtn_Click(object sender, EventArgs e)
        {
            // Clear any items in listbox
            lbx_data.Items.Clear();

            bool ok = SetupConfigData();

            if (ok == true)
            {
                // Update form object properties
                progressLbl.Text = "Config data loaded.";
                RunProducerConsumerBtn.Enabled = true;
                ConstInfoBtn.Enabled = false;
                constWinnerBtn.Enabled = false;
                configBtn.Enabled = false;
            }
            else
            {
                DialogResult box = MessageBox.Show("Please select one or more .xml files");
                configBtn.Enabled = true;
            }
        }

        private void RunProducerConsumerBtn_Click(object sender, EventArgs e)
        {
            // Clear any items in listbox
            lbx_data.Items.Clear();

            progressLbl.Text = "Obtaining constituency data. Please wait";
            progressLbl.Refresh();

            // Run producer consumer to load constituency data
            RunProducerConsumer();

            progressLbl.Text = "Constituency data loaded";
            this.Width = 633;
            ConstInfoBtn.Enabled = true;
            constWinnerBtn.Enabled = true;
            SumPartiesBtn.Enabled = true;
            WinnerPartyBtn.Enabled = true;
            RunProducerConsumerBtn.Enabled = false;
        }

        private void ConstInfoBtn_Click(object sender, EventArgs e)
        {
            DisplayConstituencies();
            ShowMoreInfo = 1; //show all candidates for the selected constituency
        }

        private void constWinnerBtn_Click(object sender, EventArgs e)
        {
            DisplayConstituencies();
            ShowMoreInfo = 2; //show the elected candidate for the selected constituency
        }

        private void SumPartiesBtn_Click(object sender, EventArgs e)
        {
            DisplaySumParties();
        }

        private void WinnerPartyBtn_Click(object sender, EventArgs e)
        {
            DisplayWinnerParty();
        }


        //DATA GRID VIEW EVENT LISTENER

        private void meanAsymListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (ShowMoreInfo)
            {
                case 1: //show all candidates for the selected constituency
                    var selectedItem1 = lbx_data.SelectedItem.ToString();

                    grdv_more_info.DataSource = constituencyList.printConstDetails(selectedItem1);

                    //get only the name of the party from the Party object, whitout the votes
                    grdv_more_info.CellFormatting += (Ssender, Ee) =>
                     {
                         var party = Ee.Value as Party;
                         if (party != null ) { Ee.Value = party.Name; Ee.FormattingApplied = true; }
                     };

                    grdv_more_info.Columns[0].Width = 70;
                    grdv_more_info.Columns[1].Width = 70;
                    grdv_more_info.Columns[2].Width = 50;

                    break;

                case 2: //show the elected candidate for the selected constituency
                    var selectedItem2 = lbx_data.SelectedItem.ToString();

                    List<Candidates> Useless_List_Helping_Me_Just_To_Put_One_Object_In_Data_Grid_Because_Otherwise_It_Does_Not_Work = new List<Candidates>();
                    Useless_List_Helping_Me_Just_To_Put_One_Object_In_Data_Grid_Because_Otherwise_It_Does_Not_Work.Add(constituencyList.printConstWinner(selectedItem2).First());
                    grdv_more_info.DataSource = Useless_List_Helping_Me_Just_To_Put_One_Object_In_Data_Grid_Because_Otherwise_It_Does_Not_Work;

                    //get only the name of the party from the Party object, whitout the votes
                    grdv_more_info.CellFormatting += (Ssender, Ee) =>
                    {
                        var party = Ee.Value as Party;
                        if (party != null) { Ee.Value = party.Name; Ee.FormattingApplied = true; }
                    };

                    grdv_more_info.Columns[0].Width = 70;
                    grdv_more_info.Columns[1].Width = 70;
                    grdv_more_info.Columns[2].Width = 50;


                    break;
            }
        }
    }
}
