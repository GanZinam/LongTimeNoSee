using UnityEngine;
using System.Collections;

public class BoxObj : MonoBehaviour {

    public GameObject BoxInRight;
    public GameObject BoxInLeft;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")&&gameObject.CompareTag("BoxHideRight"))
        {

        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideLeft"))
        {

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideRight"))
        {
          
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideLeft"))
        {
            
        }
    }
}
