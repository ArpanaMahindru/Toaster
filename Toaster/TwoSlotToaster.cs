using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oven
{
    public class TwoSlotToaster : Toaster
    {
        private SlotGroup LeftSlotGroup { get; }

        private SlotGroup RightSlotGroup { get; }

        public Dialer LeftDialer { get; }

        public Dialer RightDialer { get; }

        public TwoSlotToaster()
        {
            // Set dialer with default time.
            LeftDialer = new Dialer(TimeSpan.FromMilliseconds(2000));
            LeftSlotGroup = new SlotGroup(LeftDialer);

            // Set dialer with default time.
            RightDialer = new Dialer(TimeSpan.FromMilliseconds(2000));
            RightSlotGroup = new SlotGroup(RightDialer);
        }

        public void AddItemtoLeftSlot(Item item)
        {
            LeftSlotGroup.AddItem(item);
        }

        public void AddItemtoRightSlot(Item item)
        {
            RightSlotGroup.AddItem(item);
        }

        public override async Task Toast(CancellationToken cancellationToken)
        {
            await LeftSlotGroup.Start(cancellationToken);

            await RightSlotGroup.Start(cancellationToken);
        }
    }
}
