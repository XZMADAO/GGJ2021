using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2021 GGJ 怪物控制脚本

public class BigMonsterMove : MonoBehaviour
{
    public float speed; //  移动速度
    public GameObject BigMonster;       //  大怪对象
    public GameObject SmallMonster;     //  小怪对象
    public GameObject Heart;     //  掉落血量
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
    public bool IsFree; //  是否要撞墙
    public bool IsLeft; //  是否要撞墙
    public bool IsRight; //  是否要撞墙
    public bool IsUp; //  是否要撞墙
    public bool IsDown; //  是否要撞墙
    public bool IsDead; //  是否要撞墙
    public bool IsBorn; //  是否要生子

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
        //  移动逻辑：怪物每隔 （RandomTimeMin 至 RandomTimeMax） 秒变换一次方向，要撞墙时会向反方向移动
        CopyMonstertime();
        // 生小怪逻辑：怪物每隔 （CopyTime） 秒在原地生出一个小怪


        if (IsDead == true)
        {
            CopyMonster(Heart);
            Destroy(gameObject);

        }
    }

    private void RayCheck()     //  射线检测
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

    private void Move()      // 移动
    {
        MoveTimer += Time.deltaTime;     //  计时
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

    public void CopyMonstertime()    //  生小怪
    {
        
        CopyTimer += Time.deltaTime;     //  计时
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


    
    private void OnTriggerEnter2D(Collider2D other)     //  掉落生命
    {
        if(other.gameObject.tag == "bullet")
        {
            IsDead = true;
        }
    }
}
