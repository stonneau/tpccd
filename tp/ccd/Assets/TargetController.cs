using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour {

	public Transform target;
	/*Control target with directional keys + V and B*/
	void Update () {
		gameObject.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10, 0, 0);
		gameObject.transform.Translate(0, Input.GetAxis("Vertical") * Time.deltaTime * 10, 0);
		if(Input.GetKey(KeyCode.V))
		{
			gameObject.transform.Translate(0, 0, Time.deltaTime * 10);
		}
		if(Input.GetKey(KeyCode.B))
		{
			gameObject.transform.Translate(0, 0, -Time.deltaTime * 10);
		}
	}
}
	