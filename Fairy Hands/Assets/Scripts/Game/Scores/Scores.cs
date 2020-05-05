using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    [SerializeField] private GameObject[] ScoresDisplayeds = null;

//    myList.Sort(
//    delegate (KeyValuePair<string, string> pair1,
//    KeyValuePair<string, string> pair2)
//    {
//        return pair1.Value.CompareTo(pair2.Value);
//    }
//);

    public void SetScores(Dictionary<string, int> scores)
    {
        List<KeyValuePair<string, int>> myList = scores.ToList();
        myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

        for (int i = 0; i < myList.Count && i < ScoresDisplayeds.Length; i++)
        {
            TextMeshPro[] texts = ScoresDisplayeds[i].GetComponentsInChildren<TextMeshPro>();
            texts[0].text = myList[i].Key;
            texts[1].text = myList[i].Value.ToString();
        }
    }
}
