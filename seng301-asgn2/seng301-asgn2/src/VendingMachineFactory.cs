using System;
using System.Collections.Generic;
using Frontend2;
using Frontend2.Hardware;
using System.Linq;

//nice meme
public class VendingMachineFactory : IVendingMachineFactory {

    List<VendingMachine> vendingMachines = new List<VendingMachine>();
    public static int ID = 0;
    public List<Coin> coinsEntered = new List<Coin>();

    public int CreateVendingMachine(List<int> coinKinds, int selectionButtonCount, int coinRackCapacity, int popRackCapcity, int receptacleCapacity)
    {
        // TODO: Implement

        vendingMachines.Add(new VendingMachine(coinKinds.ToArray(), selectionButtonCount, coinRackCapacity, popRackCapcity, receptacleCapacity));
        return ++ID;
    }

    public void ConfigureVendingMachine(int vmIndex, List<string> popNames, List<int> popCosts)
    {
        VendingMachine dummyVm = vendingMachines[vmIndex];
        dummyVm.Configure(popNames, popCosts);
        vendingMachines[vmIndex] = dummyVm;
           
    }
    public void LoadCoins(int vmIndex, int coinKindIndex, List<Coin> coins) {
        // TODO: Implement
        VendingMachine dummyVm = vendingMachines[vmIndex];

        //getting the right coin rack from VM and then using its method to load coins
        //1. First the value of the coin
        int kind = dummyVm.GetCoinKindForCoinRack(coinKindIndex);
        //2. Then we access the coin rack by value and load stuff into there
        (dummyVm.GetCoinRackForCoinKind(kind)).LoadCoins(coins);
        vendingMachines[vmIndex] = dummyVm;
    }

    public void LoadPops(int vmIndex, int popKindIndex, List<PopCan> pops) {
        // TODO: Implement
        VendingMachine dummyVm = vendingMachines[vmIndex];
        //Same procedure as with the coin rack
        dummyVm.PopCanRacks[popKindIndex].LoadPops(pops);

        vendingMachines[vmIndex] = dummyVm;
    }
    int total = 0;
    public void InsertCoin(int vmIndex, Coin coin) {
        // TODO: Implement
        VendingMachine dummyVm = vendingMachines[vmIndex];
        EHandler test = new EHandler(dummyVm, this);
        //1. Goto Coin slot -> Coin rack -> Appropriate slot based on response
        //2. Sub and then unsub the events after youre done
        dummyVm.CoinReceptacle.CoinAdded += new EventHandler<CoinEventArgs>(test.coinAddedReceptacle);
        dummyVm.StorageBin.CoinAdded += new EventHandler<CoinEventArgs>(test.coinAddedStorageBin);
        dummyVm.CoinSlot.AddCoin(coin);
        total += coin.Value;

        vendingMachines[vmIndex] = dummyVm;
    }
    
    public void PressButton(int vmIndex, int value)
    {
        // TODO: Implement
        VendingMachine dummyVm = vendingMachines[vmIndex];
        EHandler temp = new EHandler(dummyVm, this);

        dummyVm.SelectionButtons[value].Pressed += new EventHandler(temp.printButtonPressed);
        dummyVm.SelectionButtons[value].Press();
        dummyVm.SelectionButtons[value].Pressed -= new EventHandler(temp.printButtonPressed);


        if (dummyVm.CoinReceptacle.Count != 0 && total >= dummyVm.PopCanCosts[value])
        {

            var changedNeeded = total - (dummyVm.PopCanCosts[value]);

            //dummyVm.CoinReceptacle.ReceptacleFull += new EventHandler(temp.CoinReceptacle_ReceptacleFull);
            //var.CoinReceptacle.StoreCoins();
            //var.CoinReceptacle.ReceptacleFull -= new EventHandler(temp.CoinReceptacle_ReceptacleFull);


            var temp2 = dummyVm.PopCanRacks;
            temp2[value].DispensePopCan();

            List<int> b = new List<int>();
            int length = dummyVm.CoinRacks.Length;

            for (int i = 0; i < length; i++)
            {
                b.Add(dummyVm.GetCoinKindForCoinRack(i));
            }

            b.Sort();

            for (int i = b.Count - 1; i >= 0; i--)
            {
                int jk = b[i];
                while (changedNeeded % jk == 0 && changedNeeded != 0)
                {
                    dummyVm.GetCoinRackForCoinKind(jk).ReleaseCoin();

                    changedNeeded -= jk;
                }

                if (changedNeeded % jk != 0 && changedNeeded > jk)
                {
                    dummyVm.GetCoinRackForCoinKind(jk).ReleaseCoin();
                    changedNeeded -= jk;
                }

            }
            dummyVm.CoinReceptacle.StoreCoins();
            total = 0;

        }

    }

   

    public List<IDeliverable> ExtractFromDeliveryChute(int vmIndex) {
        // TODO: Implement
        VendingMachine dummyVm = vendingMachines[vmIndex];

        List<IDeliverable> extracted = new List<IDeliverable>();
        IDeliverable[] test = dummyVm.DeliveryChute.RemoveItems();
        extracted = test.ToList();
        vendingMachines[vmIndex] = dummyVm;

        return extracted;
    }

    public VendingMachineStoredContents UnloadVendingMachine(int vmIndex) {
        // TODO: Implement
        VendingMachine dummyVm = vendingMachines[vmIndex];

        VendingMachineStoredContents unloader = new VendingMachineStoredContents();
        foreach (var rack in dummyVm.CoinRacks)
        {
            
        }

        vendingMachines[vmIndex] = dummyVm;
        return unloader;
    }
}