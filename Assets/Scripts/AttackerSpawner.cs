using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackerPrefabArray;
    float minDelay = 7f;
    float maxDelay = 12f;
    [SerializeField] bool spawn = true;

    IEnumerator Start()
    {
        float difficulty = PlayerPrefsController.GetDifficulty();
        minDelay -= difficulty * 2;
        maxDelay -= difficulty * 2;

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

    public void StopSpawning()
    {
        spawn = false;
    }

    void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]); 
    }

    private void Spawn (Attacker attacker)
    {
        Instantiate(attacker, transform.position, Quaternion.identity, transform);
    }
}
