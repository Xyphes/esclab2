using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBG : MonoBehaviour
{
    [SerializeField] Material BGMaterial;

    private void Start() {
        SetBGColor();
    }

    private void SetBGColor() {
        Image BG = GetComponent<Image>();
        BG.color = BGMaterial.color;
    }
}
