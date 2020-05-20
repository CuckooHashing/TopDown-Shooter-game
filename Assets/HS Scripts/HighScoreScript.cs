using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {

    public GameObject score;
    public GameObject score_user;
    public GameObject rank;

    public void SetScore (string user, string score, string rank)
    {
        this.rank.GetComponent<Text>().text = rank;
        this.score_user.GetComponent<Text>().text = user;
        this.score.GetComponent<Text>().text = score;
    }
}
