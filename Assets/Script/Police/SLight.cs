using UnityEngine;
using System.Collections;

public class SLight : MonoBehaviour
{
    // 미안해 ㅜㅜ 변수 이름이 길어서
    public GameObject ExclamationGame = null;               // 느낌표의 게임 오브잭트
    public SpriteRenderer ExclamationSprite = null;         // 느낌표의 스프라이트렌더러
    public GameObject Hero;


    public float ColorSpeed = 1;        // 빨간색으로 되는 속도 (1)
    float DistanceMax;                  // 최대 사이 거리
    float NowDistance;                  // 현제 사이 거리

    void Start()
    {
        ExclamationSprite = ExclamationGame.GetComponent<SpriteRenderer>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Hero.GetComponent<Hero>().RoomInit.Equals(false))
        {
            ExclamationGame.SetActive(true);

            DistanceMax = Vector3.Distance(transform.parent.parent.position, col.transform.position);
            Debug.Log(DistanceMax);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Hero.GetComponent<Hero>().RoomInit.Equals(false))
        {
            Debug.Log("Up");
            NowDistance = Vector3.Distance(transform.parent.parent.position, col.transform.position);
            ColorSpeed = (DistanceMax-NowDistance)/(DistanceMax/15) ;
            Debug.Log(ColorSpeed);
            ExclamationSprite.color -= new Color(0f, ColorSpeed / 255f, ColorSpeed / 255f, 0f);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Hero.GetComponent<Hero>().RoomInit.Equals(false))
        {
            ExclamationGame.SetActive(false);
            ExclamationSprite.color = new Color(1f, 1f, 1f);
        }
    }
}
