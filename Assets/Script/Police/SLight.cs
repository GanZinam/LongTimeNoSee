using UnityEngine;
using System.Collections;

public class SLight : MonoBehaviour
{
    public GameObject ExclamationGame = null;               // 느낌표의 게임 오브잭트
    public SpriteRenderer ExclamationSprite = null;         // 느낌표의 
    public bool Light_full;             // 라이트 다찻는지 아닌지

    public float ColorSpeed;            // 빨간색으로 되는 속도 (1)
    float DistanceMax;                  // 최대 사이 거리
    float NowDistance;                  // 현제 사이 거리

    public bool bFollow;                // 라이트랑 플래이어가 충돌했을때
    float fEraseSpeed;                  // 느낌표 지워주는 속도 3


    void Start()
    {
        ExclamationSprite = ExclamationGame.GetComponent<SpriteRenderer>();
        fEraseSpeed = 3f;
    }

    //@ 라이트가 줄어드는부분
    void Update()
    {

        if (!bFollow && ExclamationSprite.color.b <= 1f)
        {
            ExclamationSprite.color += new Color(0f, fEraseSpeed / 255f, fEraseSpeed / 255f, 0f);
        }
        else if (!bFollow && ExclamationSprite.color.b > 1f)
        {
            ExclamationGame.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && SMng.Instance.RoomInit.Equals(false) && SMng.Instance.Hide.Equals(false))
        {
            ExclamationGame.SetActive(true);

            DistanceMax = 7.8f;

            bFollow = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && SMng.Instance.RoomInit.Equals(false) && SMng.Instance.Hide.Equals(false))
        {
            if (SMng.Instance.Hide_left.Equals(transform.parent.parent.GetComponent<Police1>().Arrow.Equals(true)) ||
                SMng.Instance.Hide_right.Equals(transform.parent.parent.GetComponent<Police1>().Arrow.Equals(false)))
            {
                if (!bFollow)
                {
                    ExclamationGame.SetActive(true);

                    DistanceMax = 7.8f;

                    bFollow = true;
                }
                NowDistance = Vector3.Distance(transform.parent.parent.position, col.transform.position);
                ColorSpeed = (DistanceMax - NowDistance) / (DistanceMax / 4);      //

                if (ExclamationSprite.color.r > 0 && ExclamationSprite.color.b > 0 && ExclamationSprite.color.g > 0)
                {
                    ExclamationSprite.color -= new Color(0f, ColorSpeed / 255f, ColorSpeed / 255f, 0f);
                }
                else
                {
                    ExclamationSprite.color = new Color(255f, 0f, 0f);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ExclamationSprite.color += new Color(0f, ColorSpeed / 255f, ColorSpeed / 255f);
            bFollow = false;
        }
    }
}
