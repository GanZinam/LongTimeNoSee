using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetMurder : MonoBehaviour
{
    public GameObject tempTargetPolice;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.transform.CompareTag("knife"))
                {
                    tempTargetPolice.transform.position = SMng.Instance.Hero.transform.position;
                    tempTargetPolice.transform.GetComponent<Police1>().Life = false;
                    transform.parent.GetComponent<Animator>().SetBool("CabinetOpen",true);
                    //gameObject.SetActive(false);
                    //tempTargetPolice.SendMessage("BeCaught");       // 경찰에게 붙잡혔다는 메세지를 보내줌
                }
            }
        }
    }

    public void BeCaught()
    {
        tempTargetPolice.SendMessage("BeCaught");
    }
}