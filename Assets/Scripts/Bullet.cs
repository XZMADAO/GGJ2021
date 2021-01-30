using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.isTrigger)
        {
            if(other.gameObject.tag!="Player")
                Destroy(gameObject);

        }
        else
        {
            if (other.gameObject.tag == "Monster")
                Destroy(gameObject);
        }
    }
}
