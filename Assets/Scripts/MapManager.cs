using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
	public Character Character;
	public Pin StartPin;
	public Text SelectedLevelText;
	
	/// <summary>
	/// Use this for initialization
	/// </summary>
	private void Start ()
	{
		// Pass a ref and default the player Starting Pin
		Character.Initialise(this, StartPin);
	}


	/// <summary>
	/// This runs once a frame
	/// </summary>
	private void Update()
	{
		// Only check input when character is stopped
		if (Character.IsMoving) return;
		
		// First thing to do is try get the player input
		CheckForInput();
	}

	
	/// <summary>
	/// Check if the player has pressed a button
	/// </summary>
	private void CheckForInput()
	{
		if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			Character.TrySetDirection(Direction.Up);
		}
		else if(Input.GetKeyUp(KeyCode.DownArrow))
		{
			Character.TrySetDirection(Direction.Down);
		}
		else if(Input.GetKeyUp(KeyCode.LeftArrow))
		{
			Character.TrySetDirection(Direction.Left);
		}
		else if(Input.GetKeyUp(KeyCode.RightArrow))
		{
			Character.TrySetDirection(Direction.Right);
		}
	}

	
	/// <summary>
	/// Update the GUI text
	/// </summary>
	public void UpdateGui()
	{
		SelectedLevelText.text = string.Format("Current Level: {0}", Character.CurrentPin.SceneToLoad);
	}
}
