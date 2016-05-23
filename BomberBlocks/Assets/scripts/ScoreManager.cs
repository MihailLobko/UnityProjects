using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public int scoreCount;
    public int hiScoreCount;

    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetInt("HightScore") != null)
        {
            hiScoreCount = PlayerPrefs.GetInt("HightScore");
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (scoreCount > hiScoreCount)
	    {
	        hiScoreCount = scoreCount;
            PlayerPrefs.SetInt("HightScore", hiScoreCount);
	    }
	}

    private void OnEnemyHit()
    {
        scoreCount += 1;
    }
}
