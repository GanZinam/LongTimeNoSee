using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGet : MonoBehaviour
{
    public int itemCode;

    public void click()
    {
        SMng.Instance._inventory.getItem(itemCode);
        itemCode = 0;
    }
}
