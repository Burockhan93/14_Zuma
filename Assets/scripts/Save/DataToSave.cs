using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DataToSave  // bu class önemli hangi bilgiler save edilecek buraya yazcaz su an sadece level. Score falan yok highscore icin düsünüleblr
{
    // String name----- level , score ve bestsocre arrayin icinde
    private Dictionary<string, int[]> Users = new Dictionary<string, int[]>();

    public void addUser(string user)
    {
        if (!Users.ContainsKey(user))
        {
            Users.Add(user, new int[3] );  //1 leveli, 0 ana kadarki score, -1 bestscore
            Users[user][0] = 1;
        }
        return;
        
    }

    public void addHighScore(string user, int hScore)
    {
        if (Users.ContainsKey(user))
        {
            Users1[user][0] = 12;
            
            Users1[user][2] = hScore;
        }
        
    }
    public void saveProgress(string user, int lvl, int score)
    {
        if (Users.ContainsKey(user))
        {
            Users1[user][0] = lvl;
            Users1[user][1] = score;
            
        }

    }
    private void deleteUser(string s)
    {

    }

    private void deleteHighScore(string s)
    {

    }

    private void deleteAll()
    {
       Users = new Dictionary<string, int[]>();
    }

    public Dictionary<string, int[]> Users1 { get => Users; set => Users = value; }
}
