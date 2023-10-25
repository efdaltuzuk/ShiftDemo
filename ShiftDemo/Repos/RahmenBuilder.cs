using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftDemo.Repos
{
    public class RahmenBuilder : IRahmenBuilder
    {
        public Task GrabImage()
        {
            MessageBox.Show("Burdayım be burdayım");
            return Task.CompletedTask;
        }

        public Task DummyControl()
        {
            MessageBox.Show("Dummy isteği yapıldı");
            return Task.CompletedTask;
        }
    }
}
