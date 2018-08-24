using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spelprojekt.Services
{
    public class ScoreService
    {
        public int LineMoved => 1;
        public int CompletedLine => 10;

        public Stopwatch StopWatch => new Stopwatch();

        public void StartTheWatch()
        { 
            StopWatch.Start();
        }

        public void StopTheWatch()
        {
            StopWatch.Stop();
        }

        public long GetTheTime()
        {
           return StopWatch.ElapsedTicks;
        }



    }
}
