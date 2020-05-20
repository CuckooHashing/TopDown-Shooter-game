using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System;
using System.Data;

public class EnterNickname : HighScore_Manager {

    /*public Text entername;

    void Start () {
       

    }
	
	
	void Update () {
		
	}

    private void InsertScore(string username, int newscore)
    {
        GetScores();
        int hsCount = highscores.Count;
        if (highscores.Count > 0)
        {
            HighScore lowestscore = highscores[highscores.Count - 1];
            if (lowestscore != null && SaveScores > 0 && highscores.Count >= SaveScores && newscore > lowestscore.Score)
            {
                DeleteScore(lowestscore.ID);
                hsCount--;
            }
        }
        if (hsCount < SaveScores)
        {
            string sqlQuery = String.Format("INSERT INTO HighScores(Username,Score) VALUES(\"{0}\",\"{1}\")", username, newscore);
            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    dbConnection.Close();
                }
            }
        }
    }

    public void EnterName()
    {
        if(entername.text!=string.Empty)
        {
            int score = UnityEngine.Random.Range(1, 500);
            InsertScore(entername.text, score);
            entername.text = string.Empty;
            ShowScores();
        }
    }*/
}
