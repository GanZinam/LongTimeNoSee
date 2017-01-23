using UnityEngine;
using System.Collections;

public class BoxObj : MonoBehaviour
{
    bool Stay_right = false;
    bool Stay_left = false;

    void Update()
    {
        if (Stay_right)
        {
            if (SMng.Instance.sit && !SMng.Instance.Hide)
            {
                SMng.Instance.Hide = true;
                SMng.Instance.Hide_right = true;
            }
            else if (!SMng.Instance.sit && SMng.Instance.Hide)
            {
                SMng.Instance.Hide = false;
                SMng.Instance.Hide_right = false;
            }
        }
        if (Stay_left)
        {
            if (SMng.Instance.sit && !SMng.Instance.Hide)
            {
                SMng.Instance.Hide = true;
                SMng.Instance.Hide_left = true;
            }
            else if (!SMng.Instance.sit && SMng.Instance.Hide)
            {
                SMng.Instance.Hide = false;
                SMng.Instance.Hide_left = false;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideRight"))
        {
            if (SMng.Instance.sit)
            {
                SMng.Instance.Hide = true;
                SMng.Instance.Hide_right = true;
            }
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideLeft"))
        {
            if (SMng.Instance.sit)
            {
                SMng.Instance.Hide = true;
                SMng.Instance.Hide_left = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideRight"))
        {
            Stay_right = true;
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideLeft"))
        {
            Stay_left = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideRight"))
        {
            if (!SMng.Instance.Hide_left)
                SMng.Instance.Hide = false;

            SMng.Instance.Hide_right = false;
            Stay_right = false;
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideLeft"))
        {
            if (!SMng.Instance.Hide_right)
                SMng.Instance.Hide = false;
            SMng.Instance.Hide_left = false;
            Stay_left = false;
        }
    }
}
