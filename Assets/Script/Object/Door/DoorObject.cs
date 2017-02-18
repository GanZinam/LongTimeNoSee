using UnityEngine;
using System.Collections;

public class DoorObject : MonoBehaviour
{

    public GameObject Doorin;
    public bool MinigameDoor;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(MinigameDoor)
        {
            if (SMng.Instance.MGComplite[2]&&other.gameObject.CompareTag("Player"))
            {
                Doorin.SetActive(true);
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Doorin.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (MinigameDoor)
        {
            if (SMng.Instance.MGComplite[2] && other.gameObject.CompareTag("Player"))
            {
                Doorin.SetActive(false);
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Doorin.SetActive(false);
        }
    }
}
