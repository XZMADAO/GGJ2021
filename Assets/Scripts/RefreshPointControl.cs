using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshPointControl : MonoBehaviour
{

    public GameObject[] RefreshPoint = new GameObject[8];
    int RandomA;
    int RandomB;
    float Timer;
    public float BornTime;
    float HardTimer;
    public float HardTime;
    public float BornTimeDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HardTimer += Time.deltaTime;
        Timer += Time.deltaTime;
        if (Timer >= BornTime)
        {
            RandomA = Random.Range(0, 8);
            RandomB = Random.Range(0, 8);
            for(int i=0; RandomB == RandomA; i++)
            {
                RandomB = Random.Range(0, 8);
            }

            RefreshPoint[RandomA].GetComponent<Refresh>().IsOpen = true;
            RefreshPoint[RandomB].GetComponent<Refresh>().IsOpen = true;
            Timer = 0;
        }

        if (HardTimer >= HardTime)
        {
            BornTime = BornTime - BornTimeDown;
            HardTimer = 0;
        }

        if (BornTime <= 2f)
        {
            HardTimer = 0;
        }
    }
}
