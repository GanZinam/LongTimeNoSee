using UnityEngine;
using System.Collections;

public class Police1 : MonoBehaviour {

    int Paturn;
    bool Arrow;     // true = 오른쪽 , false = 왼쪽
    float Speed;    // 경찰 스피드

    public bool police_In;


	void Start () {
        Paturn = Random.Range(0, 3);
        Paturn = 0;
        Speed = 0.05f;
	}
	
	void Update () {
        if(Paturn.Equals(0))        //경찰 패턴 1
        {
            if(Arrow)
            {
                gameObject.transform.Translate(Speed, 0, 0);
            }
            else
            {
                gameObject.transform.Translate(-Speed, 0, 0);
            }
            if(gameObject.transform.localPosition.x <= -20f)
            {
                Arrow = true;
            }
            if (gameObject.transform.localPosition.x >= 20f)
            {
                Arrow = false;
            }
        }
        else
        {

        }
        
	}

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Room"))// 방들어가면 Alpha값 변경 
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            police_In = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Room"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1.0f);
            police_In = true;
        }
    }
}
