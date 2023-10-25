using ShiftDemo.Director;
using ShiftDemo.Repos;
using ShiftDemo.Shifting;
using System.ComponentModel;

namespace ShiftDemo
{
    public partial class Form1 : Form
    {
        private IRahmenBuilder _rahmenBuilder;
        private RahmenDirector _rahmenDirector;
        private List<Shift> _shifts;
        private BackgroundWorker _shiftCotrol;
        private Shift _currentShift;
        public Form1()
        {


            InitializeComponent();
            _rahmenBuilder = new RahmenBuilder();
            _rahmenDirector = new RahmenDirector();
            _shifts = new List<Shift>();
            _shiftCotrol = new BackgroundWorker();
            _shiftCotrol.DoWork += _shiftCotrol_DoWork;
            _shiftCotrol.RunWorkerAsync();
            var shiftTimes = File.ReadAllLines(@"C:\Users\90552\Desktop\ShiftTimes.txt");
            seperateShift(shiftTimes);


        }

        private async void _shiftCotrol_DoWork(object? sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var currentShift = CurrentShift();
                if (_currentShift == null)
                {
                    _currentShift = currentShift;
                    continue;
                }
                if (_currentShift.StartedAt != currentShift.StartedAt)
                {
                    _currentShift = currentShift;
                    _rahmenDirector.IsDummyDone = false;
                }
                await Task.Delay(1000);
            }



        }
        private Shift CurrentShift()
        {

            var currentTime = DateTime.Now;
            foreach (var shift in _shifts)
            {
                var shiftStarted = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, shift.StartedAtHour, shift.StartedAtMinute, 0);
                var shiftEnded = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, shift.EndedAtHour, shift.EndedAtMinute, 0);
                if (currentTime > shiftStarted && currentTime < shiftEnded)
                {
                    return shift;

                }

            }
            return null;

        }

        private void seperateShift(string[] shiftTimes)
        {
            foreach (var shift in shiftTimes)
            {
                var splittedShiftTime = shift.Split('-');
                var startedTime = splittedShiftTime[0];
                var endedTime = splittedShiftTime[1];

                var createdShift = Shift.CreateShift(startedTime, endedTime);
                _shifts.Add(createdShift);
            }


        }

        private async void Request_Click(object sender, EventArgs e)
        {
            var eventNumber = (int)neEventNumber.Value;
            await _rahmenDirector.RunProgram(_rahmenBuilder, eventNumber);


        }

        private async void btnDummy_Click(object sender, EventArgs e)
        {
           // await _rahmenBuilder.DummyControl()
        }
    }
}