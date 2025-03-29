using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab1;
    public GameObject targetPrefab2;
    public List<Vector3> targetPositions;
    public List<GameObject> spawnedTargets = new();
    void Start()
    {
        targetPositions = new(){
            new Vector3(3f, 1.5f, 5.5f),
            new Vector3(0, 1.5f, 5.5f),
            new Vector3(-3f, 1.5f, 5.5f),

            new Vector3(3f, 1.5f, 7.5f),
            new Vector3(0, 1.5f, 7.5f),
            new Vector3(-3f, 1.5f, 7.5f)
        };

        StartCoroutine(spawnTarget());
    }


    IEnumerator spawnTarget()
    {
        while (true)
        {
            spawnedTargets.RemoveAll(e => e == null);
            var spawnPosition = targetPositions[Random.Range(0, targetPositions.Count)];
            bool isSpawned = spawnedTargets.Exists(spawnedTarget => spawnPosition == spawnedTarget.transform.position);
            if (!isSpawned)
            {
                var targetPrefab = Random.Range(0, 2) == 0 ? targetPrefab2 : targetPrefab1;
                var target = Instantiate(targetPrefab, spawnPosition, Quaternion.Euler(0, 90, 0));
                target.transform.SetParent(transform);
                spawnedTargets.Add(target);
                if (targetPrefab == targetPrefab1) Destroy(target, 1); else Destroy(target, 0.5f);
            }

            yield return new WaitForSeconds(0.5f);
        }

    }
}
