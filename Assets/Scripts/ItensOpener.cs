using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensOpener : MonoBehaviour
{

    public GameObject Panel;
    public void Start()
    {
        // Mete painel do iventario a falso quando começa
        Panel.SetActive(false);
    }

    public void OpenClose()
    {
        if(Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
}
