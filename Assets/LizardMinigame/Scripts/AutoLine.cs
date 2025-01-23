using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLine : MonoBehaviour
{
    private LineRenderer lRender;
    [Tooltip("added distance to rope")]
    public Vector3 addedPos;
    public Transform tip;

    private void Start()
    {
        lRender = GetComponent<LineRenderer>();
    }
    private void OnValidate()
    {
        lRender = GetComponent<LineRenderer>();
        lRender.SetPosition(0,transform.position);
        if(tip != null)
        {
            lRender.SetPosition(1,tip.position);
        } else
        {
            lRender.SetPosition(1,transform.position + addedPos);
        }
    }

    private void Update()
    {
        lRender.SetPosition(0, transform.position);
        if (tip != null)
        {
            lRender.SetPosition(1, tip.position);
        }
        else
        {
            lRender.SetPosition(1, transform.position + addedPos);
        }
    }

}
