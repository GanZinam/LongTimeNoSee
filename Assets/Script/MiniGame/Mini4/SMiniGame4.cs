using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SMiniGame4 : MonoBehaviour
{
    public SpriteRenderer[] ImgSpriteRenderer = new SpriteRenderer[3];
    public SpriteRenderer[] LifeSprite;
    public SImgChange[] ImgChangeScrp = new SImgChange[3];
    public Sprite[] sprite = null;
    public Camera UICam = null;
    bool bfuck = true;

    int nCount;

    RaycastHit2D Ray;

    Sprite[] imgSprite;

    public int nFirstCount;
    public int nSecondCount;
    public int nThirdCount;

    [SerializeField]
    GameObject finale;


    void Start()
    {
        Init();
    }

    void Update()
    {
        ImgSpriteRenderer[0].sprite = ImgChangeScrp[0].ImgSprite[nFirstCount];
        ImgSpriteRenderer[1].sprite = ImgChangeScrp[1].ImgSprite[nSecondCount];
        ImgSpriteRenderer[2].sprite = ImgChangeScrp[2].ImgSprite[nThirdCount];

        Click();
        if (Ray.collider != null)
        {
            if (Input.GetMouseButtonDown(0) && Ray.collider.tag.Equals("StartBtn"))
            {
                if (nFirstCount.Equals(0) && nSecondCount.Equals(0) && nThirdCount.Equals(0) && bfuck)
                {
                    Debug.Log("Clear");
                    bfuck = false;
                    StartCoroutine("fade");
                }
                else // 끝나는곳
                {
                    Debug.Log("fuck");
                    LifeSprite[nCount].sprite = sprite[0];
                    nCount++;
                    if (nCount.Equals(3))
                    {
                        Init();
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    IEnumerator fade()
    {
        finale.SetActive(true);
        yield return new WaitForSeconds(1.1f);

        SceneManager.LoadScene("End");
    }

    void Init()
    {
        nCount = 0;
        for (int i = 0; i < 3; i++)
        {
            LifeSprite[i].sprite = sprite[1];
        }
        nFirstCount = Random.Range(0, 3);
        nSecondCount = Random.Range(0, 3);
        nThirdCount = Random.Range(0, 3);
        ImgSpriteRenderer[0].sprite = ImgChangeScrp[0].ImgSprite[nFirstCount];
        ImgSpriteRenderer[1].sprite = ImgChangeScrp[1].ImgSprite[nSecondCount];
        ImgSpriteRenderer[2].sprite = ImgChangeScrp[2].ImgSprite[nThirdCount];

    }

    void Click()
    {
        Ray = GetHitInfo();

        if (Ray.collider != null)
        {
            if (Input.GetMouseButtonDown(0) && Ray.collider.tag.Equals("Answer1"))
            {
                nFirstCount++;
            }
            if (Input.GetMouseButtonDown(0) && Ray.collider.tag.Equals("Answer2"))
            {
                nSecondCount++;
            }
            if (Input.GetMouseButtonDown(0) && Ray.collider.tag.Equals("Answer3"))
            {
                nThirdCount++;
            }
            if (nFirstCount.Equals(3))
            {
                nFirstCount = 0;
            }
            if (nSecondCount.Equals(3))
            {
                nSecondCount = 0;
            }
            if (nThirdCount.Equals(3))
            {
                nThirdCount = 0;
            }
        }
    }

    RaycastHit2D GetHitInfo()
    {
        Vector2 ClickPosVec2 = UICam.ScreenToWorldPoint(Input.mousePosition);

        Ray2D ClickRay = new Ray2D(ClickPosVec2, Vector2.zero);
        RaycastHit2D Hit2D = Physics2D.Raycast(ClickRay.origin, ClickRay.direction);

        if (Hit2D.collider != null)
        {
            return Hit2D;
        }
        return Hit2D;
    }

}
