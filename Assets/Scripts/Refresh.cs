using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refresh : MonoBehaviour
{
    public GameObject BigMonster;
    public Vector3 BornPosition;
    public float BornTime;
    float Timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer>= BornTime)
        {
            Instantiate(BigMonster, BornPosition, BigMonster.transform.rotation);
            Timer = 0;
        }
        
    }
}
