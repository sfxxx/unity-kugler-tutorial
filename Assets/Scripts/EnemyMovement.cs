using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed;

	// Use this for initialization
	//void Start () {
	//}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += Vector3.down * this.speed * Time.deltaTime;

		if (!this.GetComponent<Renderer>().isVisible) {
			GameObject system = GameObject.Find("MySystem");
			if (system != null) {
				system.SendMessage("DamagePlayer", SendMessageOptions.DontRequireReceiver);
			}
			GameObject.Destroy(this.gameObject);
		}
	}
}
