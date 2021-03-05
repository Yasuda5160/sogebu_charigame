using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CubeMesh : MonoBehaviour
{
    [SerializeField]
    private MeshFilter meshFilter;

    private Mesh mesh;
    private List<Vector3> vertextList = new List<Vector3>();
    private List<Vector2> uvList = new List<Vector2>();
    private List<int> indexList = new List<int>();

    void Start()
    {
        CreateCube();
    }

	private void CreateCube()
	{
		/*int n = 10;
		int s = n * n - (n - 1) * (n - 1);
		Vector3[] vertices = new Vector3[s];
		vertices[0] = new Vector3(0, 0, 0);
		vertices[1] = new Vector3(1, 0, 0);
		vertices[2] = new Vector3(1, 1, 0);
		vertices[3] = new Vector3(0, 1, 0);
		for (int k = 0; k < n; k++)
        {
			for (int j = 0; j < n; j++)
            {
				for (int i = 0; i < n; i++)
                {
					vertices[4 + i + j + k] = new Vector3(1 + i, j, k);
					vertices[5 + i + j + k] = new Vector3(0, 0, 0);
					vertices[6 + i + j + k] = new Vector3(0, 0, 0);
				}
            }
        }*/

		Vector3[] vertices = {
			new Vector3 (0, 0, 0),
			new Vector3 (3, 0, 0),
			new Vector3 (3, 3, 0),
			new Vector3 (0, 3, 0),
			new Vector3 (0, 3, 3),
			new Vector3 (3, 3, 3),
			new Vector3 (3, 0, 3),
			new Vector3 (0, 0, 3),
		};

		int[] triangles = {
			0, 2, 1, //face front
			0, 3, 2,
			2, 3, 4, //face top
			2, 4, 5,
			1, 2, 5, //face right
			1, 5, 6,
			0, 7, 4, //face left
			0, 4, 3,
			5, 4, 7, //face back
			5, 7, 6,
			0, 6, 7, //face bottom
			0, 1, 6
		};

		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.Clear();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.Optimize();
		mesh.RecalculateNormals();
	}
}
