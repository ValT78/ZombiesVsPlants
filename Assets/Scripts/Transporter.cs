using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transporter : MonoBehaviour
{
    public static int[] plantTable;
    public static int unlockedZombie;
    public static string message;
    public static float sunMultiplier;
    public static bool spawnBrains;
    public static int nexusLife;
    private static bool hasBeenLoaded;
    public static Transporter transporter;

    // Start is called before the first frame update
    void Start()
    {
        transporter = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    // Update is called once per frame
    public void LoadGame(int[] plantTable, int unlockedZombie, string message, float sunMultiplier, bool spawnBrains,int nexusLife)
    {
        Transporter.plantTable = plantTable;
        Transporter.unlockedZombie = unlockedZombie;
        Transporter.message = message;
        Transporter.sunMultiplier = sunMultiplier;
        Transporter.spawnBrains = spawnBrains;
        Transporter.nexusLife = nexusLife;
        SceneManager.LoadScene("Game");
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.isLoaded && scene.name == "Game")
        {
            ZombieManager.zombieManager.DispawnObject();
        }
    }
    private void Awake()
    {
        if (!hasBeenLoaded)
        {
            // Marquer le GameObject comme chargé et ne pas le détruire lors des transitions de scène
            hasBeenLoaded = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Détruire le GameObject s'il a déjà été chargé auparavant
            Destroy(gameObject);
        }
    }
}
