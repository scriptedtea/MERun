using UnityEngine;
using System.Collections;

public class ChangeScene: MonoBehaviour {
    [SerializeField]
    public string nextLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goToNextLevel() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
	}
}
