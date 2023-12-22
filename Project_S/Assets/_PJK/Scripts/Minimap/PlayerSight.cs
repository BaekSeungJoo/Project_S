using UnityEngine;

public class PlayerSight : MonoBehaviour
{
    public MeshRenderer visionConeRenderer; // �þ߸� ��Ÿ�� �޽� ������
    public float visionAngle = 60f; // �þ� ����
    public float visionDistance = 10f; // �þ� �Ÿ�

    void Update()
    {
        DrawVisionCone();
    }

    void DrawVisionCone()
    {
        MeshFilter meshFilter = visionConeRenderer.GetComponent<MeshFilter>();
        Mesh visionMesh = new Mesh();

        int segments = 50; // �޽��� ���׸�Ʈ ��, ���� ����

        Vector3[] vertices = new Vector3[segments + 2];
        int[] triangles = new int[segments * 3];

        vertices[0] = Vector3.zero;
        float angleIncrement = visionAngle / segments;
        for (int i = 1; i <= segments + 1; i++)
        {
            float angle = angleIncrement * (i - 1);
            vertices[i] = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), 0f, Mathf.Sin(Mathf.Deg2Rad * angle)) * visionDistance;
        }

        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }

        visionMesh.vertices = vertices;
        visionMesh.triangles = triangles;

        meshFilter.mesh = visionMesh;
    }
}
