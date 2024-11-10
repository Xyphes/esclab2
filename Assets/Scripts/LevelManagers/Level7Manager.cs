using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7Manager : MonoBehaviour
{

    bool matching;

    [SerializeField] GameObject[] stickmansReference; 
    [SerializeField] GameObject[] stickmans;

    [SerializeField] LevelColors colors;
    [SerializeField] List<Color> levelColors = new List<Color>();
    
    [SerializeField] Color[] stickmanColors;
    [SerializeField] Color[] stickmanReferenceColors;

    private void Start() {

        LevelManager.Instance.OnLevelAction += LevelAction;

        StartCoroutine("SetLevel");
    }
    private void OnDisable()
    {
        LevelManager.Instance.OnLevelAction -= LevelAction;
    }
    IEnumerator SetLevel() {


        SetLevelColors();
        float timeToWait = 1f;
        yield return new WaitForSeconds(timeToWait);

        SetStickmanReferenceColors();
        SetStickmansColorsList();
    }

    private void SetLevelColors() {
        for (int i=0;i<colors.levelColors.Length;i++) {
            levelColors.Add(colors.levelColors[i]);
        }
    }

    private void LevelAction(object sender, EventArgs e) {

        SetStickmansColorsList();
        CheckForLevelEnd();
    }

    private void SetStickmanReferenceColors() {
        for (int i=0;i<stickmanReferenceColors.Length;i++) {
            stickmanReferenceColors[i] = stickmansReference[i].GetComponent<ObjectStartingColor>().GetStartingColor();
        }
    }

    private void SetStickmansColorsList() {
        for (int i=0;i<stickmans.Length;i++) {
            stickmanColors[i] = stickmans[i].GetComponent<ChangeColor>().GetCurrentColor();
        }
    }

    public void ShiftAllStickmanColors() {
        Color lastColor = stickmanColors[stickmanColors.Length-1];
        //shifting the colors
        for (int i= stickmanColors.Length-1;i>=1;i--) {
            stickmanColors[i] = stickmanColors[i-1];
        }
        //all shiftet unless the first one that need to be equal to the last color
        stickmanColors[0] = lastColor;

        
        //the list is shiftet need to apply to the stickmans
        for (int i=0;i<stickmanColors.Length;i++) {
            int currentStickmanColorIndex = GetStickmanColorIndex(stickmanColors[i]);
            stickmans[i].GetComponent<ChangeColor>().SetColorIndex(currentStickmanColorIndex);
        }

        //check for level end
        CheckForLevelEnd();
        
    }

    private int GetStickmanColorIndex(Color currentColor) {
        int colorIndex;
        for (int i=0;i<levelColors.Count;i++) {
            if (currentColor == levelColors[i]) {
                colorIndex = i;
                return colorIndex;
            }
        }
        return -1;
    }

    private void CheckForLevelEnd() {
        matching = true;
        for (int i=0;i<stickmanColors.Length;i++) {
            if (stickmanColors[i] != stickmanReferenceColors[i]) {
                matching = false;
                break;
            }
        }


        //check for win
        if (matching) {
            Debug.Log("You win!");
            LevelManager.Instance.OpenDoor();
        } else {
            Debug.Log("You lost!");
        }

    }
}
