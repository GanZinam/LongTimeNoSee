using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameObj : MonoBehaviour {

    public GameObject MiniGameBt;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")&&!SMng.Instance.MGComplite[2])
        {
            MiniGameBt.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MiniGameBt.SetActive(false);
        }
    }
}
