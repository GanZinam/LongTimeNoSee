using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerBt : MonoBehaviour {

    public GameObject MinigameCam;
    public GameObject MiniGame1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.CompareTag("GoComputer"))
                {
                    if (SMng.Instance._inventory.ishaveItem(5))
                    {
                        SMng.Instance.hideWeapon.SetActive(true);
                        SMng.Direction = 3;

                        MiniGame1.GetComponent<SComputerMini>().bCheck = true;
                        MinigameCam.SetActive(true);
                    }
                }
            }
        }
	}
}
