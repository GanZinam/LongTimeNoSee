using UnityEngine;
using System.Collections;

public class SScroll : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeY;

    private Vector3 startPosition;

    void Start()
    {
        scrollSpeed = 5f;
        tileSizeY = 10f;
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector3.down * newPosition;
    }
}