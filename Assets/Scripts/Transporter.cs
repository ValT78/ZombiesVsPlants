using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transporter : MonoBehaviour
{
    public static int[] plantTable;
    public static int unlockedZombie;
    public static string message;
    public static int nexusLife;
    public static float sunMultiplier;
    public static float brainMultiplier;
    public static int startingSun;
    public static int startingBrain;
    public static float plantSpawnTime;
    public static bool spawnBrains;

    private static bool hasBeenLoaded;

    public static float gameSpeed = 1;
    public static Transporter transporter;


    // Start is called before the first frame update
    void Start()
    {
        transporter = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    // Update is called once per frame
    public void LoadGame(int[] plantTable, int unlockedZombie, string message, int nexusLife, float sunMultiplier, float brainMultiplier, int startingSun, int startingBrain, int plantSpawnTime,bool spawnBrains)
    {
        Transporter.plantTable = plantTable;
        Transporter.unlockedZombie = unlockedZombie;
        Transporter.message = message;
        Transporter.nexusLife = nexusLife;
        Transporter.sunMultiplier = sunMultiplier;
        Transporter.brainMultiplier = brainMultiplier;
        Transporter.startingSun = startingSun;
        Transporter.startingBrain = startingBrain;
        Transporter.plantSpawnTime = plantSpawnTime;
        Transporter.spawnBrains = spawnBrains;
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
            // Marquer le GameObject comme charg� et ne pas le d�truire lors des transitions de sc�ne
            hasBeenLoaded = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // D�truire le GameObject s'il a d�j� �t� charg� auparavant
            Destroy(gameObject);
        }
    }
}
