using System;
using System.Threading.Tasks;

namespace Oven
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SingleSloatToaster singleSloatToaster = new SingleSloatToaster();

            singleSloatToaster.AddItem(new Item("Bread"));

            singleSloatToaster.AddItem(new Item("Beagle"));

            singleSloatToaster.Dialer.SetTimer(TimeSpan.FromSeconds(5));

            await singleSloatToaster.Toast(new System.Threading.CancellationToken());
        }

    }
}
