using UnityEngine;
using System.Collections;

public class MoveBt : MonoBehaviour {

    public GameObject Hero;
    //@ 버튼
    public bool Right_ = false;
    public bool Left_ = false;
    //@ Collision으로 들어올때
    public bool C_Right_ = false;           
    public bool C_Left_ = false;            
    public void RightBt_in()
    {
        if(!C_Right_)
            Right_ = true;
    }

    public void RightBt_out()
    {
        Right_ = false;
    }

    public void LeftBt_in()
    {
        if (!C_Left_)
            Left_ = true;
    }
      
    public void LeftBt_out()
    {
        Left_ = false;
    }

    void Update()
    {
        if(Right_)
            Hero.transform.Translate(0.15f, 0, 0);
        if(Left_)
            Hero.transform.Translate(-0.15f, 0, 0);
    }
}