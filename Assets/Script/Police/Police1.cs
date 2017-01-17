using UnityEngine;
using System.Collections;

public class Police1 : MonoBehaviour
{

    int Paturn;
    public bool Arrow;     // true = 오른쪽 , false = 왼쪽
    public float Speed;    // 경찰 스피드 2
    public float fLerpSpeed;        // 러프 속도 0.7

    public bool police_In;

    SLight LightScrp = null;

    void Start()
    {
        LightScrp = GetComponentInChildren<SLight>();
        Paturn = Random.Range(0, 3);
        Paturn = 0;
        //Speed = 0.05f;
    }

    void Update()
    {
        if (Paturn.Equals(0))        //경찰 패턴 1
        {
            if (Arrow)      //오늘쪽
            {
                gameObject.transform.localScale = new Vector2(0.5f, transform.localScale.y);
                gameObject.transform.Translate(Vector3.right * Speed * Time.deltaTime);
            }
            else           //왼쪽
            {
                transform.localScale = new Vector2(-0.5f, transform.localScale.y);
                gameObject.transform.Translate(Vector3.left * Speed * Time.deltaTime);
            }
            if (gameObject.transform.localPosition.x <= -20f)
            {
                Arrow = true;
            }
            if (gameObject.transform.localPosition.x >= 6f)
            {
                Arrow = false;
            }
        }
        else
        {

        }
        Follow();
    }

    void Follow()
    {
        if (LightScrp.bFollow)
        {
            Paturn = 1;
            transform.localPosition = Vector2.Lerp(new Vector3(transform.localPosition.x, transform.localPosition.y),
                                                   new Vector3(SMng.Instance.Hero.transform.localPosition.x, transform.localPosition.y),
                                                   fLerpSpeed * Time.deltaTime);
        }
        else
        {
            Paturn = 0;
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
