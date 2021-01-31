using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;


    [Space]
    [Header("Stats")]
    public float speed;
    public float countDown;
    public float backCount;
    public float loseSpeed;
    public float attractTime;

    [Space]
    [Header("Key")]
    public GameObject[] keys;

    [Space]
    [Header("AttractArea")]
    public GameObject[] attractArea;

    [Space]
    [Header("Particle")]
    public ParticleSystem[] keyParticles;
    public ParticleSystem[] novaParticles;

    //Movement Relavent
    public Vector2 dir;

    //keyLost Relavent
    private float countDownW;
    private float countDownA;
    private float countDownS;
    private float countDownD;
    private bool wBan;
    private bool aBan;
    private bool sBan;
    private bool dBan;

    //attractRelavent
    private int backBarW;
    private int backBarA;
    private int backBarS;
    private int backBarD;
    private float attractW;
    private float attractA;
    private float attractS;
    private float attractD;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        countDownW = countDown;
        countDownA = countDown;
        countDownD = countDown;
        countDownS = countDown;
    }


    void Update()
    {
        KeyCountDown();
        KeyCountReset();
        KeyBack();
        AttractAreaActive();

        //dir.x = Input.GetAxisRaw("Horizontal");
        //dir.y = Input.GetAxisRaw("Vertical");
        Walk();

    }

    void Walk()
    {
        rb.velocity = new Vector2(dir.x * speed, dir.y * speed);
    }

    void KeyCountReset()
    {
        float xTemp = 0;
        float yTemp = 0;
        if (Input.GetKey(KeyCode.W) && !wBan)
        {
            yTemp++;
            countDownW = countDown;
        }

        if (Input.GetKey(KeyCode.A) && !aBan)
        {
            xTemp--;
            countDownA = countDown;
        }

        if (Input.GetKey(KeyCode.S) && !sBan)
        {
            yTemp--;
            countDownS = countDown;
        }

        if (Input.GetKey(KeyCode.D) && !dBan)
        {
            xTemp++;
            countDownD = countDown;
        }
        dir.x = xTemp;
        dir.y = yTemp;
    }    
    void KeyCountDown()
    {
        if (!wBan)
        {
            if (countDownW > 0)
            {
                countDownW -= Time.deltaTime;
                Color tempColor = keys[0].GetComponent<SpriteRenderer>().color;
                keys[0].GetComponent<SpriteRenderer>().color = new Color(tempColor.r, tempColor.g, tempColor.b, countDownW / countDown * 1.0f);
            }

            else
            {
                keyParticles[0].Play();
                wBan = true;
                backBarW = 0;
                countDownW = 0;
            }
        }
        if (!aBan)
        {
            if (countDownA > 0)
            {
                countDownA -= Time.deltaTime;
                Color tempColor = keys[1].GetComponent<SpriteRenderer>().color;
                keys[1].GetComponent<SpriteRenderer>().color = new Color(tempColor.r, tempColor.g, tempColor.b, countDownA / countDown * 1.0f);
            }
            else
            {
                keyParticles[1].Play();
                aBan = true;
                backBarA = 0;
                countDownA = 0;
            }
        }

        if (!sBan)
        {
            if (countDownS > 0)
            {
                countDownS -= Time.deltaTime;
                Color tempColor = keys[2].GetComponent<SpriteRenderer>().color;
                keys[2].GetComponent<SpriteRenderer>().color = new Color(tempColor.r, tempColor.g, tempColor.b, countDownS / countDown * 1.0f);
            }
            else
            {
                keyParticles[2].Play();
                sBan = true;
                backBarS = 0;
                countDownS = 0;
            }
        }
        if (!dBan)
        {
            if (countDownD > 0)
            {
                Color tempColor = keys[3].GetComponent<SpriteRenderer>().color;
                keys[3].GetComponent<SpriteRenderer>().color = new Color(tempColor.r, tempColor.g, tempColor.b, countDownD / countDown * 1.0f);
                countDownD -= Time.deltaTime;
            }
            else
            {
                keyParticles[3].Play();
                dBan = true;
                backBarD = 0;
                countDownD = 0;
            }
        }
    }    

    void KeyBack()
    {
        if (wBan)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                backBarW++;
                attractW = attractTime;
                attractArea[0].SetActive(true);
            }
            if(backBarW>= backCount)
            {
                wBan = false;
                countDownW = countDown;
                attractW = 0;
                attractArea[0].SetActive(false);
                novaParticles[0].Play();
            }
            Color tempColor = keys[0].GetComponent<SpriteRenderer>().color;
            keys[0].GetComponent<SpriteRenderer>().color = new Color(tempColor.r, tempColor.g, tempColor.b, backBarW / backCount * 1.0f);
        }
        if(aBan)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                backBarA++;
                attractA = attractTime;
                attractArea[1].SetActive(true);
            }
            if (backBarA >= backCount)
            {
                aBan = false;
                countDownA = countDown;
                attractA = 0;
                attractArea[1].SetActive(false);
                novaParticles[1].Play();
            }
            Color tempColor = keys[1].GetComponent<SpriteRenderer>().color;
            keys[1].GetComponent<SpriteRenderer>().color = new Color(tempColor.r, tempColor.g, tempColor.b, backBarA / backCount * 1.0f);
        }
        if(sBan)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                backBarS++;
                attractS = attractTime;
                attractArea[2].SetActive(true);
            }
            if (backBarS >= backCount)
            {
                sBan = false;
                countDownS = countDown;
                attractS = 0;
                attractArea[2].SetActive(false);
                novaParticles[2].Play();
            }
            Color tempColor = keys[2].GetComponent<SpriteRenderer>().color;
            keys[2].GetComponent<SpriteRenderer>().color = new Color(tempColor.r, tempColor.g, tempColor.b, backBarS / backCount * 1.0f);
        }
        if(dBan)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                backBarD++;
                attractD = attractTime;
                attractArea[3].SetActive(true);
            }
            if (backBarD >= backCount)
            {
                dBan = false;
                countDownD = countDown;
                attractD = 0;
                attractArea[3].SetActive(false);
                novaParticles[3].Play();
            }
            Color tempColor = keys[3].GetComponent<SpriteRenderer>().color;
            keys[3].GetComponent<SpriteRenderer>().color = new Color(tempColor.r, tempColor.g, tempColor.b, backBarD / backCount * 1.0f);
        }
    }



    void AttractAreaActive()
    {
        if(wBan)
        {
            if (attractW > 0)
                attractW -= Time.deltaTime;
            else
            {
                attractW = 0;
                attractArea[0].SetActive(false);
            }
        }
        if (aBan)
        {
            if (attractA > 0)
                attractA -= Time.deltaTime;
            else
            {
                attractA = 0;
                attractArea[1].SetActive(false);
            }
        }
        if (sBan)
        {
            if (attractS > 0)
                attractS -= Time.deltaTime;
            else
            {
                attractS = 0;
                attractArea[2].SetActive(false);
            }
        }
        if (dBan)
        {
            if (attractD > 0)
                attractD -= Time.deltaTime;
            else
            {
                attractD = 0;
                attractArea[3].SetActive(false);
            }
        }

    }

    void KeyBackLose()
    {
        if(wBan)
        {

        }
    }
}
