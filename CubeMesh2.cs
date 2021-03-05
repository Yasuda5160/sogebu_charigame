using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CubeMesh2 : MonoBehaviour
{
    [SerializeField] private Vector3 size = new Vector3(5, 4, 3);
    [SerializeField] private Vector3Int segment = new Vector3Int(5, 4, 3);

    private void Awake()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Vector3Int extendedSeg = segment + Vector3Int.one;
        Vector3[] vertices = new Vector3[2 * ((extendedSeg.x * extendedSeg.y) + (extendedSeg.y * extendedSeg.z) + (extendedSeg.z * extendedSeg.x))];
        int[] triangles = new int[(segment.x * segment.y + segment.y * segment.z + segment.z * segment.x) * 2 * 2 * 3];

        int vi = 0;
        int ti = 0;
        MakeNearPlane(vertices, triangles, ref vi, ref ti);
        MakeFarPlane(vertices, triangles, ref vi, ref ti);
        MakeRightPlane(vertices, triangles, ref vi, ref ti);
        MakeLeftPlane(vertices, triangles, ref vi, ref ti);
        MakeUpPlane(vertices, triangles, ref vi, ref ti);
        MakeDownPlane(vertices, triangles, ref vi, ref ti);

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    private void MakeNearPlane(Vector3[] vertices, int[] triangles, ref int vi, ref int ti)
    {
        Vector3 halfSize = size * 0.5f;
        Vector3 sizeStep = new Vector3(size.x / segment.x, size.y / segment.y, size.z / segment.z);

        int vj = 0;
        for (int y = 0; y < segment.y + 1; y++)
        {
            for (int x = 0; x < segment.x + 1; x++)
            {
                vertices[vi + vj++] = new Vector3(sizeStep.x * x - halfSize.x, sizeStep.y * y - halfSize.y, -halfSize.z);
            }
        }
        for (int y = 0; y < segment.y; y++)
        {
            for (int x = 0; x < segment.x; x++)
            {
                int v00 = vi + x + y * (segment.x + 1);
                int v10 = vi + (x + 1) + y * (segment.x + 1);
                int v01 = vi + x + (y + 1) * (segment.x + 1);
                int v11 = vi + (x + 1) + (y + 1) * (segment.x + 1);
                ti = MakeQuad(triangles, ti, v00, v10, v01, v11);
            }
        }
        vi += vj;
    }

    private void MakeFarPlane(Vector3[] vertices, int[] triangles, ref int vi, ref int ti)
    {
        Vector3 halfSize = size * 0.5f;
        Vector3 sizeStep = new Vector3(size.x / segment.x, size.y / segment.y, size.z / segment.z);

        int vj = 0;
        for (int y = 0; y < segment.y + 1; y++)
        {
            for (int x = 0; x < segment.x + 1; x++)
            {
                vertices[vi + vj++] = new Vector3(sizeStep.x * x - halfSize.x, sizeStep.y * y - halfSize.y, halfSize.z);
            }
        }
        for (int y = 0; y < segment.y; y++)
        {
            for (int x = 0; x < segment.x; x++)
            {
                int v00 = vi + x + y * (segment.x + 1);
                int v10 = vi + (x + 1) + y * (segment.x + 1);
                int v01 = vi + x + (y + 1) * (segment.x + 1);
                int v11 = vi + (x + 1) + (y + 1) * (segment.x + 1);
                ti = MakeQuad(triangles, ti, v00, v01, v10, v11);
            }
        }
        vi += vj;
    }

    private void MakeRightPlane(Vector3[] vertices, int[] triangles, ref int vi, ref int ti)
    {
        Vector3 halfSize = size * 0.5f;
        Vector3 sizeStep = new Vector3(size.x / segment.x, size.y / segment.y, size.z / segment.z);

        int vj = 0;
        for (int y = 0; y < segment.y + 1; y++)
        {
            for (int z = 0; z < segment.z + 1; z++)
            {
                vertices[vi + vj++] = new Vector3(halfSize.x, sizeStep.y * y - halfSize.y, sizeStep.z * z - halfSize.z);
            }
        }
        for (int y = 0; y < segment.y; y++)
        {
            for (int z = 0; z < segment.z; z++)
            {
                int v00 = vi + z + y * (segment.z + 1);
                int v10 = vi + (z + 1) + y * (segment.z + 1);
                int v01 = vi + z + (y + 1) * (segment.z + 1);
                int v11 = vi + (z + 1) + (y + 1) * (segment.z + 1);
                ti = MakeQuad(triangles, ti, v00, v10, v01, v11);
            }
        }
        vi += vj;
    }

    private void MakeLeftPlane(Vector3[] vertices, int[] triangles, ref int vi, ref int ti)
    {
        Vector3 halfSize = size * 0.5f;
        Vector3 sizeStep = new Vector3(size.x / segment.x, size.y / segment.y, size.z / segment.z);

        int vj = 0;
        for (int y = 0; y < segment.y + 1; y++)
        {
            for (int z = 0; z < segment.z + 1; z++)
            {
                vertices[vi + vj++] = new Vector3(-halfSize.x, sizeStep.y * y - halfSize.y, sizeStep.z * z - halfSize.z);
            }
        }
        for (int y = 0; y < segment.y; y++)
        {
            for (int z = 0; z < segment.z; z++)
            {
                int v00 = vi + z + y * (segment.z + 1);
                int v10 = vi + (z + 1) + y * (segment.z + 1);
                int v01 = vi + z + (y + 1) * (segment.z + 1);
                int v11 = vi + (z + 1) + (y + 1) * (segment.z + 1);
                ti = MakeQuad(triangles, ti, v00, v01, v10, v11);
            }
        }
        vi += vj;
    }

    private void MakeUpPlane(Vector3[] vertices, int[] triangles, ref int vi, ref int ti)
    {
        Vector3 halfSize = size * 0.5f;
        Vector3 sizeStep = new Vector3(size.x / segment.x, size.y / segment.y, size.z / segment.z);

        int vj = 0;

        for (int z = 0; z < segment.z + 1; z++)
        {
            for (int x = 0; x < segment.x + 1; x++)
            {
                vertices[vi + vj++] = new Vector3(sizeStep.x * x - halfSize.x, halfSize.y, sizeStep.z * z - halfSize.z);
            }
        }

        for (int z = 0; z < segment.z; z++)
        {
            for (int x = 0; x < segment.x; x++)
            {
                int v00 = vi + x + z * (segment.x + 1);
                int v10 = vi + (x + 1) + z * (segment.x + 1);
                int v01 = vi + x + (z + 1) * (segment.x + 1);
                int v11 = vi + (x + 1) + (z + 1) * (segment.x + 1);
                ti = MakeQuad(triangles, ti, v00, v10, v01, v11);
            }
        }
        vi += vj;
    }

    private void MakeDownPlane(Vector3[] vertices, int[] triangles, ref int vi, ref int ti)
    {
        Vector3 halfSize = size * 0.5f;
        Vector3 sizeStep = new Vector3(size.x / segment.x, size.y / segment.y, size.z / segment.z);

        int vj = 0;

        for (int z = 0; z < segment.z + 1; z++)
        {
            for (int x = 0; x < segment.x + 1; x++)
            {
                vertices[vi + vj++] = new Vector3(sizeStep.x * x - halfSize.x, -halfSize.y, sizeStep.z * z - halfSize.z);
            }
        }

        for (int z = 0; z < segment.z; z++)
        {
            for (int x = 0; x < segment.x; x++)
            {
                int v00 = vi + x + z * (segment.x + 1);
                int v10 = vi + (x + 1) + z * (segment.x + 1);
                int v01 = vi + x + (z + 1) * (segment.x + 1);
                int v11 = vi + (x + 1) + (z + 1) * (segment.x + 1);
                ti = MakeQuad(triangles, ti, v00, v01, v10, v11);
            }
        }
        vi += vj;
    }

    private int MakeQuad(int[] triangles, int ti, int v00, int v10, int v01, int v11)
    {
        triangles[ti] = v00;
        triangles[ti + 1] = triangles[ti + 5] = v01;
        triangles[ti + 2] = triangles[ti + 4] = v10;
        triangles[ti + 3] = v11;
        return ti + 6;
    }
}