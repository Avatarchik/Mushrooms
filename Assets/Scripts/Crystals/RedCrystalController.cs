using UnityEngine;
using System.Collections;

public class RedCrystalController : MonoBehaviour {

    [SerializeField]
    private QuestController _QuestController;
    
    void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
        {
            _QuestController.CollectRedCrystal();
            Destroy(gameObject);
        }
    }
}
