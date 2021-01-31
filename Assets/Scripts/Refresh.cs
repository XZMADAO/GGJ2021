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
    //float HardTimer;
    //public float HardTime;
    //public float BornTimeDown;
    public bool IsMonsterBorn;
    public bool IsTrapBorn;
    int RandomTrap;
    public bool IsOpen;
    //float RandomTrapX;
    //float RandomTrapY;

    // Start is called before the first frame update
    void Start()
    {
        RandomTrap = 0;
        MonsterBornPosition = gameObject.transform.position;
        TrapBornPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (IsMonsterBorn == true)
        {

            if (IsOpen == true)
            {
                Instantiate(BigMonster, MonsterBornPosition, BigMonster.transform.rotation);
                IsOpen = false;
            }

        }

        if (IsTrapBorn == true)
        {
            if (Timer >= BornTime)
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