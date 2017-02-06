using System;
using System.Collections.Generic;
using Frontend2;
using Frontend2.Hardware;


public class VendingMachineFactory : IVendingMachineFactory {

    List<VendingMachine> vendingMachines = new List<VendingMachine>();
    public static int ID = 0;

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
        dummyVm.CoinReceptacle.LoadCoins(coins);
        //getting the right coin rack from VM and then using its method to load coins
        //dummyVm.GetCoinRackForCoinKind(coinKindIndex).LoadCoins(coins);

        vendingMachines[vmIndex] = dummyVm;
    }

    public void LoadPops(int vmIndex, int popKindIndex, List<PopCan> pops) {
        // TODO: Implement
        VendingMachine dummyVm = vendingMachines[vmIndex];



        vendingMachines[vmIndex] = dummyVm;
    }

    public void InsertCoin(int vmIndex, Coin coin) {
        // TODO: Implement
        VendingMachine dummyVm = vendingMachines[vmIndex];



        vendingMachines[vmIndex] = dummyVm;
    }

    public void PressButton(int vmIndex, int value) {
        // TODO: Implement
        VendingMachine dummyVm = vendingMachines[vmIndex];



        vendingMachines[vmIndex] = dummyVm;
    }

    public List<IDeliverable> ExtractFromDeliveryChute(int vmIndex) {
        // TODO: Implement
        VendingMachine dummyVm = vendingMachines[vmIndex];



        vendingMachines[vmIndex] = dummyVm;
        return new List<IDeliverable>();
    }

    public VendingMachineStoredContents UnloadVendingMachine(int vmIndex) {
        // TODO: Implement
        VendingMachine dummyVm = vendingMachines[vmIndex];



        vendingMachines[vmIndex] = dummyVm;
        return new VendingMachineStoredContents();
    }
}