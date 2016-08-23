using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

    [SerializeField]
    private Text _ScoreLabel;

    [SerializeField]
    private int _Score;

    public int Score { get { return _Score; } }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public void IncreaseScore(int value)
    {
        _Score += value;
        _ScoreLabel.text = "Score: " + _Score;
    }

}
