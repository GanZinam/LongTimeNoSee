using UnityEngine;
using System.Collections;

public class BoxObj : MonoBehaviour
{
    bool Stay_right = false;
    bool Stay_left = false;

    void Update()
    {
        if (Stay_right)
        {
            if (SMng.sit && !SMng.Hide)
            {
                SMng.Hide = true;
                SMng.Hide_right = true;
                HeroAlpha_Hide();
            }
            else if (!SMng.sit && SMng.Hide)
            {
                SMng.Hide = false;
                SMng.Hide_right = false;
                HeroAlpha_UnHide();
            }
        }
        if (Stay_left)
        {
            if (SMng.sit && !SMng.Hide)
            {
                SMng.Hide = true;
                SMng.Hide_left = true;
                HeroAlpha_Hide();
            }
            else if (!SMng.sit && SMng.Hide)
            {
                SMng.Hide = false;
                SMng.Hide_left = false;
                HeroAlpha_UnHide();
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideRight"))
        {
            if (SMng.sit)
            {
                SMng.Hide = true;
                SMng.Hide_right = true;
                HeroAlpha_Hide();
            }
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideLeft"))
        {
            if (SMng.sit)
            {
                SMng.Hide = true;
                SMng.Hide_left = true;
                HeroAlpha_Hide();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideRight"))
        {
            Stay_right = true;
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideLeft"))
        {
            Stay_left = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideRight"))
        {
            if (!SMng.Hide_left)
            {
                SMng.Hide = false;
                HeroAlpha_UnHide();
            }
            SMng.Hide_right = false;
            Stay_right = false;
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("BoxHideLeft"))
        {
            if (!SMng.Hide_right)
            {
                SMng.Hide = false;
                HeroAlpha_UnHide();
            }
            SMng.Hide_left = false;
            Stay_left = false;
        }
    }
    void HeroAlpha_Hide()
    {
        SMng.Instance.Hero.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
    }

    void HeroAlpha_UnHide()
    {
        SMng.Instance.Hero.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
    }
}
