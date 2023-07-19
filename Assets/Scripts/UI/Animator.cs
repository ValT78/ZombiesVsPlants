using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator : MonoBehaviour
{

	public GameObject icon, playButton, htpButton, creditsButton, quitButton;

    private int hoveredOption;

	private GameObject[] options;

	public AudioSource hoversoundEffect;
	void Start()
	{
		options = new GameObject[] { playButton, htpButton, creditsButton, quitButton };

		MouserOver(0);
	}


	public void MouserOver(int hovered)
	{
		hoveredOption = hovered;
		icon.transform.position = options[hoveredOption].transform.position - 0.1f * Camera.main.pixelWidth * Vector3.right;
		hoversoundEffect.Play();
	}


	public void QuitApplication()
	{
		Application.Quit();
	}

}
