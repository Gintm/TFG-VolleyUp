using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DefaultNamespace;

public class ProgressBar : MonoBehaviour
{
    private Slider progressBar;
    void Start()
    {
        progressBar = GetComponent<Slider>();
        progressBar.value = 0f;
    }

    public void UpdateProgressBar(Fraction ratio)
    {
        progressBar.value = ratio.Quotient;
    }
}
