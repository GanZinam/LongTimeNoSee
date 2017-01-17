using UnityEngine;
using System.Collections;

public class SLight : MonoBehaviour
{
    public GameObject ExclamationGame = null;               // 느낌표의 게임 오브잭트
    public SpriteRenderer ExclamationSprite = null;         // 느낌표의 

    public float ColorSpeed = 1;        // 빨간색으로 되는 속도 (1)
    float DistanceMax;                  // 최대 사이 거리
    float NowDistance;                  // 현제 사이 거리

    //public bool Exclamation;            // 느낌표 있을때 

    public bool bFollow;                // 라이트랑 플래이어가 충돌했을때
    public float fEraseSpeed;           // 느낌표 지워주는 속도 10

    void Start()
    {
        ExclamationSprite = ExclamationGame.GetComponent<SpriteRenderer>();

    }

    //@ 라이트가 줄어드는부분
    void Update()
    {
        //if (Exclamation)
        //{
        //    if (ExclamationSprite.color.Equals(new Color(255f, 255f, 255f)))
        //    {
        //        ExclamationGame.SetActive(false);
        //        Exclamation = false;
        //    }
        //}

        if (!bFollow && ExclamationSprite.color.b <= 1f)
        {
            ExclamationSprite.color += new Color(0f, fEraseSpeed / 255f, fEraseSpeed / 255f, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(SMng.Instance.RoomInit +" "+ SMng.Instance.Hide);
        if (col.CompareTag("Player") && SMng.Instance.RoomInit.Equals(false) && SMng.Instance.Hide.Equals(false))
        {
            ExclamationGame.SetActive(true);

            DistanceMax = Vector3.Distance(transform.parent.parent.position, col.transform.position);

            bFollow = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {

        if (col.CompareTag("Player") && SMng.Instance.RoomInit.Equals(false) && SMng.Instance.Hide.Equals(false))
        {
            NowDistance = Vector3.Distance(transform.parent.parent.position, col.transform.position);
            ColorSpeed = (DistanceMax - NowDistance) / (DistanceMax / 15);
            ExclamationSprite.color -= new Color(0f, ColorSpeed / 255f, ColorSpeed / 255f, 0f);
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
