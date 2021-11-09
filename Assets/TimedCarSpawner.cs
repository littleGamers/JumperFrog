using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedCarSpawner : MonoBehaviour
{
    [SerializeField] AutoPilot[] prefabsToSpawn;
    [Tooltip("Waiting time is chosen randomly from minWaitingTime to maxWaitingTime.")]
    [SerializeField] float minWaitingTime = 1f;
    [SerializeField] float maxWaitingTime = 3f;
    [Tooltip("Speed is chosen randomly from minSpeed to maxSpeed.")]
    [SerializeField] float minSpeed = 5f;
    [SerializeField] float maxSpeed = 10f;

    void Start()
    {
        StartCoroutine(carSpawnRoutine());
    }

    private IEnumerator carSpawnRoutine()
    {
        while (true)
        {
            // Choose a random car model from prefabs:
            int prefabIndex = 0;
            prefabIndex = Random.Range(prefabIndex, prefabsToSpawn.Length);

            // Choose a random direction (-1 or 1):
            float direction = 1;
            direction = (Random.Range(-direction, direction) > 0) ? direction : -direction;

            // Create a postion vector for the spawned car:
            Vector3 carPostion = new Vector3(-direction * transform.position.x,
                                                transform.position.y,
                                                transform.position.z);

            // Create a rotation vector for the spawned car:
            float rotationAngel = 180f; // to face right/left according to driving direction
            Quaternion rotationVector = (direction < 0) ?
                                        Quaternion.Euler(new Vector3(0, rotationAngel, 0)) :
                                        Quaternion.identity;

            // Spawn a car to the screen:
            GameObject newObject = Instantiate(prefabsToSpawn[prefabIndex].gameObject,
                                                carPostion,
                                                rotationVector);

            // Get the driving component of the spawned car:
            AutoPilot driver = newObject.GetComponent<AutoPilot>();

            // Set direction and random speed for the spawned car:
            driver.setDirection((int)direction);
            driver.setSpeed(Random.Range(minSpeed, maxSpeed));

            // Wait a random amount of time between tthe range before next spawn:
            float timeBeforeNextSpawn = Random.Range(minWaitingTime, maxWaitingTime);
            yield return new WaitForSeconds(timeBeforeNextSpawn);

        }

    }
}
