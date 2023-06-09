

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class TextureFix : MonoBehaviour
{
    public Material material;
    void Update()
    {// Get the mesh filter component on the object
      MeshFilter meshFilter = GetComponent<MeshFilter>();

      // Get the mesh on the object
      Mesh mesh = meshFilter.mesh;

      // Get the bounds of the mesh
      Bounds bounds = mesh.bounds;

      // Calculate the size of the object
      Vector3 size = bounds.size;

      // Set the tiling values based on the size of the object
      material.mainTextureScale = new Vector2(size.x/2, size.y/2);
    }
}
