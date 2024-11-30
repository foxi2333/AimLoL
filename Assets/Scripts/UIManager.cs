using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ammoText; // Текст для кількості патронів
    public Text magazineText; // Текст для кількості магазинів
    public GameObject reloadingIndicator; // Індикатор перезарядки

    // Оновлення кількості патронів на екрані
    public void UpdateAmmoCount(int currentAmmo, int maxAmmo)
    {
        ammoText.text = currentAmmo + " / " + maxAmmo;
    }

    // Оновлення кількості магазинів на екрані
    public void UpdateMagazineCount(int remainingMagazines, int maxMagazines)
    {
        magazineText.text = remainingMagazines + " / " + maxMagazines;
    }

    // Показує чи ховає індикатор перезарядки
    public void ShowReloading(bool isReloading)
    {
        reloadingIndicator.SetActive(isReloading);
    }
}