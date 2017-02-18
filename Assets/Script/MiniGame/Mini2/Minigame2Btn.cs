using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame2Btn : MonoBehaviour {

    public GameObject Mini2Game = null;

    public void Click()
    {
        SMng.Direction = 3;
        Mini2Game.SetActive(true);
    }
}
