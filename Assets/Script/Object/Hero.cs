﻿
using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{
    //@ 바라보고있는 방향
    public bool Right;
    public bool Left;


    public Vector3 outDoorPos;
    public int DoorType;

    public int Count;           // 에니매이션 몇번 돌았는지
    bool StairPos;

    public GameObject Police;          // 암살가능한 경찰
    public Animator PoliceAni;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("RoomRight") || other.gameObject.CompareTag("WallRight"))       // 벽이 왼쪽에있을때
        {
            SMng.Direction = 1;
        }
        else if (other.gameObject.CompareTag("RoomLeft") || other.gameObject.CompareTag("WallLeft"))   // 벽이 오른쪽에있을때
        {
            Debug.Log("LeftIn");
            SMng.Direction = 2;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("RoomRight") || other.gameObject.CompareTag("WallRight"))
        {
            SMng.Direction = 0;
        }
        else if (other.gameObject.CompareTag("RoomLeft") || other.gameObject.CompareTag("WallLeft"))
        {
            SMng.Direction = 0;
        }
    }


    public void SitDownFinish()
    {
        SMng.Instance.HeroAnimator.SetBool("Crouch", false);

        SMng.Instance.HeroAnimator.SetBool("CrouchBreath", true);
    }

    public void StandUpFinish()
    {
        SMng.Instance.HeroAnimator.SetBool("StandUp", false);

        SMng.Instance.HeroAnimator.SetBool("CrouchBreath", false);
    }

    // 애니메이션 끝날시 상태변화
    public void AniFinsh_statusCh()
    {

        SMng.Instance.hideWeapon.SetActive(false);
        SMng.interection = false;
        SMng.Direction = 0;
    }

    //@ 계단
    public void setOutDoorpostioin(int type)
    {
        DoorType = type;
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        Count = 0;
        if (type <= 4)
        {
            StairPos = true;
        }
    }

    public static int upSize = 6;

    public void StairUp()
    {
        if (StairPos)
        {
            if (Count < upSize)
            {
                if (DoorType.Equals(1) || DoorType.Equals(3))
                    SMng.Instance.Hero.transform.Translate(Vector3.up * 0.5f);
                else if (DoorType.Equals(2) || DoorType.Equals(4))
                    SMng.Instance.Hero.transform.Translate(Vector3.down * 0.5f);

                if (DoorType.Equals(1) || DoorType.Equals(2))
                {
                    SMng.Instance.Hero.transform.Translate(Vector3.right * 0.5f);
                    SMng.Instance.Hero.transform.localScale = new Vector2(0.5f, 0.5f);
                }
                else if (DoorType.Equals(3) || DoorType.Equals(4))
                {
                    SMng.Instance.Hero.transform.Translate(Vector3.left * 0.5f);
                    SMng.Instance.Hero.transform.localScale = new Vector2(-0.5f, 0.5f);
                }

                Count++;
            }
            else if (Count < upSize * 2)
            {
                if (DoorType.Equals(1) || DoorType.Equals(3))
                    SMng.Instance.Hero.transform.Translate(Vector3.up * 0.5f);
                else if (DoorType.Equals(2) || DoorType.Equals(4))
                    SMng.Instance.Hero.transform.Translate(Vector3.down * 0.5f);
                if (DoorType.Equals(1) || DoorType.Equals(2))
                {
                    SMng.Instance.Hero.transform.Translate(Vector3.left * 0.5f);
                    SMng.Instance.Hero.transform.localScale = new Vector2(-0.5f, 0.5f);
                }
                else if (DoorType.Equals(3) || DoorType.Equals(4))
                {
                    SMng.Instance.Hero.transform.Translate(Vector3.right * 0.5f);
                    SMng.Instance.Hero.transform.localScale = new Vector2(0.5f, 0.5f);
                }
                Count++;
            }
            else if (Count >= upSize * 2)      //계단 끝
            {
                GetComponent<BoxCollider2D>().isTrigger = false;
                GetComponent<Rigidbody2D>().gravityScale = 100;

                SMng.Instance.hideWeapon.SetActive(false);
                SMng.Direction = 0;
                if (SMng.Instance.HeroAnimator.GetBool("StairUp"))
                    SMng.Instance.HeroAnimator.SetBool("StairUp", false);
                if (SMng.Instance.HeroAnimator.GetBool("StairDown"))
                    SMng.Instance.HeroAnimator.SetBool("StairDown", false);
                Count = 0;
                StairPos = false;
            }
        }
        if (!StairPos)
        {
            if (DoorType.Equals(6) && Count.Equals(0))
            {
                SMng.Instance.Hero.transform.Translate(Vector3.left * 0.6f);
                SMng.Instance.Hero.transform.localScale = new Vector2(-0.5f, 0.5f);
            }
            if (Count < 3)
            {
                if (DoorType.Equals(5))
                    SMng.Instance.Hero.transform.Translate(Vector3.up * 0.3f);
                else if (DoorType.Equals(6) && Count != 0)
                    SMng.Instance.Hero.transform.Translate(Vector3.down * 0.3f);

                if (DoorType.Equals(5))
                {
                    SMng.Instance.Hero.transform.Translate(Vector3.right * 0.6f);
                    SMng.Instance.Hero.transform.localScale = new Vector2(0.5f, 0.5f);
                }
                else if (DoorType.Equals(6))
                {
                    SMng.Instance.Hero.transform.Translate(Vector3.left * 0.6f);
                    SMng.Instance.Hero.transform.localScale = new Vector2(-0.5f, 0.5f);
                }
                Count++;
            }
            else if (Count >= 3)      //계단 끝
            {
                if (DoorType.Equals(5))
                {
                    SMng.Instance.Hero.transform.Translate(Vector3.up * 0.3f);
                    SMng.Instance.Hero.transform.Translate(Vector3.right * 0.6f);
                    SMng.Instance.Hero.transform.localScale = new Vector2(0.5f, 0.5f);
                }
                else if (DoorType.Equals(6))
                {
                    SMng.Instance.Hero.transform.Translate(Vector3.down * 0.3f);
                    SMng.Instance.Hero.transform.Translate(Vector3.left * 0.6f);
                    SMng.Instance.Hero.transform.localScale = new Vector2(-0.5f, 0.5f);
                }
                GetComponent<BoxCollider2D>().isTrigger = false;
                GetComponent<Rigidbody2D>().gravityScale = 100;

                SMng.Instance.hideWeapon.SetActive(false);
                SMng.Direction = 0;
                if (SMng.Instance.HeroAnimator.GetBool("StairUp"))
                    SMng.Instance.HeroAnimator.SetBool("StairUp", false);
                if (SMng.Instance.HeroAnimator.GetBool("StairDown"))
                    SMng.Instance.HeroAnimator.SetBool("StairDown", false);
                Count = 0;
            }
        }


    }


    public void KillPolice()
    {
        if (Police != null)
        {
            PoliceAni = Police.GetComponent<Animator>();
            PoliceAni.SetBool("dieAni", true);
            Police.GetComponent<Police1>().Life = false;
            if (Police.transform.Find("LookPoint").gameObject != null)
            {
                GameObject Child = Police.transform.Find("LookPoint").gameObject;
                Child.SetActive(false);
            }
        }
    }
    public void KillFinish()
    {
        Police.GetComponent<Police1>().MurderStart = false;
        SMng.Instance.HeroAnimator.SetBool("Murder", false);
    }
}
