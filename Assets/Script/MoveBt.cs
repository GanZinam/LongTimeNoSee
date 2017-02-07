using UnityEngine;
using System.Collections;

public class MoveBt : MonoBehaviour
{

    //@ Collision으로 들어올때
    public bool C_Right_ = false;
    public bool C_Left_ = false;



    Vector3 RotateHero;


    public void RightBt_in()
    {
        if (!C_Right_)
            SMng.Instance.Direction = 1;
    }

    public void RightBt_out()
    {
        SMng.Instance.Direction = 0;
    }

    public void LeftBt_in()
    {
        if (!C_Left_)
            SMng.Instance.Direction = 2;
    }

    public void LeftBt_out()
    {
        SMng.Instance.Direction = 0;
    }
    void Update()
    {
        if (!Input.touchCount.Equals(2) && !SMng.Instance.Direction.Equals(3))
        {
            Move();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!SMng.Instance.sit)
                SMng.Instance.HeroAnimator.SetBool("Walk", false);
            else
                SMng.Instance.HeroAnimator.SetBool("CrouchWalk", false);
        }

    }
    void Move()
    {
        Vector3 touchPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) && touchPos.x > 0.75f && touchPos.y < 0.75f && !SMng.Instance.Middle_touch)
        {
            if (SMng.Instance.Direction.Equals(0) || SMng.Instance.Direction.Equals(1))
            {

                SMng.Instance.Hero.GetComponent<Hero>().Right = true;
                SMng.Instance.Hero.GetComponent<Hero>().Left = false;

                SMng.Instance.Hero.transform.localScale = new Vector2(0.5f, 0.5f);
                SMng.Instance.Hero.transform.Translate(Vector3.right * 2f * Time.deltaTime);
                if (!SMng.Instance.sit)
                {
                    if (!SMng.Instance.HeroAnimator.GetBool("Walk"))
                    {
                        SMng.Instance.HeroAnimator.SetBool("Walk", true);
                    }
                }
                else
                {
                    if (!SMng.Instance.HeroAnimator.GetBool("CrouchWalk"))
                    {
                        SMng.Instance.HeroAnimator.SetBool("CrouchWalk", true);
                    }
                }
            }
        }
        if (Input.GetMouseButton(0) && touchPos.x < 0.25f && touchPos.y < 0.75f && !SMng.Instance.Middle_touch)
        {
            if (SMng.Instance.Direction.Equals(0) || SMng.Instance.Direction.Equals(2))
            {
                SMng.Instance.Hero.GetComponent<Hero>().Right = false;
                SMng.Instance.Hero.GetComponent<Hero>().Left = true;

                SMng.Instance.Hero.transform.localScale = new Vector2(-0.5f, 0.5f);
                SMng.Instance.Hero.transform.Translate(Vector3.left * 2f * Time.deltaTime);

                if (!SMng.Instance.sit)
                {
                    if (!SMng.Instance.HeroAnimator.GetBool("Walk"))
                    {
                        SMng.Instance.HeroAnimator.SetBool("Walk", true);
                    }
                }
                else
                {
                    if (!SMng.Instance.HeroAnimator.GetBool("CrouchWalk"))
                    {
                        //SMng.Instance.HeroAnimator.SetBool("CrouchBreath", true);
                        SMng.Instance.HeroAnimator.SetBool("CrouchWalk", true);
                    }
                }
            }
        }
    }
}