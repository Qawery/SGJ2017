using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float spawnInterval = 10f;
    private float spawnCooldown = 0f;
    public GameObject smallMinion;
    public GameObject bigMinion;

    public void Update() {
        if(spawnCooldown > 0f) {
            spawnCooldown -= Time.deltaTime;
        }
        else {
            SpawnNextBatch();
        }
    }

    private void SpawnNextBatch() {
        Vector3 spawnPointOffset = new Vector3(-3.5f, 0, -3.5f);
        float number = Random.Range(-1, 3);
        while(number >= 0f) {
            GameObject newMinion = GameObject.Instantiate(smallMinion);
            newMinion.transform.position = transform.position + spawnPointOffset;
            float destinationRoll = Random.Range(0.0f, 2.0f);
            Vector3 destination;
            if(destinationRoll <= 1.0f) {
                destination = LocationsManager.instance.GetPositionOf(LocationsEnum.Catacombs);
            }
            else {
                destination = LocationsManager.instance.GetPositionOf(LocationsEnum.FrozenThrone);
            }
            destination += new Vector3(Random.Range(-2.0f, 2.0f), 0, Random.Range(-2.0f, 2.0f));
            newMinion.GetComponent<MinionAI>().SetDestination(destination);
            number -= 1.0f;
            spawnPointOffset += new Vector3(3.5f, 0, 0);
            if(spawnPointOffset.x > 7f) {
                spawnPointOffset = new Vector3(-3.5f, 0, spawnPointOffset.z + 3.5f);
            }
        }
        number = Random.Range(-1, 1);
        while(number >= 0f) {
            GameObject newMinion = GameObject.Instantiate(bigMinion);
            newMinion.transform.position = transform.position + spawnPointOffset;
            float destinationRoll = Random.Range(0.0f, 2.0f);
            Vector3 destination;
            if(destinationRoll <= 1.0f) {
                destination = LocationsManager.instance.GetPositionOf(LocationsEnum.Catacombs);
            }
            else {
                destination = LocationsManager.instance.GetPositionOf(LocationsEnum.FrozenThrone);
            }
            destination += new Vector3(Random.Range(-2.0f, 2.0f), 0, Random.Range(-2.0f, 2.0f));
            newMinion.GetComponent<MinionAI>().SetDestination(destination);
            number -= 1.0f;
            spawnPointOffset += new Vector3(3.5f, 0, 0);
            if(spawnPointOffset.x > 7f) {
                spawnPointOffset = new Vector3(-3.5f, 0, spawnPointOffset.z + 3.5f);
            }
        }
        spawnCooldown = spawnInterval;
    }
}
