using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaBoss_Attack : MonoBehaviour
{

    public GameObject shot;
    public Transform BulletSpawn;
    public float FireRate;
    private float NextFire;

    void Update()
    {
        if (Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
        }
    }
}