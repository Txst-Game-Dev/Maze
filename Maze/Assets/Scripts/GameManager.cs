using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//public float childScale;
//public Maze mazePrefab;

//private Maze mazeInstance;



public class GameManager : MonoBehaviour {

	//public Player playerPrefab;

	//private Player playerInstance;

	public FirstPersonController PlayerPrefab;

	private FirstPersonController PlayerInstance;

	public Maze mazePrefab;
	private Maze mazeInstance;

	private void Start () {
		StartCoroutine(BeginGame());
	}

	private void Update () {
		//if (Input.GetKeyDown(KeyCode.Space)) {
		//	RestartGame();
		//}
	}

	//You can remove setting the two camera rectangles to have one camera.
	private IEnumerator BeginGame () {
		//This renders the camera without a background.
		//Camera.main.clearFlags = CameraClearFlags.Skybox;
		//First Camera in the scene set
		//Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
		 
		//Camera.main.
		mazeInstance = Instantiate(mazePrefab) as Maze;
		yield return StartCoroutine(mazeInstance.Generate());
        

		DestroyImmediate (Camera.main.gameObject);

		PlayerInstance = Instantiate(PlayerPrefab) as FirstPersonController;

		Camera.main.nearClipPlane = 0.01f;

        //The controller does not have a set location
        //A set location could be added to the class if you wanted to
        //BodyPlayerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));

        //This was used to basically make a little mini map.
        //This renders the camera without a background.
        //Camera.main.clearFlags = CameraClearFlags.Depth;
        //The main camera in the scene set
        //Camera.main.rect = new Rect(0f, 0f, 0.25f, 0.25f);
	}


	private void RestartGame () {
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		if (PlayerInstance != null) {
			Destroy(PlayerInstance.gameObject);
		}
		StartCoroutine(BeginGame());
	}

}