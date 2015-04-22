using UnityEngine;
using System.Collections;

public class EnemyHitDetection : MonoBehaviour {

	// Use this for initialization
	//void Start () {
	//}
	
	// Update is called once per frame
	void Update() {
		if (Application.isMobilePlatform) {
			if (Input.touchCount > 0) {
				Touch t = Input.GetTouch(0);

				if (t.phase == TouchPhase.Began || t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary) {
					this.CheckHit(t.position);
				}
			}
		} else {
			if (Input.GetMouseButton(0)) {
				this.CheckHit(Input.mousePosition);
			}
		}
	}

	private void CheckHit(Vector3 pos) {
		Vector3 v = Camera.main.ScreenToWorldPoint(pos);
		Collider2D col = Physics2D.OverlapCircle(new Vector2(v.x, v.y), 0.5f);

		if (col != null) {
			col.transform.gameObject.SendMessage("OnHit", SendMessageOptions.DontRequireReceiver);
			//GameInfo gi = this.gameObject.GetComponent<GameInfo>();
			//if (gi != null) {
			//	gi.IncrementScore();
			//}
		}
	}
}
