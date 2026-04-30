using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform kitchenSpawn;

    void Start()
    {
        string spawn = PlayerPrefs.GetString("SpawnPoint", "");

        if (spawn == "Kitchen")
        {
            transform.position = kitchenSpawn.position;
            transform.rotation = kitchenSpawn.rotation;

            PlayerPrefs.SetString("SpawnPoint", "");
        }
    }
}