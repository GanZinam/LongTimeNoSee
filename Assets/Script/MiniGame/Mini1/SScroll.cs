using UnityEngine;
using System.Collections;

public class SScroll : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeY;

    public BoxCollider2D[] boxcollider = new BoxCollider2D[2];

    private Vector3 startPosition;

    void Start()
    {
        tileSizeY = 8f;
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector3.down * newPosition;
    }
}