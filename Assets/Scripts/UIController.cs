using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : SingletonBase<UIController>
{
    [SerializeField] private List<Ship> ships;
    [SerializeField] private List<Scrollbar> scrollbars;
    [SerializeField] private int score;
    [SerializeField] private Text scoreTxt;
    [SerializeField] private float maxDist;
    private void Start()
    {
        maxDist = (ships[0].Moon.position - 
            ships[0].transform.position).magnitude + 
            ships[0].PointFinish;
        scoreTxt.text = "0$";
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < ships.Count; i++)
        {
            float dist = ships[i].Distance/maxDist ;
            scrollbars[i].value = dist;
        }
    }
    public void AddScore(int cash)
    {
        score += cash;
        scoreTxt.text = $"{score}$";
        PlayerPrefs.SetInt("Score", score);
    }
}
