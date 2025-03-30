using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class EnnemyManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform camTransform;
    public bool vague;
    public int nmbdevague;
    public int enemy;
    public int EnemyNumber = 10;
    public float SpawnRange = 3f;

    [SerializeField]private TMP_Text count;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        vague = false;
        nmbdevague =0;
        enemy = 0;
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < EnemyNumber + 2 * nmbdevague; i++)
        {
            float x = camTransform.position.x + Random.Range(-SpawnRange, SpawnRange);
            float y = camTransform.position.y + Random.Range(-SpawnRange, SpawnRange);
            float z = camTransform.position.z + Random.Range(-SpawnRange, SpawnRange);
            Vector3 spawnPos = new Vector3(x, y, z);
            Instantiate(EnemyPrefab, spawnPos, Quaternion.Euler(90f,0f,0f));
            enemy += 1;
        }
        count.text = "Nombre d'ennemis : " + enemy;
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
