using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelColors", menuName = "ScriptableObjects/LevelColors")]
public class LevelColors : ScriptableObject
{
    public Color[] levelColors;
}
