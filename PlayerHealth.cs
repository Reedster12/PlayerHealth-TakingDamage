using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public TextMeshProUGUI HealthUI;
    public Material playerMaterial;
    public Material playerDamagedMaterial;



    // Handling damage from ranged attacks
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile") || other.CompareTag("Blade"))
        {
            playerHealth -= 1;
            GetComponent<Renderer>().material = playerDamagedMaterial;
            Invoke("ResetMaterial", 0.5f);
        }
    }



    // Keep player's on-screen health updated
    public void Update()
    {
        HealthUI.text = playerHealth.ToString();
    }


    // Set the player's material back to normal
    void ResetMaterial()
    {
        GetComponent<Renderer>().material = playerMaterial;
    }
}
