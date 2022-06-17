using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : SingletonBase<SceneController>
{
    [SerializeField] private string sceneWin, sceneLose, gameLevel, menu;
    [SerializeField] private float timeSceneMenu, timeSceneLose;

    public void GameLevel()
    {
        SceneManager.LoadScene(gameLevel);
    }
    public void SceneWin()
    { SceneManager.LoadScene(sceneWin); }
    public void SceneLose()
    {
        StartCoroutine(CorLose());
        IEnumerator CorLose()
        {
            yield return new WaitForSeconds(timeSceneLose);
            SceneManager.LoadScene(sceneLose);
        }
    }
    public void SceneMenu()
    {
        StartCoroutine(CorMenu());
        IEnumerator CorMenu()
        {
            yield return new WaitForSeconds(timeSceneMenu);
            SceneManager.LoadScene(menu);
        }
    }
    public void SceneMenuButton()
    {
            SceneManager.LoadScene(menu);
        
    }
}
