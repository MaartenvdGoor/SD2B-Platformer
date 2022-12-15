using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int Points;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScorePoints(int pointsValue)
    {
        Points += pointsValue;
        text.text = $"Current Points: {Points.ToString()}";
    }
}
