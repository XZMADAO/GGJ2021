using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUIRelevant : MonoBehaviour
{
    public Text textScore;
    public int score;
    private float timeCount;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCount > 1)
        {
            score += 1;
            timeCount = 0;
        }
        else
            timeCount += Time.deltaTime;
        textScore.text = score.ToString();
    }
}
