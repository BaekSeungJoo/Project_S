using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    public Camera miniMapCamera; // �̴ϸ��� ���� ī�޶�
    public Transform player; // �÷��̾� ��ġ
    public Transform[] questLocations; // ����Ʈ ��ġ �迭
    public Transform[] enemyLocations; // �� ��ġ �迭

    public GameObject playerIcon; // �÷��̾� ������
    public GameObject questIcon; // ����Ʈ ������
    public GameObject enemyIcon; // �� ������

    void Update()
    {
        // �÷��̾� ������ ��ġ ������Ʈ
        Vector3 playerPosition = miniMapCamera.WorldToViewportPoint(player.position);
        playerIcon.transform.position = new Vector3(playerPosition.x, playerPosition.y, 0);

        // ����Ʈ ������ ��ġ ������Ʈ
        foreach (Transform quest in questLocations)
        {
            Vector3 questPos = miniMapCamera.WorldToViewportPoint(quest.position);
            questIcon.transform.position = new Vector3(questPos.x, questPos.y, 0);
        }

        // �� ������ ��ġ ������Ʈ
        foreach (Transform enemy in enemyLocations)
        {
            Vector3 enemyPos = miniMapCamera.WorldToViewportPoint(enemy.position);
            enemyIcon.transform.position = new Vector3(enemyPos.x, enemyPos.y, 0);
        }
    }
}