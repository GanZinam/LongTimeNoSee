using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerItemGet : MonoBehaviour
{
    public int itemCode = 100;

    public void itemGET()
    {
        SMng.Instance._inventory.getItem(itemCode);
        itemCode = 100;
    }

}
