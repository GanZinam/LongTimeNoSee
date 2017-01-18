using UnityEngine;
using System.Collections;

public class DoorBt : MonoBehaviour
{

    public GameObject OutDoor;

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
                    //@아웃도어 포지션을 넘겨주는함수
                    hero.setOutDoorpostioin(OutDoor.transform.position);  
  
                    SMng.Instance.Direction = 3;
                    SMng.Instance.HeroAnimator.SetBool("StairUp",true);
                    //SMng.Instance.Direction = 0;
                }
            }
        }
    }

    
}