using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm501
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AddEditView addEdit = new AddEditView();

            Controller controller = new Controller();
                DisplayAllAlarmsDelegate display = new DisplayAllAlarmsDelegate(controller.DisplayAlarms);
                GetSelectedAlarmDelegate getAlarm = new GetSelectedAlarmDelegate(controller.GetSelectedAlarm);
                UpdateAlarmStatusDelegate updateAlarmStatus = new UpdateAlarmStatusDelegate(controller.UpdateAlarmStatus);
            AlarmView alarmView = new AlarmView(display, getAlarm, updateAlarmStatus);   //this delegate is taken as a parameter for the 
                                                            //alarmView constructor because the delegate is run on start
            //alarmView used
            ShowAddViewDelegate showAddView = new ShowAddViewDelegate(controller.ShowAddView);
            alarmView.Register(showAddView);
            ShowEditViewDelegate showEditView = new ShowEditViewDelegate(controller.ShowEditView);
            alarmView.Register(showEditView);
            SnoozeClickedDelegate snooze = new SnoozeClickedDelegate(controller.SnoozeAlarm);
            alarmView.Register(snooze);
            StopClickedDelegate stop = new StopClickedDelegate(controller.StopAlarm);
            alarmView.Register(stop);
            //CheckAlarmsDelegate check = new CheckAlarmsDelegate(controller.CheckAlarms);
            //alarmView.Register(check);
            WriteToCloseDelegate writeToClose = new WriteToCloseDelegate(controller.Close);
            alarmView.Register(writeToClose);

            //controller used
            GetAddEditFormDelegate getForm = new GetAddEditFormDelegate(addEdit.ShowView);
            controller.Register(getForm);
            //AlarmSetOffDelegate alarmSetOff = new AlarmSetOffDelegate(alarmView.AlarmTimeMet);
            //controller.Register(alarmSetOff);
            UpdateAddingDelegate updateAdding = new UpdateAddingDelegate(addEdit.UpdateAdding);
            controller.Register(updateAdding);
            
            UpdateSelectionDelegate updateSelection = new UpdateSelectionDelegate(alarmView.UpdateSelection);
            controller.Register(updateSelection);


            //AddEdit used
            ReturnNewAlarmDelegate returnNewAlarm = new ReturnNewAlarmDelegate(controller.AddNewAlarm);
            addEdit.Register(returnNewAlarm);
            EditExistingAlarmDelegate editExistingAlarm = new EditExistingAlarmDelegate(controller.EditAlarm);
            addEdit.Register(editExistingAlarm);


            Application.Run(alarmView);
        }
    }
}
