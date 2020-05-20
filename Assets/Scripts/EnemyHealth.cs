using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public int MaxHp;
    public int CurrentHp;
    public Slider hpSlider;

    private void Awake()
    {
        CurrentHp = MaxHp;
    }
    public void TakeDamage(int amount)
    {
        CurrentHp -= amount;
        hpSlider.value = CurrentHp;
        if (CurrentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
