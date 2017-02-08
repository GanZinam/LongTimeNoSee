using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    [SerializeField]
    GameObject intoObj;
    [SerializeField]
    GameObject foundObj;
    [SerializeField]
    GameObject murderObj;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SMng.Instance.CabinetIn = true;

            if (SMng.Hero_weapon.Equals(WEAPON.WEAPON_HAND))
            {
                // 찾기
                foundObj.SetActive(true);

            }
            else if (SMng.Hero_weapon.Equals(WEAPON.WEAPON_GUN))
            {
                // 들어가기
                intoObj.SetActive(true);
            }
        }
        if(other.gameObject.CompareTag("Police"))
        {
            if (SMng.HideWide.Equals(0))
            {
                murderObj.SetActive(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SMng.Instance.CabinetIn = false;
            foundObj.SetActive(false);
            intoObj.SetActive(false);
        }
    }

    void CabinetIn()
    {
        if (SMng.Hide)
        {
            SMng.Instance.Hero.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
        }
        else
        {
            SMng.Instance.Hero.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
        }
    }

    void Cabinetbool()
    {
        transform.GetComponent<Animator>().SetBool("Cabinet", false);
    }
}
