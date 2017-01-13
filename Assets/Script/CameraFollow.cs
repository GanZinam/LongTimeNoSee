using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Camera mycam;

    //@ 카매라 기본위치
    float f_X = 0;
    float f_Y = 0.2f;

    public float moveSpeed;         // 줌할때 스피드
    public float fMaxZoomIn;          // 줌 인 최대치(줌 할때 제한)
    public float fMaxZoomout;         // 줌 아웃 최대치 원래 카메라 사이즈 5 (줌 아웃 제안)

    bool bZoomIn;
    bool bZoomOut;

    bool bFuck;     // 터치체크

    //@ 앉는 모션
    Vector3 StartPos;
    Vector3 NowPos;
    Vector3 EndPos;

    bool _action;

    // Use this for initialization
    void Start()
    {
        mycam = GetComponent<Camera>();
        _action = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target)
        {
            if (target.GetComponent<Hero>().Right)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(f_X + 0.3f, f_Y, -1);
            }
            else if (target.GetComponent<Hero>().Left)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(f_X - 0.3F, f_Y, -1);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(f_X + 0.3f, f_Y, -1);
            }
        }
    }

    void Update()
    {
        MultiTouch();
        KeyCheck();
        Zoom();
        sit();
    }

    void KeyCheck()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            bZoomIn = false;
            bZoomOut = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            bZoomIn = true;
            bZoomOut = false;
        }
    }

    void Zoom()
    {
        if (Camera.main.orthographicSize < fMaxZoomout && !bZoomOut)
        {
            Camera.main.orthographicSize += moveSpeed * Time.deltaTime;
        }
        if (Camera.main.orthographicSize >= fMaxZoomIn && !bZoomIn)
        {
            Camera.main.orthographicSize -= moveSpeed * Time.deltaTime;
        }
    }

    void MultiTouch()
    {
        if (Input.touchCount.Equals(2))
        {
            Touch touch = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            Vector2 curDist = touch.position - touch2.position;
            Vector2 prevDist = (touch.position - touch.deltaPosition) - (touch2.position - touch2.deltaPosition);
            float delta = curDist.magnitude - prevDist.magnitude;

            if (delta > 0 && !bFuck) // 3
            {
                bZoomIn = false;
                bZoomOut = true;
                bFuck = true;
            }
            else if (delta < 0 && bFuck) // 5
            {
                bZoomIn = true;
                bZoomOut = false;
                bFuck = false;
            }
        }
    }
    void sit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            StartPos = Input.mousePosition;
            if (touchPos.x < 0.75f && touchPos.x > 0.25f)
            {
                _action = true;
            }
            else
            {
                _action = false;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (_action)
            {
                NowPos = Input.mousePosition;

                if (SMng.Instance.sit)
                {
                    if (StartPos.x + 50 >= NowPos.x && StartPos.x - 50 <= NowPos.x)
                    {
                        _action = true;
                    }
                    else
                    {
                        Debug.Log(StartPos.x +" "+ NowPos.x);
                        _action = false;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            EndPos = Input.mousePosition;

            if (_action)
            {
                if ((!SMng.Instance.sit) && StartPos.y > EndPos.y + 200)
                {
                    Debug.Log("Sit Down");
                    SMng.Instance.sit = true;
                    SMng.Instance.HeroAnimator.SetBool("Crouch", true);
                }
                else if ((SMng.Instance.sit) && StartPos.y < EndPos.y - 200)
                {
                    Debug.Log("Stand Up");
                    SMng.Instance.sit = false;
                    SMng.Instance.HeroAnimator.SetBool("StandUp", true);
                }
            }
            _action = true;
        }
    }
}