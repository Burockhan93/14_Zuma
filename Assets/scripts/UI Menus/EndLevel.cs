using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EndLevel : MonoBehaviour
{
    public Button[] buttons;


    public void OnClickButton()
    {
        string name = EventSystem.current.currentSelectedGameObject.name; // name ile yaptik ama script ile gelistirilebilir
        
        switch (name)
        {
            case "Next": LevelManager.currentLevel += 1; SaveSystem.SaveProgress(LevelManager.currentLevel);
                break;
            case "Replay":
                SaveSystem.SaveProgress(LevelManager.currentLevel);
                break;
            default:
                break;

        }
    }

}
