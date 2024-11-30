using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ammoText; // ����� ��� ������� �������
    public Text magazineText; // ����� ��� ������� ��������
    public GameObject reloadingIndicator; // ��������� �����������

    // ��������� ������� ������� �� �����
    public void UpdateAmmoCount(int currentAmmo, int maxAmmo)
    {
        ammoText.text = currentAmmo + " / " + maxAmmo;
    }

    // ��������� ������� �������� �� �����
    public void UpdateMagazineCount(int remainingMagazines, int maxMagazines)
    {
        magazineText.text = remainingMagazines + " / " + maxMagazines;
    }

    // ������ �� ���� ��������� �����������
    public void ShowReloading(bool isReloading)
    {
        reloadingIndicator.SetActive(isReloading);
    }
}