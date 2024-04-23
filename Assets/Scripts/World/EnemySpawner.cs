using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyVariant1;
    [SerializeField]
    private GameObject enemyVariant2;
    [SerializeField]
    private GameObject enemyVariant3;
    [SerializeField]
    private GameObject enemyVariant4;
    [SerializeField]
    private GameObject enemyVariant5;
    [SerializeField]
    private GameObject enemyVariant6;
    [SerializeField]
    private GameObject enemyVariant7;
    [SerializeField]
    private GameObject enemyVariant8;
    [SerializeField]
    private GameObject enemyVariant9;
    [SerializeField]
    private GameObject enemyVariant10;

    private int randomEnemy;

    [SerializeField]
    private float interval = 15f;

    void Start()
    {
        randomEnemy = Random.Range(1, 11);

        switch (randomEnemy)
        {
            case 1:
                GameObject newEnemy1 = Instantiate(enemyVariant1, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;
            
            case 2:
                GameObject newEnemy2 = Instantiate(enemyVariant2, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 3:
                GameObject newEnemy3 = Instantiate(enemyVariant3, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 4:
                GameObject newEnemy4 = Instantiate(enemyVariant4, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 5:
                GameObject newEnemy5 = Instantiate(enemyVariant5, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 6:
                GameObject newEnemy6 = Instantiate(enemyVariant6, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 7:
                GameObject newEnemy7 = Instantiate(enemyVariant7, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 8:
                GameObject newEnemy8 = Instantiate(enemyVariant8, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 9:
                GameObject newEnemy9 = Instantiate(enemyVariant9, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 10:
                GameObject newEnemy10 = Instantiate(enemyVariant10, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            default:
                break;
        }
        
        StartCoroutine(spawnEnemy(interval, enemyVariant1, enemyVariant2, enemyVariant3, enemyVariant4, enemyVariant5, enemyVariant6, enemyVariant7, enemyVariant8, enemyVariant9, enemyVariant10));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemyVariant1, GameObject enemyVariant2, GameObject enemyVariant3, GameObject enemyVariant4, GameObject enemyVariant5, GameObject enemyVariant6, GameObject enemyVariant7, GameObject enemyVariant8, GameObject enemyVariant9, GameObject enemyVariant10)
    {
        yield return new WaitForSeconds(interval);
        
        randomEnemy = Random.Range(1, 11);

        switch (randomEnemy)
        {
            case 1:
                GameObject newEnemy1 = Instantiate(enemyVariant1, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;
            
            case 2:
                GameObject newEnemy2 = Instantiate(enemyVariant2, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 3:
                GameObject newEnemy3 = Instantiate(enemyVariant3, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 4:
                GameObject newEnemy4 = Instantiate(enemyVariant4, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 5:
                GameObject newEnemy5 = Instantiate(enemyVariant5, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 6:
                GameObject newEnemy6 = Instantiate(enemyVariant6, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 7:
                GameObject newEnemy7 = Instantiate(enemyVariant7, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 8:
                GameObject newEnemy8 = Instantiate(enemyVariant8, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 9:
                GameObject newEnemy9 = Instantiate(enemyVariant9, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            case 10:
                GameObject newEnemy10 = Instantiate(enemyVariant10, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                break;

            default:
                break;
        }

        StartCoroutine(spawnEnemy(interval, enemyVariant1, enemyVariant2, enemyVariant3, enemyVariant4, enemyVariant5, enemyVariant6, enemyVariant7, enemyVariant8, enemyVariant9, enemyVariant10));
    }
}
