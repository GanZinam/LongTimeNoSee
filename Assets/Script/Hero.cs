using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    public GameObject Move;
    public bool RoomInit;       // 방안에 들어갔나 나왔나

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("RoomRight")||other.gameObject.CompareTag("WallRight"))       // 벽이 왼쪽에있을때
        {
            Move.GetComponent<MoveBt>().Direction = 1;
        }
        else if (other.gameObject.CompareTag("RoomLeft") || other.gameObject.CompareTag("WallLeft"))   // 벽이 오른쪽에있을때
        {
            Debug.Log("LeftIn");
            Move.GetComponent<MoveBt>().Direction = 2;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("RoomRight") || other.gameObject.CompareTag("WallRight"))
        {
            Move.GetComponent<MoveBt>().Direction = 0;
        }
        else if (other.gameObject.CompareTag("RoomLeft") || other.gameObject.CompareTag("WallLeft"))
        {
            Move.GetComponent<MoveBt>().Direction = 0;
        }
    }
}