using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Alarm501
{
    //AlarmView to Controller
    public delegate BindingList<Alarm> DisplayAllAlarmsDelegate();
    public delegate Alarm GetSelectedAlarmDelegate(int index);
    public delegate string UpdateAlarmStatusDelegate(Alarm alarm);
    public delegate void ShowAddViewDelegate();
    public delegate void ShowEditViewDelegate(Alarm alarm);
    //public delegate void SetOffAlarmDelegate(Alarm alarm);
    public delegate string SnoozeClickedDelegate();
    public delegate string StopClickedDelegate();
    //public delegate void CheckAlarmsDelegate(object sender, ElapsedEventArgs e);
    public delegate void WriteToCloseDelegate();

    //Contoller to AddEditView
    public delegate void GetAddEditFormDelegate(Alarm alarm);
    public delegate void UpdateAddingDelegate(bool adding);

    //AddEditView to Controller
    public delegate void ReturnNewAlarmDelegate(DateTime time, bool active, int snooze, SnoozeSounds sound);
    public delegate void EditExistingAlarmDelegate(DateTime time, bool active, int snooze, SnoozeSounds sound);

    //Controller to AlarmView
    //public delegate void AlarmSetOffDelegate(int index);
    public delegate void UpdateSelectionDelegate();




}
