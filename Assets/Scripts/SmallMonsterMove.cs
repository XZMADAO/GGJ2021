using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMonsterMove : MonoBehaviour
{
    public float NormalSpeed;     //  普通移动速度
    public float AngrySpeed;      //  被吸引的移动速度 
    //public GameObject Player;   //  玩家对象
    private Transform PlayerTransform;
    private Transform SmallMonsterTransform;
    public GameObject Heart;    //  掉落生命
    public bool IsAngry;
    public bool IsDead;
    private float Timer;
    public float SearchTime;
    Vector3 EndPositon; 

    void Awake()
    {
        PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
        SmallMonsterTransform = gameObject.GetComponent<Transform>();
    }
    void Start()
    {
        IsDead = false;
        IsAngry = false;
        EndPositon = PlayerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= SearchTime)
        {
            EndPositon = PlayerTransform.position;

            if (IsAngry == true)
            {
                SmallMonsterTransform.position = Vector3.MoveTowards(SmallMonsterTransform.position,EndPositon, AngrySpeed * Time.deltaTime);    //  索敌
            }
            else
            {
                SmallMonsterTransform.position = Vector3.MoveTowards(SmallMonsterTransform.position, EndPositon, NormalSpeed * Time.deltaTime);
            }

            Timer = 0;
        }
        else
        {
            if (IsAngry == true)
            {
                SmallMonsterTransform.position = Vector3.MoveTowards(SmallMonsterTransform.position, EndPositon, AngrySpeed * Time.deltaTime);    //  索敌
            }
            else
            {
                SmallMonsterTransform.position = Vector3.MoveTowards(SmallMonsterTransform.position, EndPositon, NormalSpeed * Time.deltaTime);
            }
        }

        if (IsDead == true)     //  死亡判定
        {
            
            //CopyMonster(Heart);
            Destroy(gameObject);
        }
    }

    private void CopyMonster(GameObject CopyOne)    //  生小怪
    {
            Instantiate(CopyOne, SmallMonsterTransform.position, SmallMonsterTransform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)    //   陷阱判定
    {
        Debug.Log("1");
        if (other.gameObject.tag == "trap" || other.gameObject.tag == "edge")
        {  
            IsDead = true;
        }

        if(other.gameObject.tag == "sucker")
        {
            IsAngry = true;
        }
        else
        {
            IsAngry = false;
        }
    }


}
