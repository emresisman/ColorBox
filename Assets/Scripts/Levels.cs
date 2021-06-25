using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level", order = 1)]
public class Levels : ScriptableObject
{
    public int levelID;
    public int colorCount;
    public Color[] color;
    public int[] totalColorCount;
    public int[] requiredColorCount;
    public bool unlocked;
}