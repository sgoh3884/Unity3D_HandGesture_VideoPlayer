using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    private Main main;
    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.Find("Manager").GetComponent<Main>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnActivate()
    {
        print("O");
    }

    public void OnDeactivate()
    {
        print("X");
    }
}
