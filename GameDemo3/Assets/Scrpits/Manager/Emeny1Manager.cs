using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emeny1Manager : MonoBehaviour
{
    public static Emeny1Manager Instance = null;
    public GameObject[] Enemy1;
    int numberOfEnemy1s;

    int toggleTime;
    [SerializeField]
    GameObject Enemy1Prefab;

    void Awake()
    {
        numberOfEnemy1s = Enemy1.Length;

        if (numberOfEnemy1s - 1 == 0) { toggleTime = 1; } else { toggleTime = numberOfEnemy1s - 1; }


        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(gameObject); }


    }
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < numberOfEnemy1s; i++)
        {
            Instantiate(Enemy1Prefab, Enemy1[i].transform.position, Enemy1Prefab.transform.rotation);
            Enemy1[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy1(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(8f);
        Instantiate(Enemy1Prefab, spawnPosition, Enemy1Prefab.transform.rotation);
    }
}

