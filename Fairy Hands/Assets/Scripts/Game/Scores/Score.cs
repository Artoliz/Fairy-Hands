[System.Serializable]
public class Score
{
    public string Time;
    public int Points;
}

[System.Serializable]
public class ScoreList
{
    public System.Collections.Generic.List<Score> Scores;
}
