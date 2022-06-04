using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField] private bool lose, win;
    [SerializeField] private float time;
    private void Start()
    {
        StartCoroutine(CorStart());
        IEnumerator CorStart()
        {
            yield return new WaitForSeconds(time);
            if (lose)
            {
                SceneController.Instance.SceneMenu();
            }
            if (win)
            {
                PlayerPrefs.SetInt("Score", 30);
                SceneController.Instance.SceneMenu();
            }
        }
    }
}
