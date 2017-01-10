using UnityEngine;
using System.Collections;

public class MoveBt : MonoBehaviour
{

    public GameObject Hero;
    //@ 버튼
    public bool Right_;
    public bool Left_;

    public bool isClick = false;        //클릭 했는지 않했는지
    // 0 = 아무대도아닌상태 1= 오른쪽 2 = 왼쪽
    public int Direction = 0;

    //@ Collision으로 들어올때
    public bool C_Right_ = false;
    public bool C_Left_ = false;

    // 주인공 애니메이션
    public Animator HeroAnimator;

    Vector3 RotateHero;

    public void PointerDown()
    {
        isClick = true;
    }

    public void PointerUp()
    {
        isClick = false;
    }

    public void RightBt_in()
    {
        if (!C_Right_)
            Direction = 1;
    }

    public void RightBt_out()
    {
        Direction = 0;
    }

    public void LeftBt_in()
    {
        if (!C_Left_)
            Direction = 2;
    }

    public void LeftBt_out()
    {
        Direction = 0;
    }
    void Update()
    {
        if (isClick && Direction.Equals(1) && !Right_)
        {
            Hero.transform.Translate(0.05f, 0, 0);

            Hero.transform.rotation = Quaternion.Euler(Hero.transform.rotation.x, Hero.transform.rotation.y, RotateHero.z);
            if (!HeroAnimator.GetBool("Walk"))
            {
                HeroAnimator.SetBool("Walk", true);
            }
        }

        if (isClick && Direction.Equals(2) && !Left_)
        {
            Hero.transform.Translate(0.05f, 0, 0);

            Hero.transform.rotation = Quaternion.Euler(Hero.transform.rotation.x, Hero.transform.rotation.y - 180, RotateHero.z);
            if (!HeroAnimator.GetBool("Walk"))
            {
                HeroAnimator.SetBool("Walk", true);
            }
        }

        if (!isClick || Direction.Equals(0)||Left_||Right_)
        {
            HeroAnimator.SetBool("Walk", false);
        }


    }
}