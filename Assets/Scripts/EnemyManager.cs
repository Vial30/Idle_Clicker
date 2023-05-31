using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform canvas;

    public static EnemyManager instance;

    public int currentEnemy;

    public void Awake(){
        instance = this;
    }

    public void SpawnEnemy(){
        int _randomEnemy = currentEnemy;

        while (_randomEnemy == currentEnemy){
            _randomEnemy = Random.Range(0, enemyPrefabs.Length);
        }
        currentEnemy = _randomEnemy;

        GameObject enemy = Instantiate(enemyPrefabs[currentEnemy], canvas);
    }

    public void DestroyEnemy(GameObject enemy){
        Destroy(enemy);
        SpawnEnemy();
    }
}
