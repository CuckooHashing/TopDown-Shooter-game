using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour {
    public int score_value;
    public int Damage;
    GameObject PlayerObject;
    EnemyHealth Enemy_Health;

    private void Awake()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Boss Enemy");
        Enemy_Health = PlayerObject.GetComponent<EnemyHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerObject)
        {
            Enemy_Health.TakeDamage(Damage);
            Destroy(gameObject);
            ScoreManager.score += score_value;
        }
    }


}
