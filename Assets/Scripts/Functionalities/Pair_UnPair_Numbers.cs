using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pair_UnPair_Numbers : MonoBehaviour
{
    int maxNumber = 9;
    int currentNumber;
    bool pair;

    [SerializeField] Button currentButton;
    [SerializeField] TextMeshProUGUI currentText;

    private void Start() {


        currentButton = GetComponent<Button>();
        currentButton.onClick.AddListener(AddPairUnPairNumber);


        GetStartingNumber();

        currentText = GetComponentInChildren<TextMeshProUGUI>();
        currentText.text = currentNumber.ToString();


        CheckStartingNumberIsPair();

    }

    private void GetStartingNumber() {
        currentNumber = GetComponent<ObjectStartingNumber>().GetStartingNumber();
    }

    private void AddPairUnPairNumber() {
        currentNumber += 2;
        if (currentNumber>maxNumber) {
            if (pair) {
                pair = false;
                currentNumber = 1;
            } else {
                pair = true;
                currentNumber = 0;
            }
        }

        SetText();

        //event 
        LevelManager.Instance.ActionMade();
    }

    private void SetText() {
        //display text
        currentText.text = currentNumber.ToString();
    }

    private void CheckStartingNumberIsPair() {
        if (currentNumber%2==0) {
            //pair number
            pair = true;
        } else {
            pair = false;
        }
    }

    public int GetCurrentNumber() {
        return currentNumber;
    }

}
