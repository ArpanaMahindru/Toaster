## Oven

This project represents cooking food like bread, beagle in toaster.

how to use:

### Create instance on toaster.
SingleSloatToaster singleSloatToaster = new SingleSloatToaster();

#### Add item to toaster.
singleSloatToaster.AddItem(new Item("Bread"));

singleSloatToaster.AddItem(new Item("Beagle"));

#### Set dialer to cook.
singleSloatToaster.Dialer.SetTimer(TimeSpan.FromSeconds(5));


#### Toast to yummy food.
await singleSloatToaster.Toast(new System.Threading.CancellationToken());