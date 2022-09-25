using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm501
{
    public class Alarm
    {

        private DateTime _now;

        private int _hours;
        private int _minutes;
        private int _seconds;
        private string _period;
        private bool _isActive;
        private int _snoozeLength;
        private SnoozeSounds _sound;
        private string _status;
        private string _statusTime;


        public Alarm(int hours, int mins, int secs, string period, bool isActive, int snoozeLength, SnoozeSounds sound)
        {
            Now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, mins, secs);

            if(hours > 12)
            {
                hours -= 12;
            }
            Hours = hours;
            Mins = mins;
            Secs = secs;
            Period = period;
            IsActive = isActive;
            SnoozeLength = snoozeLength;
            Sound = sound;

            StringBuilder sb = new StringBuilder();
            if (Hours < 10)
            {
                sb.Append('0');
            }
            sb.Append(Hours.ToString() + ':');
            if (Mins < 10)
            {
                sb.Append('0');
            }
            sb.Append(Mins.ToString() + " " + Period);
            StatusTime = sb.ToString();

            if (IsActive)
            {
                Status = ("Alarm for \n" + StatusTime + "\nis running...");
            }
            else
            {
                Status = ("Alarm for \n" + StatusTime + "\nis diabled...");
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Hours < 10)
            {
                sb.Append('0');
            }
            sb.Append(Hours.ToString() + ':');
            if (Mins < 10)
            {
                sb.Append('0');
            }
            sb.Append(Mins.ToString() + " " + Period);
            if (IsActive)
            {
                sb.Append(" -- ON");
            }
            else
            {
                sb.Append(" -- OFF");
            }

            return sb.ToString();
        }

        public string StatusTime
        {
            get { return _statusTime; }
            set { _statusTime = value; }
        }

        public DateTime Now
        {
            get { return _now; }
            set { _now = value; }
        }

        public int Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }

        public int Mins
        {
            get { return _minutes; }
            set { _minutes = value; }
        }

        public int Secs
        {
            get { return _seconds; }
            set { _seconds = value; }
        }

        public string Period
        {
            get { return _period; }
            set { _period = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public int SnoozeLength
        {
            get { return _snoozeLength;}
            set { _snoozeLength = value; }
        }

        public SnoozeSounds Sound
        {
            get { return _sound; }
            set { _sound = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }



    }
}
