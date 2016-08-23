using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

    [SerializeField]
    private CanvasGroup _MessageCanvasGroup;

    public float Step = 0.01f;

    private bool _Running = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(_Running && _MessageCanvasGroup.alpha > 0)
        {
            _MessageCanvasGroup.alpha -= Step;
            if (_MessageCanvasGroup.alpha <= 0) {
                _MessageCanvasGroup.alpha = 0;
                _Running = false;
            }
        }
	}

    public void Run()
    {
        _MessageCanvasGroup.alpha = 1;
        _Running = true;
    }

    public void Stop()
    {
        _MessageCanvasGroup.alpha = 0;
        _Running = false;
    }

    public void Pause()
    {
        _Running = false;
    }
}
