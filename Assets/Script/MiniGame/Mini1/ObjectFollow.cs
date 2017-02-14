using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour {


	// Use this for initialization
    void Awake()
    {
        if (SMng.Instance.Hero.GetComponent<Hero>().Right)
        {
            transform.GetComponent<Transform>().position = new Vector3(SMng.Instance.Hero.transform.position.x + 3, SMng.Instance.Hero.transform.position.y, SMng.Instance.Hero.transform.position.z);
        }
        if (SMng.Instance.Hero.GetComponent<Hero>().Left)
        {
            transform.GetComponent<Transform>().position = new Vector3(SMng.Instance.Hero.transform.position.x - 3, SMng.Instance.Hero.transform.position.y, SMng.Instance.Hero.transform.position.z);
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
        
	}
}
