using UnityEngine;
using System.Collections;

public class DoorBt : MonoBehaviour
{

    public GameObject OutDoor;

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
                    SMng.Instance.Direction = 3;
                    Vector2 Vec = OutDoor.transform.position;
                    SMng.Instance.Hero.transform.position = Vec;
                    SMng.Instance.Direction = 0;
                }
            }
        }
    }
}