using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oven
{
    public class SingleSloatToaster : Toaster
    {
        private SlotGroup SingleSlotGroup { get; }

        public Dialer Dialer { get; }

        public SingleSloatToaster()
        {
            // Set dialer with default time.
            Dialer = new Dialer(TimeSpan.FromMilliseconds(2000));

            // slot with default time to cook.
            SingleSlotGroup = new SlotGroup(Dialer);
            
        }

        public void AddItem(Item item)
        {
            SingleSlotGroup.AddItem(item);
        }

        public override async Task Toast(CancellationToken cancellationToken)
        {
            await SingleSlotGroup.Start(cancellationToken);
        }
    }
}
