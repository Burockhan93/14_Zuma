using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Text input;
    private Dictionary<string, int[]> users;

    public Button[] buttons; // buttonlari daha iyi yonetmek icin array veya liste ile yapacaz bunu
    public ManageScenesSaves manager;

    private string user;

    private void Start()
    {
                
    }

    public void OnClickButton()
    {
        string name = EventSystem.current.currentSelectedGameObject.name; // name ile yaptik ama script ile gelistirilebilir
        Debug.Log(name);

        switch (name)
        {
            case "1": 
                LevelManager.currentLevel = 1;
                Playgame();
                //EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = null;
                break;
            case "2":
                LevelManager.currentLevel = 2;
                Playgame();
                break;
            case "3":
                LevelManager.currentLevel = 3;
                Playgame();
                break;
            case "4":
                LevelManager.currentLevel = 4;
                Playgame();
                break;
            case "5":
                LevelManager.currentLevel = 5;
                Playgame();
                break;
            case "6":
                LevelManager.currentLevel = 6;
                Playgame();
                break;
            case "7":
                LevelManager.currentLevel = 7;
                Playgame();
                break;
            case "8":
                LevelManager.currentLevel = 8;
                Playgame();
                break;
            case "9":
                LevelManager.currentLevel = 9;
                Playgame();
                break;
            case "10":
                LevelManager.currentLevel = 10;
                Playgame();
                break;
            case "11":
                LevelManager.currentLevel = 11;
                Playgame();
                break;
            case "12":
                LevelManager.currentLevel = 12;
                Playgame();
                break;
            

        }
    }

    public void Playgame()
    {
        Debug.Log(ManageScenesSaves.UserName);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ButtonHandler(int level)
    {
        for (int i = 0; i < buttons.Length; i++) // önce hepsi true
        {
            buttons[i].interactable = true;
            buttons[i].GetComponent<Animator>().enabled = true; 

        }
        for (int i = buttons.Length; i > level; i--)
        {
            buttons[i - 1].interactable = false;
            buttons[i - 1].GetComponent<Animator>().enabled = false;

        }
    }

        public void getName(string s)
    {       
        ManageScenesSaves.UserName = s;
        Debug.Log(s);

        users = manager.getData();
            

        if (users.ContainsKey(s))
        {
            ButtonHandler(users[s][0]);
            Debug.Log("Deger: " + users[s][1] + "level : "+ users[s][0]);
        }
        else
        { // degisecek
            SaveSystem.SaveUser(s);
            
            ButtonHandler(users[s][0]);
            Debug.Log(s+"  Deger: yok " + "level : " + users[s][0]);
        }
    }
}
