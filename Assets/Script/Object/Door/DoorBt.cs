using UnityEngine;
using System.Collections;

public class DoorBt : MonoBehaviour
{
    //1. 오른쪽 위로 , 2. 오른쪽 아래로 , 3. 왼쪽 위로 , 4. 왼쪽 아래로 5. 오른쪽위 (3칸) 6. 왼쪽아래 (3칸)
    public int type;

    Hero hero;

    void Start()
    {
        hero = FindObjectOfType<Hero>();
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
                if (hit.transform.CompareTag("GoDoor"))
                {
                    GM.AudioManager.instance.stair();
                    //@아웃도어 포지션을 넘겨주는함수
                    hero.setOutDoorpostioin(type);

                    SMng.Instance.hideWeapon.SetActive(true);
                    SMng.Direction = 3;
                    if (type.Equals(1) || type.Equals(3)||type.Equals(5))
                    {
                        SMng.Instance.HeroAnimator.SetBool("StairUp", true);
                    }
                    if (type.Equals(2) || type.Equals(4) || type.Equals(6))
                    {
                        SMng.Instance.HeroAnimator.SetBool("StairDown", true);
                    }
                }
            }
        }
    }


}