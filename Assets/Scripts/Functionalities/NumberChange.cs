using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberChange : MonoBehaviour
{
    private int  maxNumber =10;
    public int currentNumber;

    private Button currentButton;
    [SerializeField]private TextMeshProUGUI currentText;

    [SerializeField] NumberChange[] numbersToChange;

    private void Start() {

        currentText = GetComponentInChildren<TextMeshProUGUI>();

        currentButton = GetComponent<Button>();
        currentButton.onClick.AddListener(ChangeNumber);

        GetStartingNumber();
    }

    private void GetStartingNumber() {
        currentNumber = GetComponent<ObjectStartingNumber>().GetStartingNumber();
        SetText();
    }

    private void ChangeNumber() {

        if (numbersToChange.Length==0) {
            //cant change numbers
            return;
        }
        foreach (NumberChange numberChange in numbersToChange) {
            numberChange.AddNumber();
        }

        //event 
        LevelManager.Instance.ActionMade();
    }
    public void AddNumber() {
        currentNumber++;
        if (currentNumber>maxNumber-1) {
            currentNumber = 0;
        }

        SetText();
    }

    private void SetText() {
        currentText.text = currentNumber.ToString(); 
    }

    public int GetCurrentNumber() {
       return currentNumber;
    }
}
