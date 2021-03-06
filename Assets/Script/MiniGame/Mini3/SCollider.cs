﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCollider : MonoBehaviour
{
    public Camera UICam = null;     // 카메라
    RaycastHit2D Ray;
    public int nCount;              // 책 클릭

    public GameObject MiniGame3;

    public GameObject[] SelectGame = null;

    public Animator BookDoorAni;

    void Start()
    {
        nCount = 0;
    }

    void Update()
    {
        Ray = GetHitInfo();

        if (Ray.collider != null)
        {
            Debug.Log(Ray.collider.tag);
            if (Input.GetMouseButtonDown(0))
            {
                if (Ray.collider.CompareTag("Book") && nCount.Equals(0))        // 첫번째 책 클릭
                {
                    SelectGame[0].SetActive(true);
                    nCount++;
                    Debug.Log("BookClick");
                }

                if(Ray.collider.CompareTag("Box"))      // 끝나는조건
                {
                    Debug.Log("Game Over");
                }

                if (Ray.collider.CompareTag("Book1") && nCount.Equals(1))        // 두번째 책 클릭
                {
                    SelectGame[1].SetActive(true);
                    Debug.Log("Book2Click");
                    SMng.Instance.MGComplite[2] = true;
                    MiniGame3.SetActive(false);
                    SMng.Direction = 0;
                    BookDoorAni.SetBool("BookInto",true);
                }
                else if(Ray.collider.CompareTag("Book1")&&nCount.Equals(0))         // 끝나는조건
                {
                    Debug.Log("Game Over");
                }
            }
        }

    }

    RaycastHit2D GetHitInfo()
    {
        Vector2 ClickPosVec2 = UICam.ScreenToWorldPoint(Input.mousePosition);

        Ray2D ClickRay = new Ray2D(ClickPosVec2, Vector2.zero);
        RaycastHit2D Hit2D = Physics2D.Raycast(ClickRay.origin, ClickRay.direction);

        if (Hit2D.collider != null)
        {
            //Debug.Log(Hit2D.collider.tag);

            return Hit2D;
        }
        return Hit2D;
    }
}
