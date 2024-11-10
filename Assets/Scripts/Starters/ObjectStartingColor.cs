using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectStartingColor : MonoBehaviour
{
    int startingColorIndex;
    [SerializeField] LevelColors colors;
    [SerializeField] Image currentImage;

    private void Start() {
        SetStartingColor();
    }

    private void SetStartingColor() {

         startingColorIndex = Random.Range(0, colors.levelColors.Length);
        currentImage.color = colors.levelColors[startingColorIndex];
    }

    public int GetStartingColorIndex() {
        return startingColorIndex;
    } 
    public Color GetStartingColor() {
        return colors.levelColors[startingColorIndex];
    }
}
