using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMonsterMove : MonoBehaviour
{
    public float NormalSpeed;     //  ��ͨ�ƶ��ٶ�
    public float AngrySpeed;      //  ���������ƶ��ٶ� 
    //public GameObject Player;   //  ��Ҷ���
    private Transform PlayerTransform;
    private Transform SmallMonsterTransform;
    public GameObject Heart;    //  ��������
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
                SmallMonsterTransform.position = Vector3.MoveTowards(SmallMonsterTransform.position,EndPositon, AngrySpeed * Time.deltaTime);    //  ����
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
                SmallMonsterTransform.position = Vector3.MoveTowards(SmallMonsterTransform.position, EndPositon, AngrySpeed * Time.deltaTime);    //  ����
            }
            else
            {
                SmallMonsterTransform.position = Vector3.MoveTowards(SmallMonsterTransform.position, EndPositon, NormalSpeed * Time.deltaTime);
            }
        }

        if (IsDead == true)     //  �����ж�
        {
            
            //CopyMonster(Heart);
            Destroy(gameObject);
        }
    }

    private void CopyMonster(GameObject CopyOne)    //  ��С��
    {
            Instantiate(CopyOne, SmallMonsterTransform.position, SmallMonsterTransform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)    //   �����ж�
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
