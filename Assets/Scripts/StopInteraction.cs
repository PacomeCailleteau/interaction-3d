using UnityEngine;


public class StopInteraction : MonoBehaviour
{
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.IsStoped())
        {
            GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>().interactionLayers =
                LayerMask.GetMask("Nothing");
        }

        if (timer.IsReset())
        {
            Destroy(gameObject);
        }
    }
}
