using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action : MonoBehaviour
{
    private Button currentButton;

    public int actionTrigerrerIndex;
    private void Start() {
        currentButton = GetComponent<Button>();
        currentButton.onClick.AddListener(TriggerAction);
    }

    private void TriggerAction() {
        //event 
        LevelManager.Instance.actionTriggererIndex = actionTrigerrerIndex;
        LevelManager.Instance.actionTriggerer = this.gameObject;
        LevelManager.Instance.ActionMade();
    }

}
