using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDINGCUTSCENE : MonoBehaviour
{
    int cutIdx = -1;     // 카툰 컷 씬 인덱스

    [SerializeField]
    GameObject[] cartoonBAD;        // 카툰 12개 공간
    [SerializeField]
    GameObject[] cartoonHAPY;       // 카툰 8개 공간


    public void nex()
    {
        cutIdx++;

        if (GM.AudioManager.endResult)
        {
            if (cutIdx < 12)
                cartoonBAD[cutIdx].SetActive(true);
        }
        else
        {
            if (cutIdx < 8)
                cartoonHAPY[cutIdx].SetActive(true);
        }

        //if (cutIdx.Equals(9))
        //    titleObj.SetActive(true);
        //else if (cutIdx.Equals(10))
        //{
        //    cutIdx = 9;
        //    gameStart();
        //}
        //else
        //    cartoon[cutIdx].SetActive(true);
    }
}
