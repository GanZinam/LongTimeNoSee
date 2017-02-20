using UnityEngine;
using System.Collections;

public class SLock : MonoBehaviour
{
    public bool bLockCheck;
    Animator ani;
    public int nNum;
    public GameObject _RED;

    public GameObject Pinset;

    // Use this for initialization
    void Start()
    {
           ani = GetComponent<Animator>();
    }

    void Update()
    {
        if(nNum.Equals(1))
        {
            bLockCheck = false;
        }

        if(!bLockCheck)
        {
            _RED.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Pick"))
        {
            GM.AudioManager.instance.lockPick();
            ani.Rebind();
            ani.Play("ani1");
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
       if (Input.GetMouseButtonDown(0))
       {
            if (col.CompareTag("Pick") && bLockCheck)
            {
                ani.Stop();
                ani.Rebind();
                ani.Play("ani2");
                nNum = 1;
                GM.AudioManager.instance.lockPickDone();
            }

            if (col.CompareTag("Pick") && !bLockCheck)
            {
                SMng.Direction = 0;
                SMng.interection = false;
                transform.parent.parent.gameObject.SetActive(false);
                Pinset.transform.localPosition = new Vector2(Pinset.GetComponent<SPickMove>().fFirstXPos, Pinset.GetComponent<SPickMove>().fFirstYPos);
                SMng.Instance.nMini2Count = 0;
                Debug.Log("lock Game Over");
                transform.parent.GetComponent<SLockGroup>().Init();
                SMng.Instance.MiniGameStart = false;
            }
       }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (nNum.Equals(1))
        {
            SMng.Instance.nMini2Count++;
            nNum = 0;
        }
    }
}