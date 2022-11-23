using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreText : MonoBehaviour
{
    Text text;
    public static int pointAmount;

    void Start()
    {
        text = GetComponent<Text>();
    }


    void Update()
    {
        text.text = pointAmount.ToString();
    }
}
