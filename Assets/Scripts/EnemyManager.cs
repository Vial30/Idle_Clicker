using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Sprite[] backgrounds;
    public Transform canvas;
    public Image background;

    public static EnemyManager instance;

    public int enemyLeft = 2;

    public int currentEnemy;
    public int currentBg;

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
        ChechBackground();
    }

    void ChechBackground(){
        enemyLeft--;
        if (enemyLeft == 0){
            enemyLeft = 2;
            currentBg = (currentBg + 1) % backgrounds.Length;
            //Varian 2
            // currentBg++;
            // if (currentBg >= backgrounds.Length) currentBg = 0;

            background.sprite = backgrounds[currentBg];
        }
    }
}
