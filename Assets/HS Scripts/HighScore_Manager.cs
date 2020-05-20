using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore_Manager : MonoBehaviour {

    private string connectionString;
    private List<HighScore> highscores = new List<HighScore>();
    public GameObject scorePrefab;
    public Transform Parent;
    public int TopRanks;
    public int SaveScores;
    public InputField entername;
   //rivate string nickname;
    

    void Start() {
        connectionString = "URI=file:" + Application.dataPath + "/HighScoreDB.sqlite";
    //  InsertScore(nickname, ScoreManager.score);
        CreateTabel();
        DeleteExtraScores();
        ShowScores();
    }
    private void CreateTabel()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {

                string sqlQuery = String.Format("CREATE TABLE if not exists HighScores (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, Username TEXT NOT NULL, Score INTEGER NOT NULL)");
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                
                dbConnection.Close();
            }
        }
    }

    public void DeleteExtraScores()
    {
        GetScores();
        if(SaveScores<=highscores.Count)
        {
            int DeleteCount = highscores.Count - SaveScores;
            highscores.Reverse();
            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    for(int i=0; i<DeleteCount; i++)
                    {
                        string sqlQuery = String.Format("DELETE FROM HighScores WHERE ID=\"{0}\"", highscores[i].ID);
                        dbCmd.CommandText = sqlQuery;
                        dbCmd.ExecuteScalar();
                    }
                    
                    dbConnection.Close();
                }
            }

        }
    }

    public void ShowScores()
    {
        GetScores();
        foreach (GameObject scorePrefab in GameObject.FindGameObjectsWithTag("Score"))
        {
            Destroy(scorePrefab);
        }
        for (int i = 0; i < TopRanks; i++)
        {
            if(i <= highscores.Count - 1)
            {
                GameObject tmpObj = Instantiate(scorePrefab);
                HighScore tmpScor = highscores[i];
                tmpObj.GetComponent<HighScoreScript>().SetScore(tmpScor.Username, tmpScor.Score.ToString(), "#" + (i + 1).ToString());
                tmpObj.transform.SetParent(Parent);
            }
        }
    }

    public void GetScores()
    {
        highscores.Clear();
        string sqlQuery = "SELECT * FROM HighScores";
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        highscores.Add(new HighScore(reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1)));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        highscores.Sort();
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
        if (hsCount< SaveScores)
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
    public void DeleteScore (int id)
    {
        string sqlQuery = String.Format("DELETE FROM HighScores WHERE ID=\"{0}\"", id);
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
    public void EnterName(int scene)
    {
        if (entername.text != string.Empty)
        {

             InsertScore(entername.text, ScoreManager.score);
            //  Debug.Log(ScoreManager.score.ToString());
        //  nickname = entername.text;
            entername.text = string.Empty;
            SceneManager.LoadScene(scene);
            ShowScores();
        }
    }
        void Update ()
    {
		
	}
}
