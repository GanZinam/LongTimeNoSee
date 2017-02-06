using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetBt : MonoBehaviour
{
    [SerializeField]
    GameObject intoObj;
    
    public Sprite OutSpr;
    public Sprite IntoSpr;

    [SerializeField]
    GameObject foundObj;
    [SerializeField]
    GameObject foundItemPopup;



    public int Num;     // 비어있는 캐비넷 100

    void Start()
    {

    }

    void Update()
    {
        // 문들어가는거 클릭
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.CompareTag("GoCabinet"))
                {
                    if (SMng.Instance.Hero_weapon.Equals(WEAPON.WEAPON_HAND))
                    {
                        // 찾기
                        if (Num.Equals(100))
                        {

                        }
                        else if (Num.Equals(12))
                        {
                            SMng.Instance._inventory.getItem(1);
                            SMng.Instance._inventory.getItem(2);
                        }
                        else if(Num.Equals(5))
                        {
                            SMng.Instance._inventory.getItem(5);
                        }
                        else
                        {
                            SMng.Instance._inventory.getItem(Num);
                        }
                    }
                    else if (SMng.Instance.Hero_weapon.Equals(WEAPON.WEAPON_GUN))
                    {
                        transform.parent.GetComponent<Animator>().SetBool("Cabinet", true);
                        // 들어가기
                        if (!SMng.Instance.Hide)
                        {
                            SMng.Instance.Hide = true;
                            SMng.Instance.Direction = 3;
                            SMng.Instance.HideWide = 0;
                            intoObj.GetComponent<SpriteRenderer>().sprite = OutSpr;
                        }
                        else
                        {
                            SMng.Instance.Hide = false;
                            SMng.Instance.Direction = 0;
                            SMng.Instance.HideWide = 1;
                            intoObj.GetComponent<SpriteRenderer>().sprite = IntoSpr;
                        }
                    }
                }
            }
        }
        if(SMng.Instance.CabinetChangeUI)
        {
            if(SMng.Instance.Hero_weapon.Equals(WEAPON.WEAPON_GUN))
            {
                intoObj.SetActive(true);
                foundObj.SetActive(false);
            }
            else if(SMng.Instance.Hero_weapon.Equals(WEAPON.WEAPON_HAND))
            {
                foundObj.SetActive(true);
                intoObj.SetActive(false);
            }
        }
    }

    public void ExitBt()
    {
        SMng.Instance.Direction = 0;
    }

}
