using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Timers;

namespace Oven
{
    public class SlotGroup
    {
        //private TimeSpan? _heatTime;
        //private static System.Timers.Timer aTimer;
        private CancellationToken? _cancellationToken;
        private bool _keepCooking;
        private readonly Dialer _dialer;

        /// <summary>
        /// Slot group to cook item.
        /// </summary>
        /// <param name="heatTime"></param>
        public SlotGroup(Dialer dialer)
        {
            _dialer = dialer;
            Slot1 = new Slot();
            Slot2 = new Slot();
        }

        public Slot Slot1 { get; }

        public Slot Slot2 { get; }

        public async Task Start(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;


            // No food to cook.
            if (!Slot1.HasItem() || !Slot2.HasItem())
            {
                _keepCooking = false;

                Console.WriteLine("No food to cook");
            }


            var task = Task.Run(() => {
                // we already cancelled
                _cancellationToken?.ThrowIfCancellationRequested();
                
                _keepCooking = true;

                while (_keepCooking)
                {
                    Console.WriteLine($"{Slot1.Item.Name} & {Slot2.Item.Name} is being cooked");

                    if (_cancellationToken.HasValue && _cancellationToken.Value.IsCancellationRequested)
                    {
                        _cancellationToken?.ThrowIfCancellationRequested();
                    }
                }

            });

            try
            {
                _dialer.CookTimer.Elapsed += OnTimedEvent;

                await task;

                Console.WriteLine($"{Slot1.Item.Name} & {Slot2.Item.Name} is cooked");
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {e.Message}");
            }
        }

        public bool AddItem(Item item)
        {
            if (Slot1.CanAddItem())
            {
                Slot1.AddItem(item);
                return true;
            }

            if (Slot2.CanAddItem())
            {
                Slot2.AddItem(item);
                return true;
            }

            return false;
        }

        public void Cancel()
        {
            _keepCooking = false;
            //_heatTime = null;
            _cancellationToken = null;
        }


        //private void SetTimer()
        //{
        //    if (_heatTime.HasValue)
        //    {
        //        // Create a timer with a two second interval.
        //        aTimer = new System.Timers.Timer(_heatTime.Value.TotalMilliseconds);
        //        // Hook up the Elapsed event for the timer. 
        //        aTimer.Elapsed += OnTimedEvent;
        //        aTimer.AutoReset = true;
        //        aTimer.Enabled = true;
        //    }
        //}

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                             e.SignalTime);

            _keepCooking = false;

            Console.WriteLine("Item is cooked.");
        }

        //public void SetTimer(TimeSpan heatTime)
        //{
        //    _heatTime = heatTime;
        //}
    }
}
