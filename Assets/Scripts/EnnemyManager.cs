using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

public class EnnemyManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform camTransform;
    public GameObject Cone;
    public bool vague;
    public int nmbdevague;
    public int EnemyNumber = 10;
    public float SpawnRange = 3f;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        vague = false;
        nmbdevague =0;
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < EnemyNumber + 2 * nmbdevague; i++)
        {
            float x = camTransform.position.x + Random.Range(-SpawnRange, SpawnRange);
            float y = camTransform.position.y + Random.Range(-SpawnRange, SpawnRange);
            float z = camTransform.position.z + Random.Range(-SpawnRange, SpawnRange);
            Vector3 spawnPos = new Vector3(x, y, z);
            Instantiate(EnemyPrefab, spawnPos, Quaternion.identity);
        }
    }

    void Direction(GameObject ennemy)
    {
        Vector3 newposition = new Vector3();
        ennemy.transform.position = newposition;
    }


    // Update is called once per frame
    void Update()
    {
        if (vague)
        {
            SpawnEnemy();
            vague = false;
            nmbdevague += 1;
        }
        
    }
}
