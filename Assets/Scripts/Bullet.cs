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
   
    void OnCollisionEnter2D(Collision2D other)
    {
      //  if(!other.isTrigger)
      //  {
            if (other.gameObject.tag != "Player")
            {
                Debug.Log("123");
                Destroy(gameObject);
            }

        //}
        //else
        //{
        //    if (other.gameObject.tag == "Monster")
        //        Destroy(gameObject);
        //}
    }

}
