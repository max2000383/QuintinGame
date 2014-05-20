using UnityEngine;
using System.Collections;

public class BendyLightning : MonoBehaviour {
	public bool pointDown = false;
	public LineRenderer lineRenderer;
	public Color color = Color.white;
	public float width = 0.5f;
	public float dis = 5.0f;
	public float jump = 0.2f;
	private Vector3 [] oldPos;
	
	void Start () {
		lineRenderer = (GetComponent <LineRenderer> () as LineRenderer);
		lineRenderer.SetColors (color, color);
		lineRenderer.SetWidth (width, width);
		oldPos = new Vector3[(int)Mathf.Round(dis / 0.5f)];
	}
	

	void FixedUpdate () {
		int i = 1;
		Vector3 lastPos = new Vector3();
		float totalZ = 0.0f;
		if (pointDown)
			transform.eulerAngles = new Vector3 (Random.Range (60, 120), Random.Range (-180, 180), Random.Range (-90, 90));

		while (totalZ < dis) {
			lineRenderer.SetVertexCount(i + 1);
			Vector3 pos = lastPos;
			pos.z += 0.5f;
			pos = new Quaternion(Random.Range(-jump, jump), Random.Range(-jump, jump), 0, 1) * pos;
			totalZ += 0.5f;
			lineRenderer.SetPosition(i, pos);
			i++;
			lastPos = pos;
			oldPos[i - 2] = pos;
		}
	}

	public void SetStats (Color a, float b, float c, float d) {
		color = a;
		width = b;
		dis = c;
		jump = d;
	}

	public void DestroySpark () {
		Destroy (gameObject);
	}
}