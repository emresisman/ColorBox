using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public void LoadLevel(Levels levelSO)
    {
        SceneManagement.LoadScene("Game",levelSO.levelID);
    }

    void Awake()
    {
        GameObject[] levelButtons = GameObject.FindGameObjectsWithTag("LevelButton");
        for(int i=0; i<levelButtons.Length;i++)
        {
            levelButtons[i].GetComponent<Button>().interactable=true;
        }
    }
}
