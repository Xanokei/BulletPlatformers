using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{


    //Attributes
    [Header("Attributes")]
    public float range = 15f;
    public float turnSpeed = 10f;
    public float fireRate = 1f; //Fire rate PER SECOND
    private float fireCountDown = 0f;

    [Header("Turret mechanics fields")]
    public Transform target;
    public string enemyTag = "Player";
    public Transform turretRotator;

    public GameObject bulletPrefab;
    public Transform firePoint;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(enemyDistance < shortestDistance)
            {
                shortestDistance = enemyDistance;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        } else
        {
            //CODE FOR TURRET ROTATION
            //Jonah Method
            //turretRotator.transform.LookAt(target);

            //Brackey's method (SIMPLE)
            //Vector3 dir = target.position - transform.position;
            //Quaternion lookRotation = Quaternion.LookRotation(dir);
            //Vector3 rotation = lookRotation.eulerAngles;
            //For rotating entire turret to point at player
            //turretRotator.rotation = lookRotation;
            //for only one axis (2d?)
            //turretRotator.rotation = Quaternion.Euler (0f, rotation.y, 0f);

            //Brackey's method (SMOOTHED)
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(turretRotator.rotation,lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            //For rotating entire turret to point at player
            //turretRotator.rotation = lookRotation;
            //for only one axis(2d ?)
            turretRotator.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        //CODE FOR TURRET SHOOTING
        //IF cooling == 0 FIRE
        if(fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        //Countdown cooling time
        fireCountDown -= Time.deltaTime;
    }

    void Shoot()
    {
        //Debug.Log("FIRE");
        //FOR FOLLOWING BULLETS
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Follow(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
