using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStartingNumber : MonoBehaviour
{
    [SerializeField] int minNumber;
    [SerializeField] int maxNumber;


    int currentNumber;


    private void Awake() {
        SetRandomStartingNumber();
    }

    private void SetRandomStartingNumber() {
        currentNumber = Random.Range(minNumber,maxNumber);
    }

    public int GetStartingNumber() {
        return currentNumber;
    }
}
