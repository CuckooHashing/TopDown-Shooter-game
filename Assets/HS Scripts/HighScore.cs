using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class HighScore : IComparable<HighScore>
{
    public int Score { get; set; }
    public string Username { get; set; }
    public int ID { get; set; }
    public HighScore(int id, int score, string username)
    {
        this.Score = score;
        this.ID = id;
        this.Username = username;
    }
    
    public int CompareTo(HighScore other)
    {
        if (other.Score > this.Score)
            return 1;
        else if (other.Score < this.Score)
            return -1;
        return 0;
    }
}