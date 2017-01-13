using UnityEngine;
using System.Collections;

public class SMng : MonoBehaviour
{
    private static SMng _Instance = null;

    public static SMng Instance
    {
        get
        {
            if (_Instance == null)
            {
                Debug.Log("instance is null");
            }
            return _Instance;
        }
    }

    void Awake()
    {
        _Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    public GameObject Hero = null;      //Hero GameObject
    
    // 0 = 아무대도아닌상태 1= 오른쪽 2 = 왼쪽 3 = 상호작용했을때
    public int Direction = 0;

    public bool sit = false;

    // 주인공 애니메이션
    public Animator HeroAnimator;

}