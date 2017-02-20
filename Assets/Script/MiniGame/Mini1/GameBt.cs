using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBt : MonoBehaviour
{
    public Camera Cam;
    public GameObject Bg;
    public GameObject Game;
    public GameObject Window;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.transform.CompareTag("MiniGameStart"))
                {
                    Debug.Log("MiniGameStart");
                    GM.AudioManager.instance.mouse();
                    Bg.SetActive(true);
                    Game.SetActive(true);
                }
            }
        }

        if (SMng.Instance.MGComplite[0])
        {
            Bg.SetActive(false);
            Game.SetActive(false);
            Window.SetActive(false);
            SMng.Instance.hideWeapon.SetActive(false);
            SMng.Direction = 0;
        }
    }
}
