using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
    public int Damage = 1;
    GameObject PlayerObject;
    PlayerHealth Player_Health;

    private void Awake()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        Player_Health = PlayerObject.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject==PlayerObject)
        {
            Player_Health.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
