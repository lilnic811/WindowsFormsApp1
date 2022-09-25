using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm501
{
    public partial class AddEditView : Form
    {

        private ReturnNewAlarmDelegate NewAlarm { get; set; }
        private EditExistingAlarmDelegate EditedAlarm { get; set; }

        /// <summary>
        /// used to tell whether the form is being used too add or edit an alarm
        /// </summary>
        public bool Adding { get; set; }

        public AddEditView()
        {
            InitializeComponent();
            ux_SoundComboBox.DataSource = Enum.GetValues(typeof(SnoozeSounds));
            ux_TimePick.Format = DateTimePickerFormat.Time;
            ux_TimePick.ShowUpDown = true;

        }

        public void ShowView(Alarm alarm)
        {
            if (!Adding)
            {
                ux_TimePick.Value = alarm.Now;
                ux_ActiveCheckBox.Checked = alarm.IsActive;
                ux_snoozeUpDown.Value = alarm.SnoozeLength;

                if (alarm.Sound == SnoozeSounds.Chimes) { ux_SoundComboBox.SelectedIndex = (int)SnoozeSounds.Chimes; }
                else if (alarm.Sound == SnoozeSounds.Beacon) { ux_SoundComboBox.SelectedIndex = (int)SnoozeSounds.Beacon; }
                else if (alarm.Sound == SnoozeSounds.Circuit) { ux_SoundComboBox.SelectedIndex = (int)SnoozeSounds.Circuit; }
                else if (alarm.Sound == SnoozeSounds.Radar) { ux_SoundComboBox.SelectedIndex = (int)SnoozeSounds.Radar; }
                else { ux_SoundComboBox.SelectedIndex = (int)SnoozeSounds.Reflecion; }

            }
            else
            {
                ux_TimePick.Value = DateTime.Now;
                ux_ActiveCheckBox.Checked = true;
            }
            this.Show();

        }


        public void UpdateAdding(bool isAdding)
        {
            if (isAdding)
            {
                Adding = true;
            }
            else
            {
                Adding = false;
            }
        }


        private void ux_CancelButton_Click(object sender, EventArgs e)
        {
            ///nothing happens
            ///return to alarmView screen
            
            this.Hide();
        }

        private void ux_SetButton_Click(object sender, EventArgs e)
        {
            // add/edit alarm

            DateTime time = ux_TimePick.Value;
            bool active = ux_ActiveCheckBox.Checked;
            int snoozeLength = (int)ux_snoozeUpDown.Value;
            SnoozeSounds sound = (SnoozeSounds)ux_SoundComboBox.SelectedValue;
            // pass alarm info to controller for alarm construction
            if (Adding)
            {
                NewAlarm(time, active, snoozeLength, sound);
            }
            else
            {
                EditedAlarm(time, active, snoozeLength, sound);
            }

            // call controller and pass alarm infor to create alarm/edit
            //return to main
            this.Hide();
        }

        public void Register(Delegate d)
        {
            if(d is ReturnNewAlarmDelegate)
            {
                NewAlarm = (ReturnNewAlarmDelegate)d;
            }
            else
            {
                EditedAlarm = (EditExistingAlarmDelegate)d;
            }
        }



    }
}
