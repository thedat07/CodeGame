using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emeny4Manager : MonoBehaviour
{
    public static Emeny4Manager Instance = null;
    public GameObject[] Enemy4;
    int numberOfEnemy4s;

    int toggleTime;
    [SerializeField]
    GameObject Enemy4Prefab;

    void Awake()
    {
        numberOfEnemy4s = Enemy4.Length;

        if (numberOfEnemy4s - 1 == 0) { toggleTime = 1; } else { toggleTime = numberOfEnemy4s - 1; }


        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(gameObject); }


    }
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < numberOfEnemy4s; i++)
        {
            Instantiate(Enemy4Prefab, Enemy4[i].transform.position, Enemy4Prefab.transform.rotation);
            Enemy4[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy4(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(8f);
        Instantiate(Enemy4Prefab, spawnPosition, Enemy4Prefab.transform.rotation);
    }
}

