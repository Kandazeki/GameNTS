using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{

    public Transform target; // Le GameObject à suivre

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position;
        }
    }
}
