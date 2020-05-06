using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    [SerializeField] private GameObject[] ScoresDisplayeds = null;

    static int SortByRatio(Score p1, Score p2)
    {
        string[] times1 = p1.Time.Split(':');
        float time1 = (int.Parse(times1[0]) * 60) + int.Parse(times1[1]);
        double ratio1 = (float)p1.Points / time1;

        string[] times2 = p2.Time.Split(':');
        float time2 = (int.Parse(times2[0]) * 60) + int.Parse(times2[1]);
        double ratio2 = (float)p2.Points / time2;

        return ratio2.CompareTo(ratio1);
    }

    public void SetScores(List<Score> scores)
    {
        scores.Sort(SortByRatio);

        for (int i = 0; i < scores.Count && i < ScoresDisplayeds.Length; i++)
        {
            TextMeshProUGUI[] texts = ScoresDisplayeds[i].GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = scores[i].Time;
            texts[1].text = scores[i].Points.ToString();
        }
    }
}
