using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    Camera mycam;

    float f_X = 0;           //카메라 위치 X
    float f_Y = 0.2f;             //카메라 위치 Y

    public float moveSpeed;         // 줌할때 스피드
    public float fMaxZoomIn;          // 줌 인 최대치(줌 할때 제한)
    public float fMaxZoomout;         // 줌 아웃 최대치 원래 카메라 사이즈 5 (줌 아웃 제안)

	// Use this for initialization
	void Start () {
        mycam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
    void LateUpdate()
    {

        if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(f_X, f_Y, -1) ;
        }
        
        MultiTouch();
	}

    void MultiTouch()
    {
        if (Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            Vector2 curDist = touch.position - touch2.position;
            Vector2 prevDist = (touch.position - touch.deltaPosition) - (touch2.position - touch2.deltaPosition);
            float delta = curDist.magnitude - prevDist.magnitude;

            if (delta > 0 && Camera.main.orthographicSize >= fMaxZoomIn)
            {
                ZoomIn();
            }
            else
            {
                if (Camera.main.orthographicSize < fMaxZoomout)
                    ZoomOut();
            }
        }
    }

    void ZoomOut()
    {
        Camera.main.orthographicSize += moveSpeed * Time.deltaTime;
    }

    void ZoomIn()
    {
        Camera.main.orthographicSize -= moveSpeed * Time.deltaTime;
    }
}