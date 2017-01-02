using UnityEngine;
using System.Collections;

public class DoorBt : MonoBehaviour {

    public GameObject OutDoor;
    public GameObject Hero;

    void Update()
    {
        // 문들어가는거 클릭
        if (Input.GetMouseButtonDown(0))
		{
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

			if ( hit.collider != null )
			{
                Debug.Log("Click");
                if (hit.transform.CompareTag("GoDoor"))
                {
                    Debug.Log("DoorIntoClick");
                    Vector2 Vec = OutDoor.transform.position;
                    Hero.transform.position = Vec;
                }
            }
        }


    }
}
