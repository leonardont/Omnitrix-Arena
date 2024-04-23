using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyHealth : MonoBehaviour
{
    public Image MeterGreen;
    public float EnemyHealth;

    [System.NonSerialized]
    public GameObject enemy;

    IEnumerator UpdateHealth() {
        yield return new WaitForSeconds(1.2f);
        EnemyHealth = Mathf.Clamp(enemy.GetComponent<EnemyController>().health, 0, 20f);
        MeterGreen.fillAmount = EnemyHealth / 20f;
    }

    void Start()
    {
        Invoke("LocateEnemy", 1f);
    }

    void LocateEnemy()
    {
        enemy = this.transform.parent.gameObject;
    }

    void Update()
    {
        StartCoroutine("UpdateHealth");
    }
}
