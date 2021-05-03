using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EndLevel : MonoBehaviour
{
    public Button[] buttons;
    public TextMesh text;


    public void OnClickButton()
    {
        string name = EventSystem.current.currentSelectedGameObject.name; // name ile yaptik ama script ile gelistirilebilir
        
        switch (name)
        {
            case "Next":

                if (LevelManager.currentLevel == 12)
                {
                    Debug.Log("Oyun bitti");
                    SaveSystem.SaveHighScore(ManageScenesSaves.UserName, int.Parse(text.text));
                    break;
                }
                LevelManager.currentLevel += 1; SaveSystem.SaveProgress(ManageScenesSaves.UserName, LevelManager.currentLevel, int.Parse(text.text));
                break;
            case "Replay":
                SaveSystem.SaveProgress(ManageScenesSaves.UserName, LevelManager.currentLevel, int.Parse(text.text));
                break;
            default:
                break;

        }
    }

}
