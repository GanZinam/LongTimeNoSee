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
    public GameObject DoorBt = null;    //DoorBt GameObject

    public int Hero_weapon;     //0.상호작용 1. 전투

    public bool Middle_touch;           //중앙 터치 유무
    
    // 0 = 아무대도아닌상태 1= 오른쪽 2 = 왼쪽 3 = 상호작용했을때
    public int Direction = 0;

    // 주인공이 앉아있는지 아닌지 true = 앉아있는것 false = 서있는것
    public bool sit = false;
    public bool RoomInit;       // 방안에 들어갔나 나왔나
    public bool Hide = false;   // 숨어있는지 아닌지
    
    // 숨어있는 상자 방향
    public bool Hide_right = false;
    public bool Hide_left = false;
    
    // 주인공 애니메이션
    public Animator HeroAnimator;

    // 미니게임
    public bool bDownCheck;

}