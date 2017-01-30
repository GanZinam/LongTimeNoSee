using UnityEngine;
using System.Collections;

public class SLock : MonoBehaviour
{
    public Sprite[] PickSprite = null;
    public SpriteRenderer PickSpriteRender = null;
    public bool bLockCheck;     // 
    public int nRand;

    public bool bColliderCheck;
    public float fSpeed;

    // Use this for initialization
    void Start()
    {
        PickSpriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Init();
        if(bLockCheck && nRand.Equals(0) &&!bColliderCheck)     // on(자물쇠에 붙어있는거) 일때 
        {
            transform.localPosition = new Vector2(transform.localPosition.x, 1f);
        }
        else                                                    // off 일때 금색
        {
            PickSpriteRender.sprite = PickSprite[1];
        }
        if (bColliderCheck && transform.localPosition.y < 1.36f)        // 충돌되면 올려주는 곳
        {
            transform.Translate(Vector2.up * fSpeed * Time.deltaTime);
        }
    }

    void Init()             // 랜덤으로 on off 초기화
    {
        switch (nRand)
        {
            case 0:
                PickSpriteRender.sprite = PickSprite[nRand];
                break;
            case 1:
                PickSpriteRender.sprite = PickSprite[nRand];
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Pick"))
        {
            bColliderCheck = true;
            SMng.Instance.bDownCheck = true;
        }
    }
}
