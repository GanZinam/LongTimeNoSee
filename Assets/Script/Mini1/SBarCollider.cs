using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBarCollider : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("1"))
        {
            Debug.Log("1");
        }
    }
}
