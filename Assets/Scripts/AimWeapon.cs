using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Transform firePoint;
    public GameObject bullet;

    [Space]
    [Header("Transform")]
    public float angle;

    [Space]
    [Header("Shooting")]
    public float shootInterval;
    public float shootForce;
    public float backForce;

    //Transform private
    private float positiveDetecteAngle;
    private float negativeDetecteAngle;
    private float relativeX;
    
    //Shooting private
    private float shootCountDown;
    private int shootCount = 0;

    void Start()
    {
        relativeX = Mathf.Abs(transform.position.x - player.transform.position.x);
        positiveDetecteAngle = Mathf.Abs(angle);
        negativeDetecteAngle = 180 - positiveDetecteAngle;
        shootCountDown = shootInterval;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateTransform();
        if(Input.GetButtonDown("Fire1"))
        {
            shootCount++;
        }
        if(shootCount>0)
        {
            if (shootCountDown > 0)
                shootCountDown -= Time.deltaTime;
            else
            {
                Shoot();
                shootCountDown = shootInterval;
                shootCount--;
            }
        }
    }
    void CalculateTransform()
    {
        Vector3 mousePisiotion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePisiotion - transform.position).normalized;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (Mathf.Abs(transform.position.x - (player.transform.position.x + relativeX)) < 0.001)
        {
            if (rotZ > positiveDetecteAngle || rotZ < -positiveDetecteAngle)
                transform.position = new Vector3(player.transform.position.x - relativeX, transform.position.y, transform.position.z);
        }
        //Debug.Log(transform.position.x);
        //Debug.Log(player.position.x - relativeX);
        //Debug.Log(transform.position.x == player.position.x - relativeX);
        if (Mathf.Abs(transform.position.x - (player.transform.position.x - relativeX)) < 0.001)
        {
            if (rotZ < negativeDetecteAngle && rotZ > -negativeDetecteAngle)
                transform.position = new Vector3(player.transform.position.x + relativeX, transform.position.y, transform.position.z);
        }


        //if (rotZ < detecteAngle && rotZ > detecteAngle)
        //    transform.position =  new Vector3(player.position.x + relativeX, transform.position.y, transform.position.z);
        //else
        //    transform.position = new Vector3(player.position.x - relativeX, transform.position.y, transform.position.z);
    }

    void Shoot()
    {
        GameObject tempBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(ShootingArea(firePoint.up) * shootForce, ForceMode2D.Impulse);
   //     player.GetComponent<Rigidbody2D>().velocity -= new Vector2(firePoint.up.x * backForce, firePoint.up.y * backForce);
    //    Debug.Log(player.GetComponent<Rigidbody2D>().velocity);
    }
    Vector3 ShootingArea(Vector3 oriVec)
    {
        float ranAngle = Random.Range(-15, 15);
        return Quaternion.Euler(0, 0, ranAngle) * oriVec;
    }

}
