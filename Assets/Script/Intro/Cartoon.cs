using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartoon : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Image[] cartoon;         // 카툰 5개 공간
    [SerializeField]
    GameObject cartoonCanvas;


    int cutIdx = 0;     // 카툰 컷 씬 인덱스

    void Start()
    {
        SMng.Direction = 3;
    }

    /**
     * @brief 다음 컷 씬으로 이동
     */
    public void nextCut()
    {
        cutIdx++;
        //cartoon[0].sprite = Resources.Load<Sprite>("Cartoon/" + cutIdx);
        gameStart();
    }

    [SerializeField]
    Transform targetHero;
    [SerializeField]
    CameraFollow cam;

    public void gameStart()
    {
        SMng.Direction = 3;
        cam.target = targetHero;

        if (GM.LevelManager.myLevel.Equals(0))
        {
            GM.AudioManager.instance.rainBG();
            SMng.Instance._level.StartCoroutine("direct_0");
            //StartCoroutine(SMng.Instance._level.direct_0());
        }
        cartoonCanvas.SetActive(false);
    }

    // [0]-> 0, 1, 2
    // [1]-> 3, 4
    // [2]-> 5, 6
    // [3]-> 7, 8
    // [4]-> 9, 10




}
