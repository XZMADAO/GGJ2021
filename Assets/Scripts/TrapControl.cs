using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControl : MonoBehaviour
{
    float DestroyTimer;
    public float DestroyTime;

    // Start is called before the first frame update
    void Start()
    {
        DestroyTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyTimer += Time.deltaTime;
        if(DestroyTimer >= DestroyTime)
        {
            Destroy(gameObject);
        }
    }
}
