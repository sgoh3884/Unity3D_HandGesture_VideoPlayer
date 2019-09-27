using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Main : MonoBehaviour
{
    public bool isTouched;
    public bool isHovered;

    public float timer;
    public bool isMove;
    public bool isMoveUp;
    public bool isMoveDown;
    public bool isMoveLeft;
    public bool isMoveRight;

    public bool isIndexActivate;
    public bool isFingerClickActivate;
    public bool isReadyToPinchActivate;

    // Start is called before the first frame update
    void Start()
    {
        isTouched = false;
        isHovered = false;

        timer = 0.0f;
        isMove = false;
        isMoveUp = false;
        isMoveDown = false;
        isMoveLeft = false;
        isMoveRight = false;

        isIndexActivate = false;
        isFingerClickActivate = false;
        isReadyToPinchActivate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoveUp || isMoveDown || isMoveLeft || isMoveRight)
        {
            isMove = true;
        }
    }
}
