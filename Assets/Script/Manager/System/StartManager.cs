﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GM
{
    public class StartManager : MonoBehaviour
    {
        [SerializeField]
        GameObject[] gameLevel;
        [SerializeField]
        GameObject[] policeLevel;

        [SerializeField]
        Transform targetHero;
        [SerializeField]
        CameraFollow cam;

        [SerializeField]
        Transform[] spawnPos;

        void Start()
        {
            gameLevel[LevelManager.myLevel].SetActive(true);
            policeLevel[LevelManager.myLevel].SetActive(true);
            SMng.Instance.Hero.transform.position = spawnPos[LevelManager.myLevel].position;

            SMng.Instance._inventory.refeshInventory();

            if (LevelManager.myLevel != 0)
            {
                cam.target = targetHero;
                SMng.Instance.Hero.SetActive(true);
            }
        }
    }
}