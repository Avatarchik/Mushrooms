using UnityEngine;
using System.Collections;

public class RedCrystalController : MonoBehaviour {

    [SerializeField]
    private QuestController _QuestController;
    
    void OnTriggerEnter(Collider other)
    {
        _QuestController.CollectRedCrystal();
        Destroy(gameObject);
    }
}
