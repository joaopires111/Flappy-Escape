using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iam_InTheWay : MonoBehaviour
{

    //[SerializeField] private GameObject SolidBody;
    //[SerializeField] private GameObject transparentBody;

    [SerializeField] private Material Material1, Material2;
    private void Awake()
    {
        ShowSolid();
    }

    public void ShowTransparent()
    {

        //SolidBody.SetActive(false);
        //transparentBody.SetActive(true);

        this.gameObject.GetComponent<MeshRenderer>().material = Material2;
    }
    public void ShowSolid()
    {

        //SolidBody.SetActive(true);
        //transparentBody.SetActive(false);


        this.gameObject.GetComponent<MeshRenderer>().material = Material1;
    }
}
