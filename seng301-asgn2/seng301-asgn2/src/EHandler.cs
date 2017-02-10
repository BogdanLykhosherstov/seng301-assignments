using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend2.Hardware;


public class EHandler
{
    VendingMachineFactory vendingMachineFactory;
    VendingMachine dummyVm;
    public EHandler(VendingMachine dummyVm, VendingMachineFactory vendingMachineFactory)
    {
        this.vendingMachineFactory = vendingMachineFactory;
        this.dummyVm = dummyVm;
    }
    public void coinAddedReceptacle(object sender, CoinEventArgs e)
    {
        
            Console.WriteLine("Coin: " + e.Coin + " Accepted for coin receptacle");
            vendingMachineFactory.coinsEntered.Add(e.Coin);
        
        
    }
    public void coinAddedStorageBin(object sender, CoinEventArgs e)
    {
        Console.WriteLine("Coin: " + e.Coin + " Accepted for storage bin");

        
    }
    public void printButtonPressed(object sender, EventArgs e)
    {
        Console.WriteLine("Button pressed");
    }



}

