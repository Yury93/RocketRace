using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detail : MonoBehaviour
{
    [SerializeField] private GameObject childObj;
    [SerializeField] private float speedForward,speedOffset;

    private float speedRotate;
    private DetailsController controller;
    public bool Active { get; private set; }
    private Animator anim;
    private InputController inputController;
    private void Start()
    {
        Active = true;
        controller = GetComponentInParent<DetailsController>();
        controller.OnBranchDetails += OnBranch;
        speedRotate = UnityEngine.Random.Range(-20f, 20f);
        anim = GetComponent<Animator>();
        inputController = GetComponentInParent<InputController>();
        if(inputController)
        {
            inputController.SetSpeed(speedForward, speedOffset);
        }
    }

    private void Update()
    {
        childObj. transform.Rotate(0, speedRotate * Time.deltaTime, 0);
    }

    private void OnBranch()
    {
        if(!Active)
        {
            if (gameObject)
            {
                if (inputController)
                {
                    inputController.SetSpeed(-speedForward, -speedOffset);
                }
                anim.enabled = true;
                gameObject.transform.parent = null;
                Destroy(gameObject, 2F);
            }
        }
    }
    public void DisActivated(bool isActive)
    {
        Active = isActive;
    }
    
    private void OnDestroy()
    {
        controller.OnBranchDetails -= OnBranch;
    }
}
