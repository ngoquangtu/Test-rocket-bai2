
using UnityEngine;
public class InstancingCubes : MonoBehaviour
{
    [SerializeField] private int gridSize = 100;
    [SerializeField] private float spacing = 2f;
    [SerializeField] private Mesh meshCubes;
    [SerializeField] private Material materialCubes;
    private Matrix4x4[] matrices;

    private void Update()
    {
        matrices = new Matrix4x4[gridSize * gridSize];
        int k = 0;
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                float xPos = x * spacing;
                float yPos = Random.Range(0f, 2f);
                float zPos = z * spacing;
                Vector3 position = new Vector3(xPos, yPos, zPos);
                Quaternion rotation = Quaternion.identity;
                Vector3 scale = Vector3.one;
                matrices[x * gridSize + z] = Matrix4x4.TRS(position, rotation, scale);

            }
        }
        Graphics.DrawMeshInstanced(meshCubes, 0, materialCubes, matrices);
    }
}
