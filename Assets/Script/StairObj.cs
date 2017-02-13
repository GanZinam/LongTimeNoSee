using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairObj : MonoBehaviour {

    public GameObject StairIcon;

	// Update is called once per frame
    void Update()
    {
    }
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StairIcon.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StairIcon.SetActive(false);
        }
    }
}
