﻿using UnityEngine;
using System.Collections;

public class DoorBt : MonoBehaviour
{
    public GameObject OutDoor;

    //1. 오른쪽 위로 , 2. 오른쪽 아래로 , 3. 왼쪽 위로 , 4. 왼쪽 아래로
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
                    //@아웃도어 포지션을 넘겨주는함수
                    hero.setOutDoorpostioin(OutDoor.transform.position, type);

                    SMng.Direction = 3;
                    if (type.Equals(1) || type.Equals(3))
                    {
                        SMng.Instance.HeroAnimator.SetBool("StairUp", true);
                    }
                    if (type.Equals(2) || type.Equals(4))
                    {
                        SMng.Instance.HeroAnimator.SetBool("StairDown", true);
                    }
                }
            }
        }
    }


}