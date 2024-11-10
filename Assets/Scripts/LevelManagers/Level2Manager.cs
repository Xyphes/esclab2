using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    bool matching;

    int minNumber = 100;
    int maxNumber = 1000;
    int levelReferenceNumber;

    [SerializeField]
    int[] correctNumbers;
    [SerializeField] TextMeshProUGUI levelReferenceText;
    [SerializeField] Pair_UnPair_Numbers[] levelNumbers;

    private void Start() {
        LevelManager.Instance.OnLevelAction += LevelAction;

        levelReferenceNumber = UnityEngine.Random.Range(minNumber, maxNumber);
        levelReferenceText.text = levelReferenceNumber.ToString();

        StartCoroutine("SetLevel");
    }

    IEnumerator SetLevel() {

        float timeToWait = 1f;

        yield return new WaitForSeconds(timeToWait);
        SetRandomReferenceNumber();
    }
    private void OnDisable() {
        LevelManager.Instance.OnLevelAction -= LevelAction;
    }

    private void LevelAction(object sender, EventArgs e) {

        CheckForLevelEnd();

    }

    private void CheckForLevelEnd() {
        matching = true;
        for (int i = 0; i < levelNumbers.Length; i++) {
            if (correctNumbers[i] != levelNumbers[i].GetCurrentNumber()) {
                //not same number
                matching = false;
                break;
            }
        }

        //check if all matched
        if (matching) {
            Debug.Log("Level success");
            LevelManager.Instance.OpenDoor();
        } else {
            Debug.Log("Level Loss");
        }
    }


    //random references 

    private void SetRandomReferenceNumber() {
        //setting the level reference number 
        string numberString = levelReferenceNumber.ToString();

        char digit1 = numberString[0];
        char digit2 = numberString[1];
        char digit3 = numberString[2];


        correctNumbers[0] = int.Parse(digit1.ToString());
        correctNumbers[1] = int.Parse(digit2.ToString());
        correctNumbers[2] = int.Parse(digit3.ToString());

    }

}
