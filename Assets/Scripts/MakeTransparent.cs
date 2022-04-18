using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparent : MonoBehaviour
{

    [SerializeField] private List<Iam_InTheWay> CurrentlyInTheWay;
    [SerializeField] private List<Iam_InTheWay> AlreadyTransparent;
    [SerializeField] private Transform player;
    private Transform camera1;

    private void Awake()
    {
        CurrentlyInTheWay = new List<Iam_InTheWay>();
        AlreadyTransparent = new List<Iam_InTheWay>();
        camera1 = this.gameObject.transform;
    }


    // Update is called once per frame
    void Update()
    {
        GetAllObjectsInTheWay();
        MakeObjectsSolid();
        MakeObjectsTransparent();
    }

    private void GetAllObjectsInTheWay()
    {
        CurrentlyInTheWay.Clear();

        float cameraPlayerDistance = Vector3.Magnitude(camera1.position - player.position);

        Ray ray1_foward = new Ray(camera1.position, player.position - camera1.position);
        Ray ray1_backward = new Ray(camera1.position, camera1.position - player.position);

        var hits1_foward = Physics.RaycastAll(ray1_foward, cameraPlayerDistance);
        var hits1_backward = Physics.RaycastAll(ray1_backward, cameraPlayerDistance);

        foreach (var hit in hits1_foward)
        {
            if (hit.collider.gameObject.TryGetComponent(out Iam_InTheWay inTheWay))
            {
                if (!CurrentlyInTheWay.Contains(inTheWay))
                {
                    CurrentlyInTheWay.Add(inTheWay);
                }
            }
        }
        foreach (var hit in hits1_backward)
        {
            if (hit.collider.gameObject.TryGetComponent(out Iam_InTheWay inTheWay))
            {
                if (!CurrentlyInTheWay.Contains(inTheWay))
                {
                    CurrentlyInTheWay.Add(inTheWay);
                }
            }
        }


    }
    private void MakeObjectsTransparent()
    {
        for(int i = 0; i < CurrentlyInTheWay.Count; i++)
        {
            Iam_InTheWay inTheWay = CurrentlyInTheWay[i];

            if (!AlreadyTransparent.Contains(inTheWay))
            {
                inTheWay.ShowTransparent();
                AlreadyTransparent.Add(inTheWay);
            }
        }
    }
    private void MakeObjectsSolid()
    {
        for (int i = AlreadyTransparent.Count -1; i >= 0; i--)
        {
            Iam_InTheWay wasInTheWay = AlreadyTransparent[i];

            if (!CurrentlyInTheWay.Contains(wasInTheWay))
            {
                wasInTheWay.ShowSolid();
                AlreadyTransparent.Remove(wasInTheWay);
            }
        }
    }
}
