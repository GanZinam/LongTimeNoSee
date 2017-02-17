using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SComputerMini : MonoBehaviour
{
    public SScroll[] SScrollScrp = new SScroll[6];
    public GameObject[] WallGame = new GameObject[6];

    public GameObject EndDoor;
    public Sprite EndDoorSpr;

    public int nCount;          // 알파벳 카운트?
    public bool bCheck;

    // timer
    public float fTimer;        // 타이머 시간
    int nTime;
    int nMinutes;
    int nSeconds;
    float fMillisecond;
    // public Text TimerText = null;        // 텍스트 적용 부탁

    bool GameClear;

    void Start()
    {
        nCount = 0;
        fTimer = 180f;
    }

    void Update()
    {
        // Timer();

        for (int i = 0; i < SScrollScrp.Length; i++)
        {
            if (i != nCount)
            {
                SScrollScrp[i].boxcollider[0].enabled = false;
                SScrollScrp[i].boxcollider[1].enabled = false;
            }
            else
            {
                SScrollScrp[i].boxcollider[0].enabled = true;
                SScrollScrp[i].boxcollider[1].enabled = true;
                //Debug.Log(i);
            }
        }
        if (GameClear)        // 게임 클리어 조건
        {
            GameClear = false;
            Debug.Log("Clear");
            EndDoor.GetComponent<SpriteRenderer>().sprite = EndDoorSpr;
            SMng.Instance.MGComplite[0] = true;
        }

        Reset();     // 게임이끝났을때 호출되는 함수(현재는 R)
    }

    //void Timer()
    //{
    //    if (fTimer > 0)
    //    {
    //        fTimer -= Time.deltaTime;
    //        nTime = (int)fTimer;
    //        nMinutes = nTime / 60;
    //        nSeconds = nTime % 60;
    //        fMillisecond = fTimer * 1000;
    //        fMillisecond = (fMillisecond % 1000);
    //        TimerText.text = string.Format("{0:00}:{1:00}:{2:000}", nMinutes, nSeconds, fMillisecond);
    //    }
    //    if (fTimer <= 0)
    //    {
    //        TimerText.text = string.Format("{0:00}:{1:00}:{2:000}", 0, 0, 0);
    //        Time.timeScale = 0;
    //    }
    //}

    void Reset()
    {
        if (Input.GetKeyDown(KeyCode.R))        // 게임 재시작
        {
            nCount = 0;
            for (int i = 0; i < WallGame.Length; i++)
            {
                SScrollScrp[i].StopSpeed = 1;
                SScrollScrp[i].boxcollider[0].enabled = true;
            }
        }
    }



    void OnTriggerStay2D(Collider2D col)        // Bar 에서 클릭하면 속도 0으로
    {
        if (Input.GetMouseButtonDown(0) && bCheck)
        {
            switch (nCount)
            {
                case 0:
                    SScrollScrp[nCount].StopSpeed = 0;
                    bCheck = false;
                    nCount++;
                    break;
                case 1:
                    SScrollScrp[nCount].StopSpeed = 0;
                    bCheck = false;
                    nCount++;
                    break;
                case 2:
                    SScrollScrp[nCount].StopSpeed = 0;
                    bCheck = false;
                    nCount++;
                    break;
                case 3:
                    SScrollScrp[nCount].StopSpeed = 0;
                    bCheck = false;
                    nCount++;
                    break;
                case 4:
                    SScrollScrp[nCount].StopSpeed = 0;
                    bCheck = false;
                    nCount++;
                    GameClear = true;
                    break;
            }
        }
        else if (Input.GetMouseButtonDown(0) && !bCheck)
        {
            // 잘못눌렀을때 시간 줄어들게
        }
    }


}
