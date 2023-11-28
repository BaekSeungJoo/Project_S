using UnityEngine;
using UnityEngine.UI;

public class QuestMarker : MonoBehaviour
{
    public Text questDirectionText; // ����Ʈ ������ ��Ÿ���� UI �ؽ�Ʈ
    public Text distanceText; // NPC���� �Ÿ��� ��Ÿ���� UI �ؽ�Ʈ
    public Transform questTarget; // ����Ʈ ��� NPC�� Transform

    void Update()
    {
        UpdateUIPosition();
        UpdateDistance();
    }

    void UpdateUIPosition()
    {
        // �÷��̾��� �þ� �ٷ� ������ UI ��� �̵�
        Vector3 playerPosition = transform.position;
        Vector3 playerForward = transform.forward;
        float distance = 2f; // ǥ���� �Ÿ� ���� ����

        Vector3 newPosition = playerPosition + playerForward * distance;
        transform.position = newPosition;
        transform.rotation = Quaternion.LookRotation(playerForward);
    }

    void UpdateDistance()
    {
        // NPC�� �÷��̾� ������ �Ÿ� ��� �� UI ������Ʈ
        if (questTarget != null)
        {
            float distance = Vector3.Distance(transform.position, questTarget.position);
            distanceText.text = $"Distance: {distance:F2} units"; // ���ϴ� �������� �Ÿ� ǥ��
        }
    }
}
