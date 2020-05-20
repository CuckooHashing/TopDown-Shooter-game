using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpImageChange : MonoBehaviour
{

    public int MaxHp;
    public int CurrentHp;
    public Slider HpSlider;
    public Image HpSprite;
    public Sprite SpriteHigh, SpriteMedium, SpriteLow;
    void Update()
    {
        if(HpSlider.value<HpSlider.maxValue*2/3)
        {
            if(HpSlider.value<HpSlider.maxValue/3)
            {
                HpSprite.sprite = SpriteLow;
            }
            else
            {
                HpSprite.sprite = SpriteMedium;
            }
        }
        else
        {
            HpSprite.sprite = SpriteHigh;
        }
    }
}
