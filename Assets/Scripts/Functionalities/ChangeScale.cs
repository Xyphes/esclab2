using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    [SerializeField] int currentScale;

    [SerializeField] bool randomScale;
    [SerializeField] int maxNumberOfScales;

    [SerializeField] float[] XScale;
    [SerializeField] float[] YScale;

    private void Start() {
        SetStartingScale();
    }

    private void SetStartingScale() {

       
        if (!randomScale) {
          SetScale(0);
        } else {
            currentScale = Random.Range(0, maxNumberOfScales);
            SetScale(currentScale);
        }
       
    }

    public void SetScale(int index) {
        Vector3 temp = this.transform.localScale;
        temp.x = XScale[index];
        temp.y = YScale[index];
        currentScale = index;
        this.transform.localScale = temp;
    }

    public int GetScaleIndex () {
        return currentScale;
    }

}
