﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] GameObject attakerPrefab;
    [SerializeField] float minDelay = 1f;
    [SerializeField] float maxDelay = 6f;
    [SerializeField] bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return StartCoroutine(SpawnAttackerWithDelay(Random.Range(minDelay, maxDelay)));
        }
    }

    IEnumerator SpawnAttackerWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnAttacker();
    }

    void SpawnAttacker()
    {
        Instantiate(attakerPrefab, transform.position, Quaternion.identity);
    }
}