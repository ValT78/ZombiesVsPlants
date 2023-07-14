using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelParameters : MonoBehaviour
{
    [SerializeField] private Transporter transporter;
    private readonly List<int[]> listLevel = new();
    private float[] sunMultiplier;
    private int[] unlockedZombie;
    private bool[] spawnBrains;


    void Start()
    {
        spawnBrains = new bool[] { true, true, true, true, true, true, true, true, false, true, true, true, false, true};
        unlockedZombie = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        sunMultiplier = new float[] { 0.5f, 0.5f, 0.55f, 0.6f, 0.65f, 0.7f, 0.75f, 0.8f, 0.85f, 0.9f, 0.95f, 1f, 1f, 1f };
        listLevel.Add(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        listLevel.Add(new int[] { 0, 3, 3, 2, 3, 3, 2, 3, 3, 2, 3, 3, 6, 6, 3, 6, 6, 2 });
        listLevel.Add(new int[] { 0, 3, 3, 6, 3, 3, 3, 3, 2, 2, 2, 0, 6, 6, 3, 6, 6, 2 });
        listLevel.Add(new int[] { 0, 3, 4, 0, 3, 0, 2, 3, 0, 2, 5, 0, 8, 0, 4, 6, 7, 2 });
        listLevel.Add(new int[] { 0, 3, 0, 5, 0, 3, 4, 3, 0, 2, 3, 0, 6, 0, 3, 7, 8, 2 });

    }

    public void LoadGame(int level)
	{
        transporter.LoadGame(listLevel[level], unlockedZombie[level], sunMultiplier[level], spawnBrains[level]);
	}
    

}
