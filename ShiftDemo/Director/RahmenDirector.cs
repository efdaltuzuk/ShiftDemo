using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftDemo.Repos;

namespace ShiftDemo.Director
{
    public class RahmenDirector
    {
        public bool IsDummyDone { get; set; }
        public async Task RunProgram(IRahmenBuilder rahmenBuilder, int eventNumber)
        {
            if (!IsDummyDone)
            {
                await rahmenBuilder.DummyControl();
                IsDummyDone = true;
                MessageBox.Show("Dummy geçir aloooo");
                return;
            }
            switch (eventNumber)
            {
                case 0:
                    break;

                case 1:
                    break;
                case 2:
                    await rahmenBuilder.GrabImage();
                    break;
                default:
                    break;
            }

        }
    }
}
