using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soucoupe : MonoBehaviour
{
    public float vitesse = 3f;
    private Vector3 ptB;
    private Vector3 target;
    private Vector3 stock;

    
    private void Start()
    {
        if (ptB == null) 
        {
            ptB = transform.position;
            Debug.Log (ptB);
        }
        if (target == null)
        {
            target = transform.position + Vector3.forward * 10f;
            Debug.Log(target);
        }
        stock = transform.position;
    }

    void Update()
    {
        if (ptB != null && target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, vitesse * Time.deltaTime);
            
            if (transform.position == target)
            {
                Debug.Log("okay");
                target = stock;
                ptB = transform.position;
            }
        }
    }
}
