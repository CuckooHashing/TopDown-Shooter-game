using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaBoss_Behaviour : MonoBehaviour {

    public Transform[] Waypoints;
    public float speed;
    public int cWaypoint;
    public bool Patrol = true;
    public Vector3 Target;
    public Vector3 Move_Direction;
    public Vector3 Velocity;

    public float speedMult = 1.0f;
    public float rangeMult = 1.0f;
    
    /*public GameObject bullet;
    public float shootInterval = 1.0f;
    float basex = 0.0f;
    float shootTimeAc = 0.0f;
    public Transform AnimaBullets;*/
    private void Update()
    {
        if (cWaypoint < Waypoints.Length)
        {
            Target = Waypoints[cWaypoint].position;
            Move_Direction = Target - transform.position;
            Velocity = GetComponent<Rigidbody>().velocity;
            if (Move_Direction.magnitude < 1)
            {
                cWaypoint++;
            }
            else Velocity = Move_Direction.normalized * speed;
        }
        else
        {
            if (Patrol) cWaypoint = 0;
            else Velocity = Vector3.zero;
        }
        GetComponent<Rigidbody>().velocity = Velocity;
        
     /*
        float interval = Mathf.Sin(Time.time * (speedMult / rangeMult)) * rangeMult;
        bool shoot = false;
        if (Time.deltaTime + shootTimeAc > shootInterval)
        {
            shootTimeAc = 0.0f;
            shoot = true;
        }

        else
            shootTimeAc += Time.deltaTime;

        if (shoot)
            Instantiate(bullet, transform.position, bullet.transform.rotation);*/
    }


}
