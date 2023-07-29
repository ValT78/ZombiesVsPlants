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
        spawnBrains = new bool[] { true, true, true, true, true, true, true, true, false, true, true, true, false, true, true, true, true, true, true, true, true, true, true, true, false, true, true, true, true, true, true, false, true, true, true, true, true, true, true, true, true };
        spawnSuns = new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, true, true, true, true, true, true, false, true, true, true, true, false, true, true, true, false, true, true, true };
        unlockedZombie = new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 3, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
        sunMultiplier = new float[] { 0.5f, 0.8f, 0.55f, 1.20f, 1.30f, 1.40f, 1.50f, 1.60f, 1f, 1.70f, 1.70f, 1.70f, 1f, 1.80f, 1.80f, 1.90f, 1.90f, 2f, 2.3f, 2.2f, 2.2f, 0f, 2.1f, 2.1f, 1.4f, 2.7f, 2.1f, 4f, 0f, 2.2f, 2.2f, 1.4f, 1.8f, 0f, 2.3f, 2.3f, 4.5f, 0f, 2.4f, 2.4f, 2.5f };
        brainMultiplier = new float[] { 1f, 1f, 1.05f, 1.10f, 1.15f, 1.20f, 1.25f, 1.30f, 1f, 1.35f, 1.35f, 1.35f, 1f, 1.40f, 1.40f, 1.45f, 1.45f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.5f, 1.6f, 1.4f, 1.5f, 2.5f, 1.5f, 1.5f, 1.5f, 1f, 1.4f, 1.5f, 1.5f, 1.5f, 2.5f, 1.5f, 1.5f, 1.5f, 1.5f };
        startingSun = new int[] { 50, 25, 100, 100, 100, 100, 100, 100, 0, 0, 0, 100, 0, 100, 100, 100, 100, 100, 300, 300, 300, 1250, 300, 1600, 300, 300, 300, 300, 2500, 300, 300, 300, 300, 2200, 2100, 300, 300, 3000, 300, 300, 300 };
        startingBrain = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 200, 200, 200, 400, 200, 800, 200, 200, 200, 200, 200, 200, 300, 300, 200, 600, 1000, 200, 200, 200, 200, 200, 500 };
        nexusLife = new int[] { 800, 800, 700, 600, 500, 450, 400, 350, 300, 250, 200, 150, 300, 100, 50, 50, 30, 30, 100, 100, 100, 700, 50, 200, 100, 30, 50, 100, 500, 50, 50, 100, 50, 900, 300, 50, 100, 500, 50, 50, 30 };
        plantSpawnTime = new int[] { 8, 3, 8, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 5, 5, 5, 2, 5, 5, 5, 5, 5, 5, 12, 5, 5, 5, 5, 5, 5, 5, 5, 12, 5, 5, 5 };

        listLevel.Add(new int[] { 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        listLevel.Add(new int[] { 3 });
        listLevel.Add(new int[] { 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0 });
        listLevel.Add(new int[] { 0, 3, 0, 2, 2, 2, 2, 2, 2, 3,0, 0, 2, 2, 2, 2, 2 });
        listLevel.Add(new int[] { 0, 3, 0, 0, 0, 0, 3, 2, 0, 3, 2, 0, 3, 2, 0, 3, 2, 0, 3, 2, 0 });
        //5
        listLevel.Add(new int[] { 0, 0, 12, 12, 12, 12, 12 });
        listLevel.Add(new int[] { 0, 0, 2, 2, 3, 2, 2, 2, 3, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3 });
        listLevel.Add(new int[] { 3, 3, 0, 0, 9, 9, 3, 3, 3, 9, 3, 3, 3, 9 });
        listLevel.Add(new int[] { 3, 3, 2, 0, 12, 0, 9, 0, 2 });
        listLevel.Add(new int[] { 0, 4, 0, 4, 2, 4, 4, 12, 0, 2, 0, 10, 4, 0, 12, 10, 0 });
        //10
        listLevel.Add(new int[] { 0, 5, 0, 5, 0, 0, 12, 5, 2, 12, 11, 5, 11, 2, 12, 0 });
        listLevel.Add(new int[] { 0, 1, 6, 0, 6, 1, 7, 8, 7, 8 });
        listLevel.Add(new int[] { 3, 2, 4, 0, 5, 12, 1, 4, 8, 0, 5, 0, 2, 12, 0, 10, 0, 11 });
        listLevel.Add(new int[] { 0, 5, 0, 7, 1, 12, 2, 12, 0, 9, 4, 4, 0, 1, 2, 12, 2, 6, 3, 11, 0, 1, 12, 12, 2, 3, 4, 5, 3, 4, 5, 0, 1, 2, 2, 12, 10, 11, 6, 0 });
        listLevel.Add(new int[] { 0, 3, 2, 0, 4, 12, 0, 8, 2, 1, 5, 12, 0, 10, 2, 1, 6, 12, 0, 5, 2, 0, 7, 12, 0, 9, 2, 1, 5, 12 });
        //15
        listLevel.Add(new int[] { 3,0, 0, 0, 10, 11, 12, 12, 12, 12, 12, 0, 0, 0, 3, 4, 5, 3, 4, 5, 3, 4, 5, 2, 2, 2 });
        listLevel.Add(new int[] { 0,5, 0, 7, 10, 1, 12, 12, 0, 8, 11, 0, 1, 2, 2, 2, 12, 6, 9 });
        listLevel.Add(new int[] { 0, 0, 0, 1, 1, 2, 12, 2, 12, 2, 4, 5, 4, 5, 4, 0, 1, 1, 1, 0, 9, 9, 12, 2, 12, 2, 12 });

        listLevel.Add(new int[] { 0, 13, 0, 13, 1, 2, 12, 2, 14, 15, 0, 1, 13, 2, 12, 2 });
        listLevel.Add(new int[] { 0, 0, 4, 5, 0, 0, 14, 15, 1, 10, 12, 11, 12, 4, 5, 0, 0, 7, 8, 0, 0, 2, 2, 14, 15 });
        //20
        listLevel.Add(new int[] { 0, 16, 0, 16, 1, 2, 12, 2, 17, 18, 0, 1, 16, 2, 12, 2 });
        listLevel.Add(new int[] { 3, 3, 3, 3, 3, 4, 5, 4, 5, 4, 2, 2, 2, 2, 2 });
        listLevel.Add(new int[] { 0, 0, 1, 17, 16, 2, 2, 2, 18, 2, 2, 0, 16, 0, 18, 2, 2, 0, 1, 17, 16, 0, 0, 2, 18, 2, 2, 0, 17 });
        listLevel.Add(new int[] { 7, 0, 1, 1, 6, 12, 12, 0, 12, 7, 0, 1, 6, 8, 8, 12, 12, 0 });
        listLevel.Add(new int[] { 14, 0, 0, 4, 0, 14, 1, 5, 5, 12, 5, 15, 0, 12, 2, 1, 3, 4, 15, 0, 0, 13, 13, 5, 4, 2 });
        //25
        listLevel.Add(new int[] { 0, 0, 16, 16, 16, 16, 2, 2, 0, 0, 17, 18, 18, 17, 2, 2, 0 });
        listLevel.Add(new int[] { 0, 1, 3, 4, 2, 2, 0, 1, 2, 4, 5, 3, 4, 2, 2, 0, 0, 1, 2, 2, 2, 5, 0, 4, 3, 5 });
        listLevel.Add(new int[] { 3, 17, 4, 0, 0, 4, 17, 2, 12, 0, 2, 3, 5, 1, 18, 14, 0, 3, 4, 4, 2, 12, 0, 0, 16,7 });
        listLevel.Add(new int[] { 10, 4, 4, 16, 15, 2, 12, 8, 5, 9, 4, 7, 17, 12, 2, 9, 8, 5, 15 });
        listLevel.Add(new int[] { 4, 0, 0, 7, 6, 2, 2, 0, 1, 12, 5, 5, 8, 0, 12, 0, 2, 3, 3, 6, 1, 0, 2, 4, 12, 2, 7, 0, 6, 4, 0 });
        //30
        listLevel.Add(new int[] { 0, 0, 1, 8, 11, 2, 0, 2, 5, 18, 0, 5, 1, 15, 0, 12, 12, 0, 2, 7, 10, 2, 0, 2, 4, 17, 0, 4, 1, 14, 0, 12, 12, 0, 2 });
        listLevel.Add(new int[] { 0, 0, 12, 1, 12, 9, 10, 0, 12, 12,3, 12, 9, 0, 1, 12, 11, 0, 12,13, 11, 9, 0, 1, 12, 12, 10, 9 });
        listLevel.Add(new int[] { 0, 0, 0, 13, 13, 2, 2, 12, 1, 1, 7, 8, 0, 0, 14, 15, 1, 6 });
        listLevel.Add(new int[] { 7, 10, 9, 11, 8, 17, 12, 12, 12, 18, 12, 2, 2, 2, 12 });
        listLevel.Add(new int[] { 11, 18, 9, 2, 12, 0, 0, 1, 12, 2, 16, 16, 0, 0, 10, 10, 17, 2, 2, 12, 0, 1 });
        //35
        listLevel.Add(new int[] { 0, 2, 0, 3, 0, 4, 0, 5, 0, 6, 0, 7, 0, 8, 0, 9, 0, 10, 0, 11, 0, 12, 0, 13, 0, 14, 0, 15, 0, 16, 0, 17, 0, 18 });
        listLevel.Add(new int[] { 3, 0, 6, 12, 1, 9, 2, 0, 1, 16, 4, 0, 7, 13, 1, 10, 0, 17, 5, 2, 0, 8, 1, 11, 12, 0, 18 });
        listLevel.Add(new int[] { 13, 4, 14, 2, 4, 3, 9, 15, 5, 12, 5, 13, 4, 14, 2, 4, 3, 6, 15, 5, 12, 5 });
        listLevel.Add(new int[] { 0, 0, 14, 15, 0, 0, 10, 7, 1, 12, 12, 16, 16, 0, 1, 0, 7, 8, 0, 9, 2, 2, 0, 0, 12 });
        listLevel.Add(new int[] { 0, 5, 0, 3, 4, 2, 12, 1, 9, 15, 0, 0, 18, 16, 0, 7 });
        //40
        listLevel.Add(new int[] { 0, 0, 14, 15, 0, 0, 10, 7, 1, 12, 12, 16, 16, 0, 1, 0, 7, 8, 0, 9, 2, 2, 0, 12 });


        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        //5
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        //10
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        //15
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });

        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 1, 5, 1, 5, 2, 4, 2, 4, 3, 2, 2, 4, 4, 1, 5, 3, 3, 2, 4, 5, 1, 5, 1, 2, 4 });
        //20
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 5, 4, 3, 2, 1 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        //25
        plantPlacement.Add(new int[] { 1, 5 });
        plantPlacement.Add(new int[] { 2, 5, 2, 5, 2, 5, 3, 1, 3, 1, 3, 3, 1, 4, 4, 3, 4, 2, 4, 2, 4, 1, 1, 2, 3, 4, 5 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        //30
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 3, 1, 5, 4, 2, 3, 1, 5, 2, 4, 2, 4, 1, 5, 1, 5, 3, 3 });
        plantPlacement.Add(new int[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 5, 4, 3, 2, 1 });
        plantPlacement.Add(new int[] { 0 });
        //35
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 0 });
        plantPlacement.Add(new int[] { 1, 5, 1, 5, 4, 2, 3, 3, 3, 2, 4, 5, 1, 2, 3, 4, 2, 4, 3, 3, 1, 5, 1, 5, 3 });
        plantPlacement.Add(new int[] { 2, 3, 4, 4, 2, 3, 2, 4, 3, 3, 3, 4, 2, 2, 4, 3, 3 });
        //40
        plantPlacement.Add(new int[] { 0 });

        messages = new string[]
        {
            " ",
            "  ",
            "   ",
            "Be ready to fight the nut ! This plant doesn't attack but has a lot of HP",
            "Sport zombie can only eat one plant before dying due to his strict diet. He has low HP, but strong damage and speed for his low cost !",
            "This level is filled of Pears : a one-use plant that deal area damage",
            "Use the quaterback zombie : it costs a lot but he is fast and has so mush HP and damage",
            "Another level with many peashooter. Be careful with the triple-Peashooter : shoot on several lane",
            "This level is special : no brain come from the ground ! you'll have to use a lot of gravestones",
            "    ",
            "     ",
            "DOUBLE sunflower and peashooter : 2 times more efficient in a smaller area",
            "Another level with no bonus brains from the ground ! We need gravestones !",
            "You know everything of this game now. But are you really that strong ?",
            "you think the last level was hard ? Try this one",
            "OK ! You dare challenge this game ? You will regret it !",
            "will you ever be tired of destroying happy plants wanting to live in peace",
            "If you're able to defeat this level, you really are the zombie's master !",

            "Introducing Mushroom ! Shoot spores, dealing damage to several zombies with one projectile",
            "In DLC levels, plants can now spawn on a predefine lane instead of the furthest from zombies",
            "Probably the last new plant. It shoots two peas in diagonale so he can defend every lane... except its own",
            "This level summon a whole castle of plant. But it don't produce sun !",
            "A classic hard level with a lot of split peas and nuts",
            "A special level where you and your opponent start with a ton of brain and sun",
            "No additionnal brain from the ground, you know the rules",
            "RUSH SPLIT PEAS ON SIDE LANE !",
            "Basic strategy doesn't mean inneficient",
            "There is a crazy multiplier on sun and brain this level. You have to think fast !",
            "Your opponent start with a ton of sun, but don't produce anything. The beggining might be tough",
            "Classic level with split and triple peashooter. The screen will be filled of peas",
            "Can you spot the pattern in plants spawn",
            "The last level without additionnal brains from the ground",
            "A threatening combo of plants with a predetermine placement on the terrain",
            "You liked the instant fortress ? You will love the instant bastion !",
            "A special level where you and your opponent start with a ton of brain and sun",
            "All the plant roaster in one level",
            "There is a crazy multiplier on sun and brain this level. You have to think fast !",
            "Your opponent start with a ton of sun, but don't produce anything. The beggining might be tough",
            "Solid defense with pre place plants",
            "RUSH ON THE MIDDLE LANE !",
            "It might be impossible... May be..."
        };
    }

    public void LoadGame(int level)
	{
        Transporter.transporter.LoadGame(level, listLevel[level], plantPlacement[level], unlockedZombie[level], messages[level], nexusLife[level], sunMultiplier[level], brainMultiplier[level], startingSun[level], startingBrain[level], plantSpawnTime[level], spawnSuns[level], spawnBrains[level]);
	}
    

}
