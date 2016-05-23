using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

    [SerializeField]
    private Text scoreLable;
    [SerializeField]
    private Text hiScoreLable;

    public ScoreManager scoreManager;

    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    // Use this for initialization
    void Start()
    {
        scoreLable.text = "Score: " + scoreManager.scoreCount;
        hiScoreLable.text = "Best Score: " + scoreManager.hiScoreCount;
    }

    private void OnEnemyHit()
    {
        scoreLable.text = "Score: " + scoreManager.scoreCount;
    }

}
