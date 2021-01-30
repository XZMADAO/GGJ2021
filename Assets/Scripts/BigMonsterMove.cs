using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2021 GGJ ������ƽű�

public class BigMonsterMove : MonoBehaviour
{
    public float speed; //  �ƶ��ٶ�
    public GameObject BigMonster;       //  ��ֶ���
    public GameObject SmallMonster;     //  С�ֶ���
    public GameObject Heart;     //  ����Ѫ��
    private Transform MonsterTransform;
    private int RandomTime;
    private SpriteRenderer MonsterSprite;
    public int RandomTimeMin;
    public int RandomTimeMax;
    public float Distance;
    private float MoveTimer;
    private float CopyTimer;
    public float CopyTime;
    private float RandomDirectionX;
    private float RandomDirectionY;
    private Animator Anim;
    /*private Vector2[] Directions = new Vector2[] {new Vector2(-1,0), new Vector2(0, 1), new Vector2(0, -1), new Vector2(1,0),
                                                    new Vector2(0.5f, 0.5f) , new Vector2(0.5f, -0.5f),new Vector2(-0.5f, 0.5f),new Vector2(0.5f, 0.5f) };*/
    private Vector2 Direction;
    public bool IsFree; //  �Ƿ�Ҫײǽ
    public bool IsLeft; //  �Ƿ�Ҫײǽ
    public bool IsRight; //  �Ƿ�Ҫײǽ
    public bool IsUp; //  �Ƿ�Ҫײǽ
    public bool IsDown; //  �Ƿ�Ҫײǽ
    public bool IsDead; //  �Ƿ�Ҫײǽ
    public bool IsBorn; //  �Ƿ�Ҫ����

    // Start is called before the first frame update
    void Awake()
    {
        MonsterTransform = BigMonster.GetComponent<Transform>();
        MonsterSprite = BigMonster.GetComponent<SpriteRenderer>();
        IsFree = true;
        IsDead = false;
        Anim = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        MoveTimer = 0;
        CopyTimer = 0;
        RandomTime = Random.Range(RandomTimeMin, RandomTimeMax);
        RandomDirectionX = Random.Range(-1f, 1f);
        RandomDirectionY = Random.Range(-1f, 1f);
        Direction = new Vector2(RandomDirectionX, RandomDirectionY).normalized;
        Anim.SetBool("IsBorn", false);

    }

    // Update is called once per frame
    void Update()
    {
        RayCheck(); 
        Move();
        //  �ƶ��߼�������ÿ�� ��RandomTimeMin �� RandomTimeMax�� ��任һ�η���Ҫײǽʱ���򷴷����ƶ�
        CopyMonstertime();
        // ��С���߼�������ÿ�� ��CopyTime�� ����ԭ������һ��С��


        if (IsDead == true)
        {
            CopyMonster(Heart);
            Destroy(gameObject);

        }
    }

    private void RayCheck()     //  ���߼��
    {
        
        RaycastHit2D RightHit = Physics2D.Raycast(MonsterTransform.position, new Vector2(1, 0), Distance);
        RaycastHit2D LeftHit = Physics2D.Raycast(MonsterTransform.position, new Vector2(-1, 0), Distance);
        RaycastHit2D UpHit = Physics2D.Raycast(MonsterTransform.position, new Vector2(0, 1), Distance);
        RaycastHit2D DownHit = Physics2D.Raycast(MonsterTransform.position, new Vector2(0, -1), Distance);

        if(IsRight = false && IsLeft == false && IsUp == false && IsDown == false)
        {
            IsFree = true;
        }
        else
        {
            IsFree = false;
        }

        if(RightHit.collider != null)
        {
            if (RightHit.collider.gameObject.tag == "edge" || RightHit.collider.gameObject.tag == "trap")
            {
                IsRight = true;

            }
        }
        else
        {
            IsRight = false;
        }

        if (LeftHit.collider != null)
        {
            if (LeftHit.collider.gameObject.tag == "edge" || LeftHit.collider.gameObject.tag == "trap")
            {
                IsLeft = true;

            }
        }
        else
        {
            IsLeft = false;
        }

        if (UpHit.collider != null)
        {
            if (UpHit.collider.gameObject.tag == "edge" || UpHit.collider.gameObject.tag == "trap")
            {
                IsUp = true;

            }
        }
        else
        {
            IsUp = false;
        }

        if(DownHit.collider != null)
        {
            if (DownHit.collider.gameObject.tag == "edge" || DownHit.collider.gameObject.tag == "trap")
            {
                IsDown = true;

            }
        }
        else
        {
            IsDown = false;
        }
    }

    private void Move()      // �ƶ�
    {
        MoveTimer += Time.deltaTime;     //  ��ʱ
        MonsterTransform.Translate(Direction * speed * Time.deltaTime);
        if (IsFree == true)
        {
            if (MoveTimer >= RandomTime)
            {
                RandomDirectionX = Random.Range(-1f, 1f);
                RandomDirectionY = Random.Range(-1f, 1f);
                RandomTime = Random.Range(RandomTimeMin, RandomTimeMax);
                MoveTimer = 0;
                Direction = new Vector2(RandomDirectionX, RandomDirectionY).normalized;
            }
         
        }
        else if (IsFree == false)
        {

            if (IsRight == true)
            {
                RandomDirectionX = Random.Range(-1f, 0f);
                RandomDirectionY = Random.Range(-1f, 1f);
                Direction = new Vector2(RandomDirectionX, RandomDirectionY).normalized;
            }

            if (IsLeft == true)
            {
                RandomDirectionX = Random.Range( 0f, 1f);
                RandomDirectionY = Random.Range(-1f, 1f);
                Direction = new Vector2(RandomDirectionX, RandomDirectionY).normalized;
            }

            if (IsUp == true)
            {
                RandomDirectionX = Random.Range(-1f, 1f);
                RandomDirectionY = Random.Range(-1f, 0f);
                Direction = new Vector2(RandomDirectionX, RandomDirectionY).normalized;
            }

            if (IsDown == true)
            {
                RandomDirectionX = Random.Range(-1f, 1f);
                RandomDirectionY = Random.Range( 0f, 1f);
                Direction = new Vector2(RandomDirectionX, RandomDirectionY).normalized;
            }

            MoveTimer = 0;
        }

        if (RandomDirectionX >= 0)
        {
            MonsterSprite.flipX = true;
        }
        else
        {
            MonsterSprite.flipX = false;
        }
    }

    public void CopyMonstertime()    //  ��С��
    {
        
        CopyTimer += Time.deltaTime;     //  ��ʱ
        if(CopyTimer >= CopyTime)
        {
            Anim.SetBool("IsBorn", true);
            CopyTimer = 0;
        }
        
    }

    public void CopyMonster(GameObject CopyOne)
    {
        Instantiate(CopyOne, MonsterTransform.position, MonsterTransform.rotation);
        Anim.SetBool("IsBorn",false);
    }


    
    private void OnTriggerEnter2D(Collider2D other)     //  ��������
    {
        if(other.gameObject.tag == "bullet")
        {
            IsDead = true;
        }
    }
}
