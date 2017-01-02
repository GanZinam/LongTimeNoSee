using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    public GameObject Move;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("RoomRight"))
        {
            Move.GetComponent<MoveBt>().Left_ = false;
            Move.GetComponent<MoveBt>().C_Left_ = true;
        }
        else if (other.gameObject.CompareTag("RoomLeft"))
        {
            Move.GetComponent<MoveBt>().Right_ = false;
            Move.GetComponent<MoveBt>().C_Right_ = true; 
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("RoomRight"))
        {
            Move.GetComponent<MoveBt>().C_Left_ = false;
        }
        else if (other.gameObject.CompareTag("RoomLeft"))
        {
            Move.GetComponent<MoveBt>().C_Right_ = false;
        }
    }
}
