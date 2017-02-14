using UnityEngine;
using System.Collections;

public class DoorObject : MonoBehaviour
{

    public GameObject Doorin;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Doorin.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Doorin.SetActive(false);
        }
    }
}
