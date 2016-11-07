using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public Text finalTimeText;
	public Text finalDistanceText;

	void Start(){
		finalTimeText.text = MERun.finalTime;
		finalDistanceText.text = MERun.finalDistance;
		//TODO this is really bad but it's a gamejam
		if (MERun.finalDistance.Equals("Distance: 1000")) {
			finalDistanceText.text += "!  You Win!!!";
		}
	}

	public void restartGame(){
		UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
	}
}
