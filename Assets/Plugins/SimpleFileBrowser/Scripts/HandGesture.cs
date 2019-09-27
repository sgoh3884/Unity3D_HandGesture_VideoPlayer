using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandGesture : MonoBehaviour
{
    private const float DEADLINE = 0.5f;

    private Vector3 oldPos;
    private Vector3 newPos;
    private Main main;
    int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.Find("Manager").GetComponent<Main>();
        
        oldPos = this.gameObject.transform.position;
    }
    //void Update()
    //{


    //}
    // Update is called once per frame
    void Update()
    {
    //    if (main.isMoveUp)
    //    {
    //        print("UP " + cnt++);
    //    }
    //    if (main.isMoveDown)
    //    {
    //        print("Down " + cnt++);
    //    }
    //    if (main.isMoveLeft)
    //    {
    //        print("Left " + cnt++);
    //    }
    //    if (main.isMoveRight)
    //    {
    //        print("Right " + cnt++);
    //    }
        newPos = this.gameObject.transform.position; // 프레임 당 위치
        if (!main.isMove && main.isIndexActivate) {
            // 위
            if (newPos.y - oldPos.y >= 0.02) { // 한 프레임에 0.01 만큼 떨어지면
                main.timer = 0.0f; // 타이머 작동
                setFalse();
                main.isMoveUp = true;
            }
            // 아래
            else if (newPos.y - oldPos.y <= -0.02) {
                main.timer = 0.0f;
                setFalse();
                main.isMoveDown = true;
            }
            // 왼쪽
            else if (newPos.x - oldPos.x <= -0.02) {
                main.timer = 0.0f;
                setFalse();
                main.isMoveLeft = true;
            }
            // 오른쪽
            else if (newPos.x - oldPos.x >= 0.02) {
                main.timer = 0.0f;
                setFalse();
                main.isMoveRight = true;
            }
            else {
                oldPos = newPos;
            }

        }
        else {
            main.timer += Time.deltaTime;
            if (main.timer < DEADLINE && main.isIndexActivate)
            {
                if (main.isMoveUp && newPos.y - oldPos.y >= 0.04)
                {
                    oldPos = newPos;
                }
                else if (main.isMoveDown && newPos.y - oldPos.y <= -0.04)
                {
                    oldPos = newPos;
                }
                else if (main.isMoveLeft && newPos.x - oldPos.x <= -0.04)
                {
                    oldPos = newPos;
                }
                else if (main.isMoveRight && newPos.x - oldPos.x >= 0.04)
                {
                    oldPos = newPos;
                }
            }
            else if (Mathf.Abs(newPos.x - oldPos.x) <= 0.05 && Mathf.Abs(newPos.y - oldPos.y) <= 0.05 && main.isIndexActivate)
            {
                
            }
            else
            {
                setFalse();
                main.timer = 0.0f;
                oldPos = newPos;
            }
        }
    }

    void setFalse()
    {
        //StartCoroutine(TimeDelay());
        main.isMove = false;
        main.isMoveUp = false;
        main.isMoveDown = false;
        main.isMoveLeft = false;
        main.isMoveRight = false;
    }


    public void OnIndexActivate()
    {
        main.isIndexActivate = true;
    }

    public void OnIndexDeactivate()
    {
        main.isIndexActivate = false;
    }

    public void OnFingerClickActivate()
    {
      
        main.isFingerClickActivate = true;
    }

    public void OnFingerClickDeactivate()
    {
        main.isFingerClickActivate = false;
    }

    public void OnReadyToPinchActivate()
    {
        main.isReadyToPinchActivate = true;
    }

    public void OnReadyToPinchDeactivate()
    {
        main.isReadyToPinchActivate = false;
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(0.05f);
       
    }
}
