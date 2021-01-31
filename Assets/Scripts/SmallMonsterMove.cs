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
    private SpriteRenderer MonsterSprite;
    public GameObject Heart;    //  ��������
    public bool IsAngry;
    public bool IsDead;
    private float Timer;
    public float SearchTime;
    Vector3 EndPositon;
    Vector3 Direction;

    public GameObject explosion;
    void Awake()
    {
        PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
        SmallMonsterTransform = gameObject.GetComponent<Transform>();
        MonsterSprite = gameObject.GetComponent<SpriteRenderer>();
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
        Direction = EndPositon - SmallMonsterTransform.position;
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


        if (Direction.x>= 0)
        {
            MonsterSprite.flipX = true;
        }
        else
        {
            MonsterSprite.flipX = false;
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

    private void OnTriggerEnter2D(Collider2D other)    //   �������ж�
    {
        Debug.Log("1");
        if (other.gameObject.tag == "trap" || other.gameObject.tag == "edge")
        {  
            IsDead = true;
        }

        if (other.gameObject.tag == "bullet")
        {
            GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(effect, 5f);
            IsDead = true;
        }

        if (other.gameObject.tag == "Player")
        {
            IsDead = true;
        }

        if (other.gameObject.tag == "sucker")
        {
            IsAngry = true;
        }
        else
        {
            IsAngry = false;
        }
    }


}
