using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePopup : MonoBehaviour
{
    public int idx = 0;
    public UnityEngine.UI.Text text;

    void Start()
    {
        StartCoroutine("counting");
    }

    IEnumerator counting()
    {
        yield return new WaitForSeconds(1);
        SMng.Instance.isStating[idx] = false;
        Destroy(gameObject);
    }
}
