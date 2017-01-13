using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    public bool RoomInit;       // 방안에 들어갔나 나왔나

    //@ 바라보고있는 방향
    public bool Right;
    public bool Left;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("RoomRight")||other.gameObject.CompareTag("WallRight"))       // 벽이 왼쪽에있을때
        {
            SMng.Instance.Direction = 1;
        }
        else if (other.gameObject.CompareTag("RoomLeft") || other.gameObject.CompareTag("WallLeft"))   // 벽이 오른쪽에있을때
        {
            Debug.Log("LeftIn");
            SMng.Instance.Direction = 2;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("RoomRight") || other.gameObject.CompareTag("WallRight"))
        {
            SMng.Instance.Direction = 0;
        }
        else if (other.gameObject.CompareTag("RoomLeft") || other.gameObject.CompareTag("WallLeft"))
        {
            SMng.Instance.Direction = 0;
        }
    }

    public void SitDownFinish()
    {
        SMng.Instance.HeroAnimator.SetBool("Crouch", false);

        SMng.Instance.HeroAnimator.SetBool("CrouchBreath", true);
    }

    public void StandUpFinish()
    {
        SMng.Instance.HeroAnimator.SetBool("StandUp",false);

        SMng.Instance.HeroAnimator.SetBool("CrouchBreath", false);
    }
}