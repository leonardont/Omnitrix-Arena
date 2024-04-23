using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealth : MonoBehaviour
{
    public Image MeterGreen;
    public float PlayerHealth;

    [System.NonSerialized]
    public GameObject player;

    IEnumerator UpdateHealth() {
        yield return new WaitForSeconds(2f);
        if (player)
        {
            PlayerHealth = Mathf.Clamp(player.GetComponent<PlayerController>().health, 0, 20);
            MeterGreen.fillAmount = PlayerHealth / 20f;
        }
    }

    void Start()
    {
        Invoke("LocatePlayer", 1f);
    }

    void LocatePlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        StartCoroutine("UpdateHealth");
    }
}
