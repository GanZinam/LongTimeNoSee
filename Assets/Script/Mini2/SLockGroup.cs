using UnityEngine;
using System.Collections;

public class SLockGroup : MonoBehaviour
{
    public SLock[] LockScrp = null;

    void Update()
    {
        Init();
    }

    void Init()
    {
        for (int i = 0; i < LockScrp.Length; i++)
        {
            if(!LockScrp[i].bLockCheck)
            {
                LockScrp[i].nRand = Random.Range(0, 2);
                LockScrp[i].bLockCheck = true;
                break;
            }
        }
    }
}
