using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public PlayerHealth playerHP;
    public EnemyHealth enemyHP;
    Animator animationdoom;
    private float delay = 2f;
    public int scene;
    private float timeElapsed;

    private void Awake()
    {
        animationdoom = GetComponent<Animator>();
    }

    void Update () {

        if ((playerHP.CurrentHp <= 0) && (enemyHP.CurrentHp > 0))
        {
            animationdoom.SetTrigger("Game_Over");
            timeElapsed += Time.deltaTime;
            if(timeElapsed>delay)
            {
                SceneManager.LoadScene(scene);
            }
            
        }
        if ((playerHP.CurrentHp > 0) && (enemyHP.CurrentHp <= 0))
        {
            animationdoom.SetTrigger("Game_Over");
            timeElapsed += Time.deltaTime;
            if (timeElapsed > delay)
            {
                SceneManager.LoadScene(scene);
            }

        }
    }
}
