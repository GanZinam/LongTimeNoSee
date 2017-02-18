using UnityEngine;
using System.Collections;

public class SPickMove : MonoBehaviour
{
    public float fSpeed;

    public bool bRightCheck;
    public bool bKeyCheck;      // 입력 체크 (키보드 , 터치)

    public bool bUpCheck;       // pick 가 올라간거 체크

    public float fFirstYPos;

    void Start()
    {
        fFirstYPos = transform.localPosition.y;
        fSpeed = 1f;        // pick 스피드
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            bKeyCheck = true;
        }
        if (!bKeyCheck)
        {
            if (transform.localPosition.x <= -12.92f)        // true = 오른쪽
            {
                bRightCheck = true;
            }
            if (transform.localPosition.x >= -5f)           // false = 오른쪽
            {
                bRightCheck = false;
            }

            if (bRightCheck)
            {
                transform.Translate(Vector2.right * fSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * fSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (transform.localPosition.y < -2.86f && !SMng.bDownCheck)
            {
                bUpCheck = true;
            }
            else
            {
                SMng.bDownCheck = true;
            }

            if (bUpCheck)
            {
                transform.Translate(Vector2.up * fSpeed * Time.deltaTime);
            }

            if(SMng.bDownCheck && transform.localPosition.y > fFirstYPos)
            {
                bUpCheck = false;
                transform.Translate(Vector2.down * fSpeed * Time.deltaTime);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall"))     // 실패했을때 게임오버
        {
            Debug.Log("Game Over");
            Time.timeScale = 0f;
        }
        if(col.CompareTag("Box"))       // 박스에 충돌하면서 다시 이동
        {
            SMng.bDownCheck = false;
            bKeyCheck = false;
        }
    }
}