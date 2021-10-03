using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{

    private MeshFilter _meshFilter;
    
    public int gridSize = 16;
    public float size = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshFilter.mesh = GenerateMesh();
    }

    public void NewMesh(int newSize)
    {
        gridSize = newSize;
        _meshFilter.mesh = GenerateMesh();
    }
    
    private Mesh GenerateMesh()
    {
        var m = new Mesh();

        var vertices = new List<Vector3>();
        var normals = new List<Vector3>();
        var uvs = new List<Vector2>();

        for (var x = 0; x < gridSize + 1; x++)
        for (var y = 0; y < gridSize + 1; y++)
        {
            vertices.Add(new Vector3(-size * 0.5f + size * (x / (float) gridSize), 0,
                -size * 0.5f + size * (y / (float) gridSize)));
            normals.Add(Vector3.up);
            uvs.Add(new Vector2(x / (float) gridSize, y / (float) gridSize));
        }

        var triangles = new List<int>();
        var verticesCount = gridSize + 1;

        for (var i = 0; i < verticesCount * verticesCount - verticesCount; i++)
        {
            if ((i + 1) % verticesCount == 0) continue;
            triangles.AddRange(new List<int>
            {
                i + 1 + verticesCount, i + verticesCount, i, i, i + 1, i + verticesCount + 1
            });
        }

        m.SetVertices(vertices);
        m.SetNormals(normals);
        m.SetUVs(0, uvs);
        m.SetTriangles(triangles, 0);

        return m;
    }

    // Update is called once per frame
    void Update()
    {

        var pos = transform.position;
        
        var verts = _meshFilter.mesh.vertices;
        for (var i = 0; i < verts.Length; i++)
        {
            verts[i].y = Waver.Instance.GetWaveHeight(transform.position.x + verts[i].x, pos.z + verts[i].z);
        }

        _meshFilter.mesh.vertices = verts;
        _meshFilter.mesh.RecalculateNormals();
    }
}
