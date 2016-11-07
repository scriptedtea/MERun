using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public Text finalTimeText;
	public Text finalDistanceText;

	void Start(){
		finalTimeText.text = MERun.finalTime;
		finalDistanceText.text = MERun.finalDistance;
	}

	public void restartGame(){
		UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
	}
}
