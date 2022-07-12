using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Button buttonBuy;
    [SerializeField] private DetailsController detailsController;
    [SerializeField] private int generalScore;
    [SerializeField] private int countDetails;
    private Vector3 posNewDetail;
    [SerializeField] private Text generalCash;

    void Start()
    {
        posNewDetail = detailsController.transform.position;

        generalScore = PlayerPrefs.GetInt("GeneralScore");
        generalScore += PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("Score", 0);
        generalCash.text = $"{generalScore}$";
        countDetails = PlayerPrefs.GetInt("CountDetails");
        PlayerPrefs.SetInt("GeneralScore", generalScore);

        if (generalScore < 15)
        {
            buttonBuy.interactable = false;
        }
        else
        {
            buttonBuy.interactable = true;
        }
    }

    public void BuyDetail(int cash)
    {
        if (PlayerPrefs.HasKey("x"))
        {
            posNewDetail = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
        }

        generalScore -= cash;
        PlayerPrefs.SetInt("GeneralScore",generalScore);
        countDetails += 1;
        PlayerPrefs.SetInt("CountDetails", countDetails);
            detailsController.SpawnDetail(posNewDetail);
        foreach (var item in detailsController.Details)
        {
            item.SetTimeLives(1000f);
        }
       
        posNewDetail = new Vector3(posNewDetail.x, posNewDetail.y, posNewDetail.z - detailsController.PartGap);
        PlayerPrefs.SetFloat("x", posNewDetail.x);
        PlayerPrefs.SetFloat("y", posNewDetail.y);
        PlayerPrefs.SetFloat("z", posNewDetail.z);
        if (generalScore < cash)
        {
            buttonBuy.interactable = false;
        }
        else
        {
            buttonBuy.interactable = true;
        }
        generalCash.text = $"{generalScore}$";
    }
}
