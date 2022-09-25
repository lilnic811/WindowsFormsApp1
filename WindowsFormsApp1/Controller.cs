using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Timers;

namespace Alarm501
{
    public class Controller
    {
        /// <summary>
        /// allows for the calling/setting of AddEditView objects
        /// </summary>
        public GetAddEditFormDelegate AddEditForm { get; set; }

        //public AlarmSetOffDelegate AlarmSetOff { get; set; }

        public UpdateAddingDelegate UpdateAdding { get; set; }

        public UpdateSelectionDelegate UpdateSelection { get; set; }


        private BindingList<Alarm> alarmList = new BindingList<Alarm>();

        private Alarm selectedAlarm;
        private int selectedAlarmIndex;

        //public bool adding = false;

        ///// <summary>
        ///// timer for alarms
        ///// </summary>
        //private static System.Timers.Timer timer;
        //public Controller()
        //{
        //    timer = new System.Timers.Timer(1000);
        //    timer.Elapsed += CheckAlarms;
        //    timer.SynchronizingObject = this;
        //    timer.AutoReset = true;
        //    timer.Start();
        //}


        /// <summary>
        /// called on by AlarmView to show the alarms (This is not decoupling--just removing fumctionality from view)
        /// </summary>
        /// <returns>the list of alarms to then be displayed in AlarmView listbox</returns>
        public BindingList<Alarm> DisplayAlarms()
        {
            string path = "..\\..\\AlarmData2.txt";
            //FileInfo f = new FileInfo(path);
            if (File.Exists(path))
            {
                string[] alarmInfo;
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        alarmInfo = reader.ReadLine().Split(',', ':');
                        int alarmHours = Convert.ToInt32(alarmInfo[0]);
                        int alarmMinutes = Convert.ToInt32(alarmInfo[1]);
                        int alarmSeconds = Convert.ToInt32(alarmInfo[2]);
                        string period = alarmInfo[3];

                        bool isActive;
                        if (alarmInfo[4] == "true") { isActive = true; }
                        else { isActive = false; }

                        int snooze = Convert.ToInt32(alarmInfo[5]);
                        string temp = alarmInfo[6];

                        SnoozeSounds sound;
                        if(temp == "Radar") { sound = SnoozeSounds.Radar; }
                        else if(temp == "Beacon") { sound = SnoozeSounds.Beacon; }
                        else if(temp == "Chimes") { sound = SnoozeSounds.Chimes; }
                        else if(temp == "Circuit") { sound = SnoozeSounds.Circuit; }
                        else { sound = SnoozeSounds.Reflecion; } //(temp == "Reflection")

                        alarmList.Add(new Alarm(alarmHours, alarmMinutes, alarmSeconds, period, isActive, snooze, sound));

                    }

                }
            }
            return alarmList;
        }


        /// <summary>
        /// get the alarm currently selected from the list box
        /// </summary>
        /// <param name="index">index of the select alarm</param>
        /// <returns>the alarm at the corresponding index</returns>
        public Alarm GetSelectedAlarm(int index)
        {
            selectedAlarm = alarmList[index];
            selectedAlarmIndex = index;
            return selectedAlarm;
        }


        ///// <summary>
        ///// periodically checks the alarms to see when to trigger the alarm
        ///// compares alarms from the alarmList with the system time
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public void CheckAlarms(object sender, ElapsedEventArgs e)
        //{
        //    foreach (Alarm alarm in alarmList)
        //    {
        //        //int updateHour = DateTime.Now.Hour;
        //        //if (DateTime.Now.Hour > 12 && (alarm.Period == "pm" || alarm.Period == "PM"))
        //        //{
        //        //    updateHour -= 12;
        //        //}


        //        DateTime curr = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        //        if (alarm.IsActive && TimeSpan.Compare(curr.TimeOfDay, alarm.Now.TimeOfDay) == 0)
        //        {
        //            int index = alarmList.IndexOf(alarm);
        //            AlarmSetOff(index);
        //        }
        //    }
        //}

        public string SnoozeAlarm()
        {
            //update alarm status
            //update ux_alarmStatusLabel.text
            selectedAlarm.Now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            selectedAlarm.Now = selectedAlarm.Now.AddSeconds(selectedAlarm.SnoozeLength);
            selectedAlarm.Status = ("Alarm for " + selectedAlarm.StatusTime + "\nhas been snoozed for " + selectedAlarm.SnoozeLength + " seconds...");
            //UpdateAlarmStatus(selectedAlarm);
            return selectedAlarm.Status;

        }

        public string StopAlarm()
        {
            //update alarm status
            //update ux_alarmStatusLabel.text

            selectedAlarm.IsActive = false;
            selectedAlarm.Status = ("Alarm for " + selectedAlarm.StatusTime + "\nhas been stopped...");
            return selectedAlarm.Status;
        }


        /// <summary>
        /// re-write the status of the alarm based on selection changes
        /// </summary>
        /// <param name="alarm">the selected alarm</param>
        /// <returns>the status of the alarm</returns>
        public string UpdateAlarmStatus(Alarm alarm)
        {
            if (alarm.IsActive)
            {
                selectedAlarm.Status = ("Alarm for \n" + selectedAlarm.StatusTime + "\nis running...");
            }
            else if (selectedAlarm.Status.Contains("stop") || selectedAlarm.Status.Contains("went"))
            {   /// entering this else means the alarm has already gone off
                selectedAlarm.Status = selectedAlarm.Status;
            }
            else
            {
                selectedAlarm.Status = ("Alarm for \n" + selectedAlarm.StatusTime + "\nis diabled...");
            }
            return alarm.Status;
        }

        /// <summary>
        /// when add was selected
        /// </summary>
        public void ShowAddView()
        {
            UpdateAdding(true);
            AddEditForm(selectedAlarm);
        }

        /// <summary>
        /// when edit was selected
        /// </summary>
        /// <param name="alarm"></param>
        public void ShowEditView(Alarm alarm)
        {
            UpdateAdding(false);
            selectedAlarm = alarm;
            AddEditForm(selectedAlarm);
        }


        public void AddNewAlarm(DateTime time, bool active, int snooze, SnoozeSounds sound)
        {
            string per;
            per = time.ToString("tt");
            alarmList.Add(new Alarm(time.Hour, time.Minute, time.Second, per.ToString(), active, snooze, sound));
            UpdateSelection();
        }


        public void EditAlarm(DateTime time, bool active, int snooze, SnoozeSounds sound)
        {
            alarmList.Remove(alarmList[selectedAlarmIndex]);
            string per;
            per = time.ToString("tt");
            alarmList.Add(new Alarm(time.Hour, time.Minute, time.Second, per.ToString(), active, snooze, sound));
            UpdateSelection();
        }


        public void Close()
        {
            using (StreamWriter write = new StreamWriter("..\\..\\AlarmData2.txt"))
            {
                StringBuilder alarmInfo = new StringBuilder();
                foreach (Alarm alarm in alarmList)
                {
                    int updateHours = alarm.Hours;
                    if (alarm.Hours > 12)
                    {
                        updateHours -= 12;
                    }
                    alarmInfo.Append(updateHours + ":" + alarm.Mins + ":" + alarm.Secs + "," + alarm.Period + "," + alarm.IsActive + "," + alarm.SnoozeLength + "," + alarm.Sound);

                    //if (alarm.IsActive)
                    //{
                    //    alarmInfo.Append("ON");
                    //}
                    //else
                    //{
                    //    alarmInfo.Append("OFF");
                    //}
                    write.WriteLine(alarmInfo.ToString());
                    alarmInfo.Clear();
                }

            }
        }


        public void Register(Delegate d)
        {
            if(d is GetAddEditFormDelegate)
            {
                AddEditForm = (GetAddEditFormDelegate)d;
            }
            //else if(d is AlarmSetOffDelegate)
            //{
            //    AlarmSetOff = (AlarmSetOffDelegate)d;
            //}
            else if (d is UpdateSelectionDelegate)
            {
                UpdateSelection = (UpdateSelectionDelegate)d;
            }
            else
            {
                UpdateAdding = (UpdateAddingDelegate)d;
            }

        }


    }

}










