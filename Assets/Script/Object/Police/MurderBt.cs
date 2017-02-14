using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurderBt : MonoBehaviour
{
    Vector2 Police_posiiton;
    float Distance_;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.transform.CompareTag("StartKnife"))
                {
                    Debug.Log("Stage1_PoliceKill");
                    transform.parent.GetComponent<Animator>().SetBool("Die", true);
                    SMng.Instance.LevelMng_PoliceDie = true;
                }
                if (hit.collider.transform.CompareTag("knife"))
                {
                    Police_posiiton = transform.parent.parent.parent.transform.position;
                    Distance_ = Vector2.Distance(SMng.Instance.Hero.transform.position, Police_posiiton);
                    if (Distance_ <= 1.5f)
                    {
                        SMng.Instance.hideWeapon.SetActive(true);
                        transform.parent.parent.parent.transform.GetComponent<Police1>().MurderStart = true;
                        SMng.Direction = 3;
                        SMng.interection = true;
                        if (SMng.Instance.Hero.GetComponent<Hero>().Right)
                        {
                            Police_posiiton.x = SMng.Instance.Hero.transform.position.x + 0.7f;
                            transform.parent.parent.parent.transform.position = Police_posiiton;
                        }
                        else if (SMng.Instance.Hero.GetComponent<Hero>().Left)
                        {
                            Police_posiiton.x = SMng.Instance.Hero.transform.position.x - 0.7f;
                            transform.parent.parent.parent.transform.position = Police_posiiton;
                        }
                        MurderStart_(1);
                    }
                }
                if (hit.collider.transform.CompareTag("Gun"))
                {
                    //SMng.Instance.hideWeapon.SetActive(true);
                    //SMng.MurderStart = true;
                    //SMng.Direction = 3;
                    //SMng.interection = true;
                    //MurderStart_(2);
                }
            }
        }
    }

    void MurderStart_(int Direction)            // 1 = 칼 , 2 = 총
    {
        if(Direction.Equals(1))
        {
            if(!SMng.sit)
                SMng.Instance.HeroAnimator.SetBool("Murder",true);
            else if (SMng.sit)
                SMng.Instance.HeroAnimator.SetBool("SitMurder", true);
        }
        if(Direction.Equals(2))
        {

        }
    }
}
