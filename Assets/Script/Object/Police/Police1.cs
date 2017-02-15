using UnityEngine;
using System.Collections;

public class Police1 : MonoBehaviour
{
    public bool Life;             // ture = 삶 fals = 죽음
    public int Paturn;
    public bool Arrow;     // true = 오른쪽 , false = 왼쪽
    float Speed;    // 경찰 스피드 2
    public bool bPaturnChange;     // true = 안움직임 false = 움직임
    public float fLefttMax;
    public float fRightMax;

    SLight LightScrp = null;

    public float fPaturnSpeed;      // 두번째 패턴의 경찰 이동속도
    public float fAddSpeed;         // 라이트 범위안에 들어왔을때 더해주는 속도   0.1
    public float fMaxSpeed;         // 최대 스피드(패턴2) 이건 조절해주면댐

    public bool Cabinet;

    public Animator PoliceWalking;

    GameObject Child;

    public GameObject Light;

    public bool MurderStart;        //암살 시작시

    public int nCount;

    void Start()
    {
        Child = transform.Find("SLight").gameObject;
        LightScrp = GetComponentInChildren<SLight>();
        Paturn = Random.Range(0, 3);
        Paturn = 0;
        fPaturnSpeed = Speed;
        fAddSpeed = 0.01f;
        fMaxSpeed = 2.5f;
        Speed = 0.5f;
        Life = true;
        //Speed = 0.05f;
    }

    void Update()
    {
        if (Life)
        {
            if (!LightScrp.bSendCheck)
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
                    if (gameObject.transform.localPosition.x <= fLefttMax) //-20f
                    {
                        Arrow = true;
                    }
                    if (gameObject.transform.localPosition.x >= fRightMax) //6f
                    {
                        Arrow = false;
                    }
                    if (bPaturnChange)
                    {
                        Speed = 0f;
                        PoliceWalking.speed = 0f;
                    }
                    else
                    {
                        Speed = 0.5f;
                        PoliceWalking.speed = 1f;
                    }
                }
                else
                {

                }
                Paturn2();
            }
            else
                Paturn3();
            PoliceAlphaCahnge();    // 방이 켜져있으면 경찰 Alpha
        }
        else
        {
            Light.SetActive(false);
        }
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
            else
            {
                PoliceWalking.SetBool("PoliceStop", false);
                fPaturnSpeed = Speed;
                fAddSpeed = 0.01f;
                fMaxSpeed = 2.5f;
                Paturn = 0;
            }

            if (LightScrp.ExclamationSprite.color.b <= 0f || MurderStart)      // 경찰 멈추는곳 (빨간색 됬을때) , 암살 눌렸을때
            {
                PoliceWalking.SetBool("PoliceStop", true);
                fPaturnSpeed = 0f;
                fAddSpeed = 0f;
                Paturn = 1;
            }
        }
    }

    void Paturn3()
    {

        if (LightScrp.bSendCheck && SMng.Instance.TimeCtrl((int)E_TIME.E_TIME1, 1f))        // 1초마다 한번씩 둘러봄
        {
            Speed = 0f;
            gameObject.transform.localScale = new Vector2(-(transform.localScale.x), transform.localScale.y);
            nCount++;
        }

        if (nCount > 4)
        {
            gameObject.transform.localScale = new Vector2(-(transform.localScale.x), transform.localScale.y);
            LightScrp.bSendCheck = false;
            Paturn = 0;
            Speed = 0.5f;
            nCount = 0;
        }
    }

    public void PoliceAlphaCahnge()
    {
        if (SMng.RoomInit)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
        }
    }

    public void BeCaught()
    {
        PoliceWalking.SetTrigger("Cabinet");
    }
    public void KillPolice()
    {
        gameObject.SetActive(false);
    }
}