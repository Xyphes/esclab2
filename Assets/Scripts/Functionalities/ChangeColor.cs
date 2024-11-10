using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public int colorIndex;

    Image currentImage;
    Color currentColor;

    [SerializeField] Image[] colorsToChange;
    [SerializeField] LevelColors colors;
    [SerializeField] List<Color> levelColors = new List<Color>();


    private Button currentButton;


    private void Start() {

        SetLevelColors();

        currentButton = GetComponent<Button>();
        currentImage = GetComponent<Image>();
        currentButton.onClick.AddListener(ColorChangeForAll);

        StartCoroutine("SetColorIndex");
    }

    private void SetLevelColors() {
        for (int i=0;i< colors.levelColors.Length;i++) {
            levelColors.Add(colors.levelColors[i]);
        }
    }

    IEnumerator SetColorIndex() {
        float timeToWait = 0.5f;
        yield return new WaitForSeconds(timeToWait);

        colorIndex= GetComponent<ObjectStartingColor>().GetStartingColorIndex();
        currentColor = GetComponent<ObjectStartingColor>().GetStartingColor();
    }


    private void ColorChangeForAll() {
        //changing the color

        for (int i=0;i<colorsToChange.Length;i++) {
            if (colorsToChange[i] != null && colorsToChange[i].TryGetComponent<ChangeColor>(out ChangeColor changeColorComponent)) {
                changeColorComponent.ChangeCurrentColor();
            }
        }

        //event 
        LevelManager.Instance.ActionMade();

    }

    public void ChangeCurrentColor() {

        colorIndex++;
        if (colorIndex >= levelColors.Count) {
            colorIndex = 0;
        }

        currentColor = levelColors[colorIndex];
        currentImage.color = currentColor;

    }

    public Color GetCurrentColor() {
        return currentColor;    
    }

    public void SetColorIndex(int index) {
        colorIndex = index;

        currentColor = levelColors[colorIndex];
        currentImage.color = currentColor;
    }
}
