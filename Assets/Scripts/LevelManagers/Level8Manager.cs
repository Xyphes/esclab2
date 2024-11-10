
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level8Manager : MonoBehaviour { 

    [SerializeField] Image[] lamps;
    [SerializeField] Image[] referenceLamps;

    [SerializeField] LevelColors colors;
    [SerializeField] List<Color> levelColors = new List<Color>();

    [SerializeField] Color[] colorLamps;
    [SerializeField] Color[] colorReferenceLamps;
    private void Start() {

        LevelManager.Instance.OnLevelAction += LevelAction;

        StartCoroutine("SetLevel");
    }

    IEnumerator SetLevel() {

        SetLevelColors();
        float timeToWait = 1f;
        yield return new WaitForSeconds(timeToWait);

        SetReferenceLampsColorsList();
        SetLampsColorsList();
    }
    private void OnDisable()
    {
        LevelManager.Instance.OnLevelAction -= LevelAction;
    }
    private void SetLevelColors() {
        for (int i=0;i<colors.levelColors.Length;i++) {
            levelColors.Add(colors.levelColors[i]);
        }
    }

    private void SetReferenceLampsColorsList() {
        for (int i = 0; i < referenceLamps.Length; i++) {
            colorReferenceLamps[i] = referenceLamps[i].color;
        }
    }

    private void SetLampsColorsList() {

        for (int i=0;i<lamps.Length;i++) {
            colorLamps[i] = lamps[i].color;
        }


        LevelManager.Instance.ActionMade();

    }


    private void LevelAction(object sender, EventArgs e) {

        CheckForLevelEnd();
    }

    private void CheckForLevelEnd() {

        bool matching=true;

        for (int i=0;i<colorLamps.Length;i++) {
            if (colorLamps[i] != colorReferenceLamps[i]) {
                matching = false;
                break;
            }
        }



        if (matching) {
            Debug.Log("You win the level!");
            LevelManager.Instance.OpenDoor();
        } else {
            Debug.Log("You lost the level!");
        }

    }

    //functionalities

    public void Lamp(int lampIndex) {

        Color currentLampColor = colorLamps[lampIndex];

        int colorIndexChanged;

        if (currentLampColor == levelColors[0]) {
            //its white we need to make the nearest yellow to white
            colorIndexChanged = 0;
        } else {
            colorIndexChanged = 1;
        }

        int indexToStart = lampIndex + 1;

        //check for availability
        if (indexToStart>=colorLamps.Length) {
            indexToStart = 0;
        }

        for (int i=indexToStart;i<colorLamps.Length;i++) {
            //check for this index to the end of the list
            if (colorLamps[i]!=currentLampColor) {
                //need to change the color lamp in the current index
                lamps[i].color = levelColors[colorIndexChanged];
                SetLampsColorsList();
                return;
            }
        }
        for (int j=0;j<lampIndex;j++) {
            //check for this index to the end of the list
            if (colorLamps[j] != currentLampColor) {
                //need to change the color lamp in the current index
                lamps[j].color = levelColors[colorIndexChanged];
                SetLampsColorsList() ;
                return;
            }
        }

    }

    public void LampChangeColor(int lampIndex) {
        Color currentLampColor = colorLamps[lampIndex];

        int colorIndexChanged;

        if (currentLampColor == levelColors[0]) {
            //its white we need to make the nearest yellow to white
            colorIndexChanged = 1;
        } else {
            colorIndexChanged = 0;
        }

        lamps[lampIndex].color = levelColors[colorIndexChanged];
        SetLampsColorsList();

    }

}
