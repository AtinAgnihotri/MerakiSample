using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipNormals : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mesh mesh = this.GetComponent<MeshFilter> ().mesh;

		Vector2[] flippedUV = mesh.uv;

		Vector3[] normals = mesh.normals;

		for (int i = 0; i < normals.Length; i++) {
			//if (i % 3 == 0)
				normals [i] *= -1;
		}

		for (int i = 0; i < flippedUV.Length; i++) {
			flippedUV [i].x = 1 - flippedUV [i].x; 
		}

		mesh.normals = normals;
		mesh.uv = flippedUV;

		for (int i = 0; i < mesh.subMeshCount; i++) {
			int[] tris = mesh.GetTriangles (i);
			for (int j = 0; j < tris.Length; j += 3) {
				//int temp1 = tris [j];
				int temp = tris [j];
				tris [j] = tris [j + 2];
				//tris [j + 1] = tris [j + 2];
				tris [j + 2] = temp;
			}

			mesh.SetTriangles (tris, i);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
