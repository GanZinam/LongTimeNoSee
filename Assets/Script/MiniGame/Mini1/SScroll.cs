using UnityEngine;
using System.Collections;

public class SScroll : MonoBehaviour
{
    GameObject Parents;
    
    public float scrollSpeed;
    public float tileSizeY;

    public float StopSpeed;

    public BoxCollider2D[] boxcollider = new BoxCollider2D[2];

    private Vector3 startPosition;

    void Start()
    {
        StopSpeed = 1;
        Parents = transform.parent.gameObject;
        tileSizeY = 8f;
        startPosition = transform.position;
    }

    void Update()
    {
        if (StopSpeed.Equals(0))
        {
            transform.position = new Vector2(transform.position.x,-3.4f+11.8f);
        }
        else
        {
            float newPosition = Mathf.Repeat(Time.time * scrollSpeed* StopSpeed, tileSizeY);
            transform.position = startPosition + Vector3.down * newPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (transform.CompareTag("wall" + Parents.GetComponent<SComputerMini>().nCount) && col.CompareTag("Bar"))
        {
            Debug.Log("bCheckIn");
            Parents.GetComponent<SComputerMini>().bCheck = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (transform.CompareTag("wall" + Parents.GetComponent<SComputerMini>().nCount) && col.CompareTag("Bar"))
        {
            Debug.Log("bCheckOut");
            Parents.GetComponent<SComputerMini>().bCheck = false;
        }
    }
}