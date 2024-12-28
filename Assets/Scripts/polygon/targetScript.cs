using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // �������� �� ����� ����������
    public Vector3 startPosition = new Vector3(-3.972f, 0.507f, 4.91f);
    public Vector3 endPosition = new Vector3(-7.063f, 0.507f, 4.91f);

    // �������� ���������� (������� �� �������)
    public float moveSpeed = 2f;

    // ³������ �� �������
    private float journeyLength;
    private float startTime;

    // ���������� ������ �� �����
    private bool movingTowardsEnd = true;

    void Start()
    {
        // ������������ ���������� ���������
        transform.position = startPosition; // ������������ ��������� �������
        journeyLength = Vector3.Distance(startPosition, endPosition); // ���������� �������
        startTime = Time.time; // �������� ��� ������� ����
    }

    void Update()
    {
        // ���, �� ������� � ������� ����
        float distanceCovered = (Time.time - startTime) * moveSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;

        if (movingTowardsEnd)
        {
            // ��������� ��'��� �� ����� ���� �� startPosition �� endPosition
            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
        }
        else
        {
            // ��������� ��'��� �� ����� ���� �� endPosition �� startPosition
            transform.position = Vector3.Lerp(endPosition, startPosition, fractionOfJourney);
        }

        // ���� ��'��� �������� ������ �����, ������� ��������
        if (fractionOfJourney >= 1f)
        {
            startTime = Time.time; // ��������� ��� ��� ������ �����
            movingTowardsEnd = !movingTowardsEnd; // ������� ��������
        }
    }
}
