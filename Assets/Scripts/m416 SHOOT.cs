using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m416SHOOT : MonoBehaviour
{
   
    

public class RifleReload : MonoBehaviour
{
    public int currentAmmo = 0;        // Поточна кількість патронів
    public int maxAmmo = 30;           // Максимальна кількість патронів в магазині
    public bool isReloading = false;   // Чи виконується перезарядка
    public float reloadTime = 2f;      // Час для перезарядки
    public Animator animator;          // Аніматор для гвинтівки

    void Update()
    {
        // Перевірка, чи патрони закінчились і натискання клавіші "R"
        if (currentAmmo == 0 && !isReloading && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    // Корутин для перезарядки
    IEnumerator Reload()
    {
        isReloading = true;

        // Запускаємо анімацію перезарядки
        animator.SetTrigger("Reload");

        // Чекаємо, поки анімація перезарядки завершиться
        yield return new WaitForSeconds(reloadTime);

        // Після завершення перезарядки, встановлюємо максимальну кількість патронів
        currentAmmo = maxAmmo;

        isReloading = false;
    }

    // Функція для стрільби (не обов'язкова, але для тесту)
    public void Shoot()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            // Тут додайте код для стрільби
        }
        else
        {
            Debug.Log("Патрони закінчились!");
        }
    }
}

}

