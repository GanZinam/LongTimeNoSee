using UnityEngine;
using System.Collections;

public class BoxObj : MonoBehaviour {

    public GameObject BoxInRight;
    public GameObject BoxInLeft;

    bool Stay = false;


    void Update()
    {
        if(Stay)
        {
            if (SMng.Instance.sit)
            {
                SMng.Instance.Hide = true;
            }
            else
            {
                SMng.Instance.Hide = false;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")&&gameObject.CompareTag("BoxHideRight"))
        {
            if(SMng.Instance.sit)
            {
                SMng.Instance.Hide = true;
            }
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideLeft"))
        {
            if (SMng.Instance.sit)
            {
                SMng.Instance.Hide = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideRight"))
        {
            if (SMng.Instance.sit)
            {
                Stay = true;
            }
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideLeft"))
        {
            if (SMng.Instance.sit)
            {
                Stay = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideRight"))
        {
            SMng.Instance.Hide = false;
            Stay = false;
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideLeft"))
        {
            SMng.Instance.Hide = false;
            Stay = false;
            
        }
    }
}
