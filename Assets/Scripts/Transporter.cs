using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transporter : MonoBehaviour
{
    public int[] plantTable;
    public int unlockedZombie;
    public string message;
    public float sunMultiplier;
    public bool spawnBrains;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    // Update is called once per frame
    public void LoadGame(int[] plantTable, int unlockedZombie, string message, float sunMultiplier, bool spawnBrains)
    {
        this.plantTable = plantTable;
        this.unlockedZombie = unlockedZombie;
        this.message = message;
        this.sunMultiplier = sunMultiplier;
        this.spawnBrains = spawnBrains;
        SceneManager.LoadScene("Game");
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.isLoaded && scene.name == "Game")
        {
            PlantManager plantManager = FindObjectOfType<PlantManager>();
            ZombieManager zombieManager = FindObjectOfType<ZombieManager>();
            plantManager.plantOrder = plantTable;
            plantManager.sunMultiplier = sunMultiplier;
            zombieManager.DispawnObject(unlockedZombie, message,spawnBrains);
            StartCoroutine(Kill());
        }
    }

    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
