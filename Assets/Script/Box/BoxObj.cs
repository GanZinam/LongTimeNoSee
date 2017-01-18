using UnityEngine;
using System.Collections;

public class BoxObj : MonoBehaviour {


    bool Stay = false;


    void Update()
    {
        if(Stay)
        {
            if (SMng.Instance.sit && !SMng.Instance.Hide)
            {
                Debug.Log("Hide = true");
                SMng.Instance.Hide = true;
            }
            else if(!SMng.Instance.sit && SMng.Instance.Hide)
            {
                Debug.Log("Hide = false");
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
                Debug.Log("Hide = true(Sit_In)");
                SMng.Instance.Hide = true;
            }
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideLeft"))
        {
            if (SMng.Instance.sit)
            {
                Debug.Log("Hide = true(Sit_In)");
                SMng.Instance.Hide = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideRight"))
        {
            Stay = true;
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideLeft"))
        {
            Stay = true;
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
