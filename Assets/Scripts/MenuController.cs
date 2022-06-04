using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject generalMenu;
    [SerializeField] private GameObject shop;

    private void Start()
    {
        shop.SetActive(false);
        generalMenu.SetActive(true);
    }
    public void StartButton()
    {
        generalMenu.SetActive(false);
        shop.SetActive(true);
    }
    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
