using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Problem_3.Asynchronous_Timer
{
    class AsyncTimer
    {
        private Action _action;
        private int ticks;
        private double time;
        private int counter;
        private Timer aTimer;
        public AsyncTimer(int ticks, double time, Action action)
        {
            this.Action = action;
            this.Ticks = ticks;
            this.Time = time;
            this.counter = ticks;
            this.aTimer = new System.Timers.Timer(this.time);
        }

        public Action Action
        {
            get
            {
                return this._action;
            }
            set
            {
                this._action = value;
            }
        }
        public int Ticks
        {
            get
            {
                return this.ticks;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Ticks can't be less than 0");
                this.ticks = value;
            }
        }
        public double Time
        {
            get
            {
                return this.time;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Miliseconds can't be less than 0");
                this.time = value;
            }
        }

        public void Run()
        {
            aTimer.Elapsed += (OnTimeEvent);

            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            this.Action();
            if (this.counter <= 1)
            {
                aTimer.AutoReset = false;
                aTimer.Enabled = false;
            }
            this.counter--;

        }

    }

}