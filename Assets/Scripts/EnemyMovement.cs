using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed;
	private bool rendererWasVisible;

	// Use this for initialization
	//void Start () {
	//}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += Vector3.down * this.speed * Time.deltaTime;

		if (!this.GetComponent<Renderer>().isVisible && this.rendererWasVisible) {
			// Alternatively we could have called GetComponent on the system gameobject to get the GameInfo component and called the method directly
			GameObject mySystem = GameObject.Find("MySystem");
			if (mySystem != null) {
				mySystem.SendMessage("DamagePlayer", SendMessageOptions.DontRequireReceiver);
			}
			GameObject.Destroy(this.gameObject);
		}

		if (!this.GetComponent<Renderer>().isVisible) {
			this.rendererWasVisible = true;
		}
	}
}
