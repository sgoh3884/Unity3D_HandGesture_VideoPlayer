using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FileTouch : MonoBehaviour
{
    private Vector3 oldPos;
    private Vector3 newPos;
    private Main main; 
    
    
    //public bool isTouch; // [public] *Touch 됬는지 확인
  
    // Start is called before the first frame update
    void Start()
    {
        oldPos = this.gameObject.transform.position;
        main = GameObject.Find("Manager").GetComponent<Main>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        newPos = this.gameObject.transform.position;

        if (newPos.z - oldPos.z >= 0.005) {
            // 한 프레임에 이동한 z 좌표
            if (!main.isTouched && Vector3.Angle(oldPos, newPos) >= .1f && Vector3.Angle(oldPos, newPos) <= .7f) {
                //print("Touch");
                main.isTouched = true;
            }
        }
        else {
            main.isTouched = false;
        }

        oldPos = newPos;
    }
}
