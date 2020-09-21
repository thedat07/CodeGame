using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emeny2Manager : MonoBehaviour
{
    public static Emeny2Manager Instance = null;
    public GameObject[] Enemy2L;
    public GameObject[] Enemy2R;
    int numberOfEnemy2Ls;
    int numberOfEnemy2Rs;

    int toggleTime;
    [SerializeField]
    GameObject Enemy2LPrefab;
    [SerializeField]
    GameObject Enemy2RPrefab;
    void Awake()
    {
        numberOfEnemy2Ls = Enemy2L.Length;

        if (numberOfEnemy2Ls - 1 == 0) { toggleTime = 1; } else { toggleTime = numberOfEnemy2Ls - 1; }

        numberOfEnemy2Rs = Enemy2R.Length;

        if (numberOfEnemy2Rs - 1 == 0) { toggleTime = 1; } else { toggleTime = numberOfEnemy2Rs - 1; }

        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(gameObject); }


    }
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < numberOfEnemy2Ls; i++)
        {
            Instantiate(Enemy2LPrefab, Enemy2L[i].transform.position, Enemy2LPrefab.transform.rotation);
            Enemy2L[i].SetActive(false);
        }
        for (int i = 0; i < numberOfEnemy2Rs; i++)
        {
            Instantiate(Enemy2RPrefab, Enemy2R[i].transform.position, Enemy2RPrefab.transform.rotation);
            Enemy2R[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy2L(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(8f);
        Instantiate(Enemy2LPrefab, spawnPosition, Enemy2LPrefab.transform.rotation);
    }
    IEnumerator SpawnEnemy2R(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(8f);
        Instantiate(Enemy2RPrefab, spawnPosition, Enemy2RPrefab.transform.rotation);
    }
}

