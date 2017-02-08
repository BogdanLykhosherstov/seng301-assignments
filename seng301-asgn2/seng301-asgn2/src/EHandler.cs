using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend2.Hardware;


public class EHandler
{
    VendingMachine dummyVm;
    public EHandler(VendingMachine dummyVm)
    {
        this.dummyVm = dummyVm;
    }
    public void coinAddedReceptacle(object sender, CoinEventArgs e)
    {
        
            Console.WriteLine("Coin: " + e.Coin + " Accepted");
            dummyVm.CoinReceptacle.StoreCoins();
        
        
    }
    public void coinAddedStorageBin(object sender, CoinEventArgs e)
    {
        Console.WriteLine("Coin: " + e.Coin + " Accepted");

        dummyVm.StorageBin.StoreCoins();
    }



}

