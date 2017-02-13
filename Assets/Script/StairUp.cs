using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairUp : MonoBehaviour
{
    public int type;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.transform.CompareTag("StairIcon"))
                {
                    SMng.Direction = 3;

                    if (type.Equals(5))
                    {
                        SMng.Instance.HeroAnimator.SetBool("StairUp", true);
                    }
                    if (type.Equals(6))
                    {
                        SMng.Instance.HeroAnimator.SetBool("StairDown", true);
                    }
                }
            }
        }
    }
}
