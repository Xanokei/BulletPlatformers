using UnityEngine;

public class Bullet : MonoBehaviour
{
    //If want FOLLOWING BULLETS
    private Transform target;

    public float speed = 1f;
    public float lifetime = 3f;

    public void Follow (Transform _target)
    {
        target = _target;
    }

    private void Start()
    {
        //Lifetime
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        //for FOLLOWING BULLETS
        //transform.LookAt(target);
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        //if HIT TARGET
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        //Space.world sets direction to worldspace, STOPS ORBITAL/CIRCULAR MOVEMENT
        //transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        //STRAIGHT BULLETS
        transform.Translate(Vector3.forward * distanceThisFrame);
        //for STRAIGHT BULLETS 
    }

    void HitTarget()
    {
        Debug.Log("HIT");
        Destroy(gameObject);
    }
}
