using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;
    Text text;
    private void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
    }
    private void Update()
    {
        int plus = 0, more = 0;
        text.text = (score+plus).ToString();
        more++;
        plus += more;
    }
}
