using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField][Range(0.1f, 120f)] float spawnInterval = 2f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] AudioClip spawnSFX;
    int score;

    void Start()
    {
        scoreText.text = score.ToString();
        StartCoroutine(SpawnEnemies());
    }

    void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            AddScore(); GetComponent<AudioSource>().PlayOneShot(spawnSFX);
            Enemy enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = transform;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
