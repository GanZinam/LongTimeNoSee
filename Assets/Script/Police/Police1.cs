using UnityEngine;
using System.Collections;

public class Police1 : MonoBehaviour
{
    int Paturn;
    public bool Arrow;     // true = 오른쪽 , false = 왼쪽
    float Speed;    // 경찰 스피드 2


    SLight LightScrp = null;

    public float fPaturnSpeed;      // 두번째 패턴의 경찰 이동속도
    public float fAddSpeed;         // 라이트 범위안에 들어왔을때 더해주는 속도   0.1
    public float fMaxSpeed;         // 최대 스피드(패턴2) 이건 조절해주면댐


    public Animator PoliceWalking;

    GameObject Child;


    void Start()
    {
        Child = transform.Find("LookPoint/SLight").gameObject;
        LightScrp = GetComponentInChildren<SLight>();
        Paturn = Random.Range(0, 3);
        Paturn = 0;
        fPaturnSpeed = Speed;
        fAddSpeed = 0.01f;
        fMaxSpeed = 2.5f;
        Speed = 0.5f;
        //Speed = 0.05f;
    }

    void Update()
    {
        if (!Child.GetComponent<SLight>().bFollow)
        {
            PoliceWalking.speed = 1f;
        }
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
        Paturn2();
        PoliceAlphaCahnge();    // 방이 켜져있으면 경찰 Alpha
    }

    void Paturn2()          //@ 따라가는거
    {
        if (true)
        {
            if (LightScrp.bFollow)  //충돌했는지 체크
            {
                fPaturnSpeed += fAddSpeed;      // 경찰 속도 빨라지는 부분
                PoliceWalking.speed += 0.01f;   // 걷는 애니메이션 빨라지는 부분

                if (PoliceWalking.speed >= 3)   //애니메이션
                {
                    PoliceWalking.speed = 3f;
                }

                Paturn = 1;


                if (fPaturnSpeed > fMaxSpeed)   //경찰 속도한계치
                {
                    fPaturnSpeed = fMaxSpeed;
                }
                if (Arrow)      //오늘쪽
                {
                    gameObject.transform.localScale = new Vector2(0.5f, transform.localScale.y);
                    gameObject.transform.Translate(Vector3.right * fPaturnSpeed * Time.deltaTime);
                }
                else           //왼쪽
                {
                    transform.localScale = new Vector2(-0.5f, transform.localScale.y);
                    gameObject.transform.Translate(Vector3.left * fPaturnSpeed * Time.deltaTime);
                }
            }
            else        // 여기 고침 헿
            {
                PoliceWalking.SetBool("PoliceStop", false);
                fPaturnSpeed = Speed;
                fAddSpeed = 0.01f;
                fMaxSpeed = 2.5f;
                Paturn = 0;
            }

            if (LightScrp.ExclamationSprite.color.b <= 0f)      // 경찰 멈추는곳 (빨간색 됬을때)
            {
                PoliceWalking.SetBool("PoliceStop", true);
                fPaturnSpeed = 0f;
                fAddSpeed = 0f;
            }
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
    public void PoliceAlphaCahnge()
    {
        if (SMng.Instance.RoomInit)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
        }
    }
}