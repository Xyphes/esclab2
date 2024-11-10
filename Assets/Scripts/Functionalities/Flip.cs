using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flip : MonoBehaviour
{

    [SerializeField] GameObject[] objectsToFlip; //objects that needed to be flipped

    private Button currentButton;
    private void Start() {
        currentButton = GetComponent<Button>();
        currentButton.onClick.AddListener(FlipObject);
    }

    public void FlipObject() {
     
        Vector3 rot = this.transform.localScale;
        rot.x *= -1;
        this.transform.localScale = rot;
    }
}
