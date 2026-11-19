using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [Header("Setting")]
    public GameObject obstaclePrefab;
    public GameObject collectiblePrefab;
    public Transform player;
    public float horizonDistance = 50f;
    public float maxBoundary = 2f;
    public float floatingHeight = 2.4f;
    private Vector3 spawnPosition;
    [Header("Obstacle Setting")]
    public float distanceBetweenObstacles = 20f;
    [Header("Collectible Setting")]
    public float distanceBetweenCollectible = 5f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance from the player to the spawn position
        float distanceToSpawn = Vector3.Distance(player.position, spawnPosition);

        // Check if the spawn position is within the horizon distance and if it's time to spawn a new obstacle
        if (distanceToSpawn < horizonDistance)
        {
            float obstacleLane = Random.Range(-maxBoundary, maxBoundary); // Calculate the boundary for obstacle
            spawnPosition = new Vector3(obstacleLane, floatingHeight, spawnPosition.z + distanceBetweenObstacles); // Calculate spawn position obstacle
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            float collectibleLane = Random.Range(-maxBoundary, maxBoundary);
            // Check if collectible is on the same posistion of obstacle
            while (Mathf.Abs(collectibleLane - obstacleLane) < 2f)
            {
                collectibleLane = Random.Range(-maxBoundary, maxBoundary);
            }

            float collectibleZ = spawnPosition.z + Random.Range(distanceBetweenCollectible * 0.2f, distanceBetweenCollectible * 0.8f);
            float collectibleY = spawnPosition.y + Random.Range(floatingHeight * 0.1f, floatingHeight * 1.5f);

            Vector3 collectiblePos = new Vector3(collectibleLane, collectibleY, collectibleZ);
            Instantiate(collectiblePrefab, collectiblePos, Quaternion.identity);
        }
    }
}
