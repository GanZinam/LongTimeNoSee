using UnityEngine;
using System.Collections;

public class DoorObject : MonoBehaviour
{

    public GameObject Doorin;
    public GameObject MiniGameBt;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MiniGameBt.SetActive(true);
            Doorin.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MiniGameBt.SetActive(false);
            Doorin.SetActive(false);
        }
    }
}
