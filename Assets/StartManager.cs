using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GM
{
    public class StartManager : MonoBehaviour
    {
        [SerializeField]
        GameObject[] gameLevel;

        void Start()
        {
            gameLevel[LevelManager.myLevel].SetActive(true);
            SMng.Instance._inventory.refeshInventory();
        }
    }
}