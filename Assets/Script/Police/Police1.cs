using UnityEngine;
using System.Collections;

public class Police1 : MonoBehaviour
{

    int Paturn;
    bool Arrow;     // true = 오른쪽 , false = 왼쪽
    float Speed;    // 경찰 스피드

    public bool police_In;


    void Start()
    {
        Paturn = Random.Range(0, 3);
        Paturn = 0;
        Speed = 0.05f;
    }

    void Update()
    {
        if (Paturn.Equals(0))        //경찰 패턴 1
        {
            if (Arrow)      //오늘쪽
            {
                gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
                gameObject.transform.Translate(Speed, 0, 0);
            }
            else            //왼쪽
            {
                gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y-180, gameObject.transform.rotation.z);
                gameObject.transform.Translate(Speed, 0, 0);
            }
            if (gameObject.transform.localPosition.x <= -20f)
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

    //@ 방들어가면 Alpha값 변경 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Room"))
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("RoomRight"))       // 벽이 왼쪽에있을때
        {

        }
        else if (other.gameObject.CompareTag("RoomLeft"))   // 벽이 오른쪽에있을때
        {

        }
    }
     void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("RoomRight"))
        {

        }
        else if (other.gameObject.CompareTag("RoomLeft"))
        {

        }
    }
}
