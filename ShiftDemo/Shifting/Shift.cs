using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftDemo.Shifting
{
    public class Shift
    {
        public Shift(string startedAt, string endedAt)
        {
            StartedAt = startedAt;
            EndedAt = endedAt;
            var startedTime = SetTimes(StartedAt);
            var endedTime = SetTimes(EndedAt);

            StartedAtHour = int.Parse(startedTime[0]);
            StartedAtMinute = int.Parse(startedTime[1]);
            
            EndedAtHour = int.Parse(endedTime[0]);
            EndedAtMinute = int.Parse(endedTime[1]);
           
        }
        public string StartedAt { get; set; }
        public string EndedAt { get; set; }
        public int StartedAtHour {get;}
        public int StartedAtMinute {get;}
        public int EndedAtHour {get;}
        public int EndedAtMinute {get;}


        public static Shift CreateShift(string startedAt, string endedAt)
        {
            return new Shift(startedAt, endedAt);

        }

        public string[] SetTimes(string time)
        {
            var timeArr = time.Split(':');
            return timeArr;
           
        }


    }
}
