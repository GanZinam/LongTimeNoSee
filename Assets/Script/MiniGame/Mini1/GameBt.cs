using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBt : MonoBehaviour {

    public Camera Cam;
    public GameObject Bg;
    public GameObject Game;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if(hit.collider.transform.CompareTag("MiniGameStart"))
                {
                    Debug.Log("MiniGameStart");
                    Bg.SetActive(true);
                    Game.SetActive(true);
                }
            }

        }
	}
}
