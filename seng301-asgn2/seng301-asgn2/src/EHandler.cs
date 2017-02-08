using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend2.Hardware;


public class EHandler
{
    VendingMachine dummyVm;
    bool receptacleFullFlag = false;
    public EHandler(VendingMachine dummyVm)
    {
        this.dummyVm = dummyVm;
    }
    public void coinAdded(object sender, CoinEventArgs e)
    {
        if (!receptacleFullFlag)
        {
            Console.WriteLine("Coin: " + e.Coin + " Accepted");
            dummyVm.CoinReceptacle.StoreCoins();
        }
        
    }
    public void receptacleFull(object sender, EventArgs e)
    {
        this.receptacleFullFlag = true;
    }



}

