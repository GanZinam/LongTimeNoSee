using UnityEngine;
using System.Collections;

public class SLight : MonoBehaviour
{
    // 미안해 ㅜㅜ 변수 이름이 길어서
    public GameObject ExclamationGame = null;               // 느낌표의 게임 오브잭트
    public SpriteRenderer ExclamationSprite = null;         // 느낌표의 스프라이트렌더러

    public float ColorSpeed;        // 빨간색으로 되는 속도 (1)

    void Start()
    {
        ExclamationSprite = ExclamationGame.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ExclamationGame.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ExclamationSprite.color -= new Color(0f, ColorSpeed / 255f, ColorSpeed / 255f, 0f);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ExclamationGame.SetActive(false);
            ExclamationSprite.color = new Color(1f, 1f, 1f);
        }
    }
}
