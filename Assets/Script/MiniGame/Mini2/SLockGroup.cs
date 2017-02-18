using UnityEngine;
using System.Collections;

public class SLockGroup : MonoBehaviour
{
    public SLock[] LockScrp = null;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (SMng.Instance.nMini2Count.Equals(3))
        {
            Debug.Log("Clear");
        }
    }

    void Init()
    {
        for (int i = 0; i < LockScrp.Length; i++)
        {
            if (i.Equals(0) || i.Equals(3) || i.Equals(5))
            {
                LockScrp[i].bLockCheck = true;
            }
            else
            {
                LockScrp[i].bLockCheck = false;
            }
        }
    }
}
