using UnityEngine;
using System.Collections;

public class Building : Environment {
	const int NEXT_BUILDING_X_TRIGGER = 0;
	bool triggered = false;

	void Update(){
		base.Update ();

		if (!triggered && gameObject.transform.position.x < NEXT_BUILDING_X_TRIGGER) {
			EnvironmentSpawner.spawnEnvironment ();
			triggered = true;
		}
	}
}
