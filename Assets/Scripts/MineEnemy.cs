using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineEnemy : MonoBehaviour
{
    //Attributes
    public float range = 10f;
    public float speed = 20f;
    public Transform target;

    public float hitDistance = 2;

    public bool followingPlayer = false;

    public string enemyTag = "Player";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("followPlayer", 0f, 0.5f);
    }

    void followPlayer()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= range)
        {
            followingPlayer = true;
        } else
        {
            followingPlayer = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(followingPlayer == true)
        {
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);

            if (dir.magnitude <= hitDistance)
            {
                HitTarget();
                return;
            }
        }
    }

    void HitTarget()
    {
        Debug.Log("MINE HIT");
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
