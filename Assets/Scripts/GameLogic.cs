using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour
{
	public GameObject player;
	public GameObject startUI, restartUI;
	public GameObject startPoint, playPoint, restartPoint, madHatterPoint;
	public GameObject alice;
	private bool pressPlay = false;

	void Start()
	{
		// Update 'player' to be the camera's parent gameobject, i.e. GvrEditorEmulator, instead of the camera itself.
		// Required because GVR resets camera position to 0, 0, 0.
		player = player.transform.parent.gameObject;

		// Move player to the start position.
		player.transform.position = startPoint.transform.position;

		alice.GetComponent<Animation> ().Play ("Jump");

	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && player.transform.position == playPoint.transform.position)
		{
			PuzzleSuccess();
			//GoToMadHatter();


		}


		//{
		//	iTween.RotateBy(player, new Vector3 ( 0, 30, 0), 1);
		//}



		if (pressPlay) {
			alice.GetComponent<Animation> ().Play ("Run");
			pressPlay = false;
		}
		else if (!alice.GetComponent<Animation> ().IsPlaying ("Run")) 
			
			alice.GetComponent<Animation> ().Play ("Idle");
	}

	// Begin the puzzle sequence.
	public void StartPuzzle()
	{
		ToggleUI();


		iTween.MoveTo(player,
			iTween.Hash(
				"position", madHatterPoint.transform.position,
				"time", 1.1,
				"easetype", "linear"
			)
		);
		alice.GetComponent<Animation> ().Play ("Run");
		pressPlay = true;



		//alice.GetComponent<Animation> ().Play ("Idle");

	}

	// Reset the puzzle sequence.
	public void ResetPuzzle()
	{
		player.transform.position = startPoint.transform.position;
		ToggleUI();
	}

	// Do this when the player solves the puzzle.
	public void PuzzleSuccess()
	{
		iTween.MoveTo(player,
			iTween.Hash(
				"position", restartPoint.transform.position,
				"time", 2,
				"easetype", "linear"
			)
		);
	}

	public void GoToMadHatter()
	{
		iTween.MoveTo(player,
			iTween.Hash(
				"position", madHatterPoint.transform.position,
				"time", 2,
				"easetype", "linear"
			)
		);
		//iTween.RotateTo(player, iTween.Hash("rotation", 30, "time", 1, "easetype", "linear"));
	}

	public void ToggleUI()
	{
		startUI.SetActive(!startUI.activeSelf);
		restartUI.SetActive(!restartUI.activeSelf);
	}

	// Placeholder method to prevent compiler errors caused by this method being called from LightUp.cs.
	public void PlayerSelection(GameObject sphere)
	{
		// Will be completed later in the course.
	}
}