using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Alarm501
{
    public partial class AlarmView : Form
    {
        public DisplayAllAlarmsDelegate ControllerDisplayAlarms { get; set; }

        public GetSelectedAlarmDelegate GetSelectedAlarm { get; set; }

        public UpdateAlarmStatusDelegate UpdateAlarmStatus { get; set; }

        public ShowAddViewDelegate ShowAddView { get; set; }

        public ShowEditViewDelegate ShowEditView { get; set; }

        public StopClickedDelegate StopClicked { get; set; }

        public SnoozeClickedDelegate SnoozeClicked { get; set; }

        //public CheckAlarmsDelegate CheckAlarms { get; set; }

        public WriteToCloseDelegate WriteToClose { get; set; }


        private static System.Timers.Timer timer;

        public AlarmView(DisplayAllAlarmsDelegate d, GetSelectedAlarmDelegate s, UpdateAlarmStatusDelegate u)
        {
            ControllerDisplayAlarms = d;
            GetSelectedAlarm = s;
            UpdateAlarmStatus = u;
            InitializeComponent();
            //add all alarms saved on load up
            Display();

            timer = new System.Timers.Timer(1000);
            timer.Elapsed += CheckAlarmsCall;
            timer.SynchronizingObject = this;
            timer.AutoReset = true;
            timer.Start();
        }
        
        public void CheckAlarmsCall(object sender, ElapsedEventArgs e)
        {
            foreach (Alarm alarm in ux_AlarmList.Items)
            {
                DateTime curr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                if (alarm.IsActive && TimeSpan.Compare(curr.TimeOfDay, alarm.Now.TimeOfDay) == 0)
                {
                    SetOffAlarm(alarm);
                }
            }
        }

        public void SetOffAlarm(Alarm alarm)
        {

            //Alarm alarm = GetSelectedAlarm(index);
            alarm.Status = ("Alarm for " + alarm.StatusTime + "\nwent off with " + alarm.Sound.ToString());
            ux_AlarmList.SelectedItem = alarm;
            ux_alarmStatusLabel.Text = alarm.Status;
            //UpdateAlarmStatus(alarm);
            ux_SnoozeButton.Enabled = true;
            ux_StopButton.Enabled = true;
        }

        public void Display()
        {
            ux_AlarmList.DataSource = ControllerDisplayAlarms();
            if (ux_AlarmList.Items.Count >= 5)
            {
                ux_AddButton.Enabled = false;
            }
        }

        private void ux_SnoozeButton_Click(object sender, EventArgs e)
        {
            //diasable snooze and stop
            //update alarm status
            //update ux_alarmStatusLabel.text
            ux_StopButton.Enabled = false;
            ux_SnoozeButton.Enabled = false;
            string status = SnoozeClicked();
            ux_alarmStatusLabel.Text = status;
        }

        private void ux_StopButton_Click(object sender, EventArgs e)
        {
            //disable snooze/stop
            ux_StopButton.Enabled = false;
            ux_SnoozeButton.Enabled = false;
            StopClicked();
            string status = StopClicked();
            ux_alarmStatusLabel.Text = status;
        }

        public void UpdateSelection()
        {
            ux_AlarmList.SelectedIndex = ux_AlarmList.Items.Count - 1;
        }

        private void ux_AddButton_Click(object sender, EventArgs e)
        {
            //open addedit form 
            ShowAddView();

            // disable add when 5 alrams (needs be somewhere else in case start at 5)
            if(ux_AlarmList.Items.Count >= 5)
            {
                ux_AddButton.Enabled = false;
            }
        }

        private void ux_EditButton_Click(object sender, EventArgs e)
        {
            ShowEditView(GetSelectedAlarm(ux_AlarmList.Items.IndexOf(ux_AlarmList.SelectedItem)));
            //edit currently selected alarm - addedit form ux_timePickerThing.DataSource = alarm.time
        }

        private void ux_AlarmList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //display the status of whichever alarm is selected
            Alarm alarm = GetSelectedAlarm(ux_AlarmList.Items.IndexOf(ux_AlarmList.SelectedItem));
            // update ux_alarmStatusLabel.text = alarm.Status
            ux_alarmStatusLabel.Text = UpdateAlarmStatus(alarm);
        }

        public void AlarmTimeMet(int index)
        {
            Alarm alarm = GetSelectedAlarm(index);
            alarm.Status = ("Alarm for " + alarm.StatusTime + "\nwent off with " + alarm.Sound.ToString());
            ux_AlarmList.SelectedItem = alarm;
            UpdateAlarmStatus(alarm);
            ux_SnoozeButton.Enabled = true;
            ux_StopButton.Enabled = true;
        }

        public void Close_Alarm(object sender, FormClosingEventArgs e)
        {
            WriteToClose();
        }




        public void Register(Delegate d)
        {
            if (d is ShowAddViewDelegate)
            {
                ShowAddView = (ShowAddViewDelegate)d;
            }
            else if (d is ShowEditViewDelegate)
            {
                ShowEditView = (ShowEditViewDelegate)d;

            }
            else if (d is StopClickedDelegate)
            {
                StopClicked = (StopClickedDelegate)d;
            }
            else if (d is SnoozeClickedDelegate)
            {
                SnoozeClicked = (SnoozeClickedDelegate)d;
            }
            else
            {
                WriteToClose = (WriteToCloseDelegate)d;
            }
            //else
            //{
            //    CheckAlarms = (CheckAlarmsDelegate)d;
            //}
        }

    }
}
