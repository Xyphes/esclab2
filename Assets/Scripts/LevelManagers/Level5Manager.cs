using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Level5Manager : MonoBehaviour {


    private bool matching;

    [SerializeField] Image[] levelDucks;

    [SerializeField] Color whiteColor;

    [SerializeField] GameObject actionTriggerer;

    [SerializeField] LevelColors colors;
    [SerializeField] Color[] levelColors;

    private List<GameObject> whiteLevelImages = new List<GameObject>();
    private List<GameObject> greenLevelImages = new List<GameObject>();
    private void Start() {
        LevelManager.Instance.OnLevelAction += LevelAction;

        StartCoroutine("SetLevel");

    }

    IEnumerator SetLevel() {

        SetLevelColors();

        float timeToWait = 0f;

        yield return new WaitForSeconds(timeToWait);

        SetCorrectLevelDucks();
    }

    private void SetLevelColors() {
        for (int i=0;i<levelColors.Length;i++) {
            levelColors[i] = colors.levelColors[i];
        }
    }

    private void SetCorrectLevelDucks() {
        for (int i = 0; i < levelDucks.Length; i++) {
            if (i % 2 == 0) {
                SetRandomStartingDirection(levelDucks[i].gameObject);
            }
        }
    }

    private void SetRandomStartingDirection(GameObject duckObject) {
        int maxDirections = 2;
        int direction = UnityEngine.Random.Range(0, maxDirections);

        if (direction > 0) {
            Flip(duckObject);
        }

    }
    private void OnDisable() {
        LevelManager.Instance.OnLevelAction -= LevelAction;
    }

    private void LevelAction(object sender, EventArgs e) {

        SetLevelImagesColorLists();
        SetActionTriggerer();
        FlipColors();
        CheckForLevelEnd();
    }

    private void SetLevelImagesColorLists() {

        whiteLevelImages.Clear();
        greenLevelImages.Clear();

        for (int i = 0; i < levelDucks.Length; i++) {
            if (levelDucks[i].color == whiteColor) {
                whiteLevelImages.Add(levelDucks[i].gameObject);
            } else {
                greenLevelImages.Add(levelDucks[i].gameObject);
            }
        }
    }

    private void SetActionTriggerer() {
        actionTriggerer = LevelManager.Instance.actionTriggerer;
    }

    private void FlipColors() {
        if (actionTriggerer.GetComponent<Image>().color == whiteColor) {
            //flip all the white
            foreach (var images in whiteLevelImages) {
                Flip(images);
            }
        } else {
            //flip all the green
            foreach (var images in greenLevelImages) {
                Flip(images);
            }
        }
    }

    public void Flip(GameObject objectToFlip) {

        Vector3 rot = objectToFlip.transform.localScale;
        rot.x *= -1;
        objectToFlip.transform.localScale = rot;
    }

    private void CheckForLevelEnd() {
        matching = true;

        //check for rotation
        for (int i = 0; i < levelDucks.Length; i++) {
            Vector3 scale = levelDucks[i].transform.localScale;

            //check for i pair 
            if (i % 2 == 0) {
                //pair
                if (scale.x <= 0) {
                    matching = false;
                    break;
                }
            } else {
                // not pair
                if (scale.x >= 0) {
                    matching = false;
                    break;
                }
            }

        }

        if (matching) {
            CheckForMatchColor();
        }

        //check if all matched
        if (matching) {
            Debug.Log("Level success");
            LevelManager.Instance.OpenDoor();
        } else {
            Debug.Log("Level Loss");
        }
    }

    private void CheckForMatchColor() {

        for (int i = 0; i < levelDucks.Length; i++) {
            if (i % 2 == 0) {

                //should be green color
                if (levelDucks[i].color==whiteColor) {
                    matching = false;
                }

            }
        }
    } 

    public void ChangeDuckColor(int duckIndex) {

        Color currentDuckColor = levelDucks[duckIndex].color;
        int colorIndex;
        if (currentDuckColor== whiteColor) {
            colorIndex = 1;
        } else {
            colorIndex = 0;
        }

        levelDucks[duckIndex].color = levelColors[colorIndex];

        SetLevelImagesColorLists();
        CheckForLevelEnd();
    }

}
