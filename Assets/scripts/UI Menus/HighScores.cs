using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class HighScores : MonoBehaviour
{
    private Dictionary<string, int[]> users;
    
    public TextMeshProUGUI text;

    public ManageScenesSaves manager;

    public void Start()
    {        
        users = manager.getData();
        writeScores(users);
    }

    public void writeScores(Dictionary<string, int[]> users)
    {
        Debug.Log("Calisti");
        Debug.Log(users["diladam"][0] + " " + users["diladam"][1]+" "+ users["diladam"][2]);
        users = users.OrderByDescending(pair => pair.Value[1]).Take(3).ToDictionary(pair=>pair.Key,pair=>pair.Value);//System.Linq in bir parcasi. en ust 3 u alcaz.

        
        foreach (KeyValuePair<string, int[]> kvp in users)
        
        {
            text.text += kvp.Key;
            text.text += string.Join(string.Format("Key ={0} .... Value ={1}", kvp.Key, kvp.Value[1]),System.Environment.NewLine); 
            
        }
    }
}
