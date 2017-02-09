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
                Police_posiiton = transform.parent.parent.parent.transform.position;
                if (hit.collider.transform.CompareTag("knife"))
                {
                    
                    Distance_ = Vector2.Distance(SMng.Instance.Hero.transform.position, Police_posiiton);
                    if (Distance_ <= 1.5f)
                    {
                        SMng.MurderStart = true;
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
                    SMng.MurderStart = true;
                    SMng.Direction = 3;
                    SMng.interection = true;
                    MurderStart_(2);
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
