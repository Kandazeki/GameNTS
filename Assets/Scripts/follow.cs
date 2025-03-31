using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Situation
{
    Situation1,
    Situation2,
    Situation3
}
public class follow : MonoBehaviour
{

    public Transform target; 
    float timer = 0f;
    bool b = false;
    
    Situation Situtu;
    System.Random random = new System.Random();
    private void Start()
    {
        int a = random.Next(3);
        switch (a)
        {
            case 0: Situtu = Situation.Situation1;
                break;
            case 1: Situtu = Situation.Situation2;
                break;
            case 2: Situtu = Situation.Situation3;
                break;
        }
    }
    void Mouvement1()
    {
        timer += Time.deltaTime;
        if (timer > 2f && timer < 5f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        if (timer > 5f && timer < 8f)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (timer > 8f && timer < 11f)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
        if (timer > 11f && timer < 14f)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        if (timer > 14f && timer < 17f)
        {
            if (b)
            {
                transform.Translate(Vector3.down * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.up * Time.deltaTime);
            }
        }
        if (timer > 17f)
        {
            timer = 0f;
            b = !b;
        }
    }
    void Mouvement2()
    {
        timer += Time.deltaTime;
        if (timer > 2f && timer < 5f)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        if (timer > 5f && timer < 8f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        if (timer > 8f && timer < 11f)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (timer > 11f && timer < 14f)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
        if (timer > 14f && timer < 17f)
        {
            if (b)
            {
                transform.Translate(Vector3.up * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.down * Time.deltaTime);
            }
        }
        if (timer > 17f)
        {
            timer = 0f;
            b = !b;
        }
    }
    void Mouvement3()
    {
        timer += Time.deltaTime;
        if (timer > 2f && timer < 5f)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (timer > 5f && timer < 8f)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
        if (timer > 8f && timer < 11f)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        if (timer > 11f && timer < 14f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        if (timer > 14f && timer < 17f)
        {
            if (b)
            {
                transform.Translate(Vector3.down * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.up * Time.deltaTime);
            }
        }
        if (timer > 17f)
        {
            timer = 0f;
            b = !b;
        }
    }

    void Update()
    {
        if (target != null)
        {
            switch (Situtu)
            {
                case Situation.Situation1:
                    Mouvement1();
                    break;
                case Situation.Situation2:
                    Mouvement2();
                    break;
                case Situation.Situation3:
                    Mouvement3();
                    break;
            }
        }
        /*
        if (target != null)
        {
            transform.position = target.position;
        }
        */
    }
}
