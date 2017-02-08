using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murder : MonoBehaviour {

    public GameObject MurderIcon;       // 암살 아이콘

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("MurderIn");
            MurderIcon.SetActive(true);
            SMng.Instance.Hero.GetComponent<Hero>().Police = transform.parent.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("MurderOut");
            MurderIcon.SetActive(false);
        }
    }
}
