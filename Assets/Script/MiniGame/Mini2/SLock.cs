using UnityEngine;
using System.Collections;

public class SLock : MonoBehaviour
{
    public bool bLockCheck;
    public Animator ani;
    public int nNum;

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
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Pick"))
        {
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
                //bLockCheck = false;
            }

            if (col.CompareTag("Pick") && !bLockCheck)
            {
                //Time.timeScale = 0f;
                Debug.Log("lock Game Over");
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