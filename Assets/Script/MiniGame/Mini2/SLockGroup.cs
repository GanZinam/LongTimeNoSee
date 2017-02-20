using UnityEngine;
using System.Collections;

public class SLockGroup : MonoBehaviour
{
    public SLock[] LockScrp = null;
    bool Clear = true;
    
    public GameObject LockDoor;

    public Sprite DoorIntoSpr;
    public GameObject DoorIntoObj;

    [SerializeField]
    GameObject[] redOBJ;

    public GameObject[] _RED;



    void Start()
    {
        Init();
    }

    void Update()
    {
        if (Clear&&SMng.Instance.nMini2Count.Equals(3))
        {
            Clear = false;
            Debug.Log("Clear");
            SMng.Instance.MGComplite[1] = true;
            SMng.Direction = 0;
            SMng.interection = false;
            SMng.Instance.nMini2Count = 0;
            transform.parent.gameObject.SetActive(false);
            DoorIntoObj.GetComponent<SpriteRenderer>().sprite = DoorIntoSpr;
            LockDoor.SetActive(true);
            SMng.Instance.MiniGameStart = false;
        }
    }

    public void Init()
    {
        for (int i = 0; i < LockScrp.Length; i++)
        {
            if (i.Equals(0) || i.Equals(3) || i.Equals(5))
            {
                LockScrp[i].bLockCheck = true;
                _RED[i].SetActive(false);
            }
            else
            {
                LockScrp[i].bLockCheck = false;
            }
        }
    }
}
