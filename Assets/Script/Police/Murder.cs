using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murder : MonoBehaviour
{

    public GameObject MurderIcon;       // 암살 아이콘

    void Update()
    {
        if (transform.parent.GetComponent<Police1>().MurderStart)
        {
            MurderIcon.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && transform.parent.GetComponent<Police1>().Life && SMng.Hero_weapon.Equals(WEAPON.WEAPON_GUN) && (!SMng.Hide || SMng.RoomInit.Equals(true)))
        {
            Debug.Log("MurderIn");
            MurderIcon.SetActive(true);
            SMng.Instance.Hero.GetComponent<Hero>().Police = transform.parent.gameObject;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (SMng.HideWide.Equals(0) || !transform.parent.GetComponent<Police1>().Life || SMng.Hero_weapon.Equals(WEAPON.WEAPON_HAND) || SMng.Hide || SMng.RoomInit.Equals(true))
            {
                MurderIcon.SetActive(false);
            }
            else if (SMng.HideWide.Equals(1) && transform.parent.GetComponent<Police1>().Life && SMng.Hero_weapon.Equals(WEAPON.WEAPON_GUN) && (!SMng.Hide || SMng.RoomInit.Equals(false)))
            {
                MurderIcon.SetActive(true);
                SMng.Instance.Hero.GetComponent<Hero>().Police = transform.parent.gameObject;
            }
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
