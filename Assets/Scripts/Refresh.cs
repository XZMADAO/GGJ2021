using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refresh : MonoBehaviour
{
    public GameObject BigMonster;
    public GameObject[] Trap = new GameObject[4];
    public Vector3 MonsterBornPosition;
    public Vector3 TrapBornPosition;
    public float BornTime;
    float Timer;
    float HardTimer;
    public float HardTime;
    public float BornTimeDown;
    public bool IsMonsterBorn;
    public bool IsTrapBorn;
    int RandomTrap;
    //float RandomTrapX;
    //float RandomTrapY;

    // Start is called before the first frame update
    void Start()
    {
        RandomTrap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HardTimer += Time.deltaTime;
        Timer += Time.deltaTime;

        if(IsMonsterBorn == true)
        {
            if (Timer >= BornTime)
            {
                Instantiate(BigMonster, MonsterBornPosition, BigMonster.transform.rotation);
                Timer = 0;
            }

            if (HardTimer >= HardTime)
            {
                BornTime = BornTime - BornTimeDown;
                HardTimer = 0;
            }

            if (BornTime <= 1.5f)
            {
                HardTimer = 0;
            }

        }

        if(IsTrapBorn == true)
        {
            if(Timer >= BornTime)
            {
                RandomTrap = Random.Range(0, 4);
                //RandomTrapX = Random.Range(-7f, 6.8f);
                //RandomTrapY = Random.Range(-3.6f, 3.6f);
                //TrapBornPosition = new Vector2(RandomTrapX, RandomTrapY);
                Instantiate(Trap[RandomTrap], TrapBornPosition, Trap[RandomTrap].transform.rotation);
                Timer = 0;
            }
        }

    }
}
