using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public void restartGame(){
		Debug.Log ("RESTART!");
		UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
	}
}
