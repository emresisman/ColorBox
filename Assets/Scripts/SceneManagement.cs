using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManagement
{
    public static int currentLevel;
    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public static void LoadScene(string name, int level)
    {
        currentLevel=level;
        SceneManager.LoadScene(name);
    }
}
