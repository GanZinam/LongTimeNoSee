using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murder : MonoBehaviour {

    public GameObject MurderIcon;       // 암살 아이콘

	void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("MurderIn");
        if (other.gameObject.CompareTag("Player"))
        {
            MurderIcon.SetActive(true);
            SMng.Instance.Hero.GetComponent<Hero>().Police = transform.parent.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("MurderOut");
        if (other.gameObject.CompareTag("Player"))
        {
            MurderIcon.SetActive(false);
        }
    }
}
