using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour {

	public void StartOn()
    {
        Debug.Log("Ready to Start");
        SMng.TitleStartOn = true;
    }
}
