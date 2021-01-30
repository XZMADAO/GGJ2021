using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public Movement move;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (rotZ < -135 || rotZ > 135)
            anim.SetFloat("angle", 0);
        if(rotZ>45&&rotZ<135)
            anim.SetFloat("angle", 1);
        if (rotZ > -45 && rotZ < 45)
            anim.SetFloat("angle", 2);
        if (rotZ > -135 && rotZ < -45)
            anim.SetFloat("angle", 3);
        if(move.dir.x!=0||move.dir.y!=0)
            anim.SetFloat("speed", 1);
        else
            anim.SetFloat("speed", 0);
    }
}
