using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public Text finalTimeText;

	void Start(){
		finalTimeText.text = MERun.finalTime;
	}

	public void restartGame(){
		UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
	}
}
