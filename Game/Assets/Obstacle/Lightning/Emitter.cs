using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {
	public float rate = 0.1f;
	public bool smooth = true;
	public float spread = 0.001f;
	public Transform spark;
	public bool runWhileOutOfSight = false;
	public Color color = Color.white;
	public float width = 0.5f;
	public float dis = 5.0f;
	public float jump = 0.2f;
	private Vector3[] baseVertices;
	private Mesh mesh;
	private bool run = false;
	
	void Start () {
		MeshFilter filter = (GetComponent<MeshFilter> () as MeshFilter);
		mesh = (filter.mesh as Mesh);
		if (baseVertices == null)
			baseVertices = mesh.vertices;
		EmitLightning ();
	}

	public void EmitLightning () {
		while (run) {
			transform.BroadcastMessage ("DestroySpark", SendMessageOptions.DontRequireReceiver);
			for (int i = 0; i < baseVertices.Length; i++) {
				if (Random.Range (-1.0f, spread) > 0.0f) {
					Transform sub = Instantiate (spark, transform.position, Random.rotation) as Transform;
					BendyLightning script = sub.GetComponent<BendyLightning> () as BendyLightning;
					sub.parent = transform;
					sub.transform.localPosition = baseVertices [i];
					script.SetStats (color, width, dis, jump);
				}
			Invoke ("Wait", rate);
			}
		}
	}

	void Wait() {}

	void OnBecameVisible () {
		run = true;
		EmitLightning ();
	}

	void OnBecameInvisible () {
		if (runWhileOutOfSight == false) {
			run = false;
			EmitLightning ();
		}
	}
}