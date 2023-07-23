using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelParameters : MonoBehaviour
{
    private readonly List<int[]> listLevel = new();
    private readonly List<int[]> plantPlacement = new();
    private int[] unlockedZombie;
    private string[] messages;
    private int[] nexusLife;
    private float[] sunMultiplier;
    private float[] brainMultiplier;
    private int[] startingSun;
    private int[] startingBrain;
    private int[] plantSpawnTime;
    private bool[] spawnSuns;
    private bool[] spawnBrains;

    void Start()
    {
        spawnBrains = new bool[] { true, true, true, true, true, true, true, true, false, true, true, true, false, true, true, true, true, true };
        spawnSuns = new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        unlockedZombie = new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 3, 4, 5, 5, 5, 5, 5, 5,5,5};
        sunMultiplier = new float[] { 1f, 1f, 1.10f, 1.20f, 1.30f, 1.40f, 1.50f, 1.60f, 1f, 1.70f, 1.70f, 1.70f, 1f, 1.80f, 1.80f, 1.90f, 1.90f, 2f };
        brainMultiplier = new float[] { 1f, 1f, 1.05f, 1.10f, 1.15f, 1.20f, 1.25f, 1.30f, 1f, 1.35f, 1.35f, 1.35f, 1f, 1.40f, 1.40f, 1.45f, 1.45f, 1.5f };
        startingSun = new int[] { 0, 100, 50, 100, 100, 100, 100, 100, 0, 0, 0, 100, 0, 100, 100, 100, 100, 100 };
        startingBrain = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
        nexusLife = new int[] { 800, 800, 700, 600, 500, 450, 400, 350, 300, 250, 200, 150, 300, 100, 50, 50, 30, 30 };
        plantSpawnTime = new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };

        listLevel.Add(new int[] { 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        listLevel.Add(new int[] { 3 });
        listLevel.Add(new int[] { 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0 });
        listLevel.Add(new int[] { 0, 3, 0, 2, 2, 2, 2, 2, 2, 3,0, 0, 2, 2, 2, 2, 2 });
        listLevel.Add(new int[] { 0, 3, 0, 0, 0, 0, 3, 2, 0, 3, 2, 0, 3, 2, 0, 3, 2, 0, 3, 2, 0 });
        listLevel.Add(new int[] { 0, 0, 12, 12, 12, 12, 12 });
        listLevel.Add(new int[] { 0, 0, 2, 2, 3, 2, 2, 2, 3, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3 });
        listLevel.Add(new int[] { 3, 3, 0, 0, 9, 9, 3, 3, 3, 9, 3, 3, 3, 9 });
        listLevel.Add(new int[] { 3, 3, 2, 0, 12, 0, 9, 0, 2 });
        listLevel.Add(new int[] { 0, 4, 0, 4, 2, 4, 4, 12, 0, 2, 0, 10, 4, 0, 12, 10, 0 });
        listLevel.Add(new int[] { 0, 5, 0, 5, 0, 0, 12, 5, 2, 12, 11, 5, 11, 2, 12, 0 });
        listLevel.Add(new int[] { 0, 1, 6, 0, 6, 1, 7, 8, 7, 8 });
        listLevel.Add(new int[] { 3, 2, 4, 0, 5, 12, 1, 4, 8, 0, 5, 0, 2, 12, 0, 10, 0, 11 });
        listLevel.Add(new int[] { 0, 5, 0, 7, 1, 12, 2, 12, 0, 9, 4, 4, 0, 1, 2, 12, 2, 6, 3, 11, 0, 1, 12, 12, 2, 3, 4, 5, 3, 4, 5, 0, 1, 2, 2, 12, 10, 11, 6, 0 });
        listLevel.Add(new int[] { 0, 3, 2, 0, 4, 12, 0, 8, 2, 1, 5, 12, 0, 10, 2, 1, 6, 12, 0, 5, 2, 0, 7, 12, 0, 9, 2, 1, 5, 12 });
        listLevel.Add(new int[] { 3,0, 0, 0, 10, 11, 12, 12, 12, 12, 12, 0, 0, 0, 3, 4, 5, 3, 4, 5, 3, 4, 5, 2, 2, 2 });
        listLevel.Add(new int[] { 0,5, 0, 7, 10, 1, 12, 12, 0, 8, 11, 0, 1, 2, 2, 2, 12, 6, 9 });
        listLevel.Add(new int[] { 0, 0, 0, 1, 1, 2, 12, 2, 12, 2, 4, 5, 4, 5, 4, 0, 1, 1, 1, 0, 9, 9, 12, 2, 12, 2, 12 });

        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });

        messages = new string[]
        {
            " ",
            "Be ready to deal with a lot of peashooter",
            "  ",
            "Be ready to fight the nut ! This plant doesn't attack but has a lot of HP",
            "Sport zombie can only eat one plant before dying due to his strict diet. He has low HP, but strong damage and speed for his low cost !",
            "This level is filled of Pears : a one-use plant that deal area damage",
            "Use the quaterback zombie : it costs a lot but he is fast and has so mush HP and damage",
            "Another level with many peashooter. Be careful with the triple-Peashooter : shoot on several lane",
            "This level is special : no brain come from the ground ! you'll have to use a lot of gravestones",
            "   ",
            "    ",
            "DOUBLE sunflower and peashooter : 2 times more efficient in a smaller area",
            "Another level with no bonus brains from the ground ! We need gravestones !",
            "You know everything of this game now. But are you really that strong ?",
            "you think the last level was hard ? Try this one",
            "OK ! You dare challenge this game ? You will regret it !",
            "will you ever be tired of destroying happy plants wanting to live in peace",
            "If you're able to defeat this level, you really are the zombie's master !"
        };
    }

    public void LoadGame(int level)
	{
        Transporter.transporter.LoadGame(listLevel[level], plantPlacement[level], unlockedZombie[level], messages[level], nexusLife[level], sunMultiplier[level], brainMultiplier[level], startingSun[level], startingBrain[level], plantSpawnTime[level], spawnSuns[level], spawnBrains[level]);
	}
    

}
