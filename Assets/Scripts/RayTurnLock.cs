using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRRayInteractor))]
public class RayTurnLock : MonoBehaviour
{
    [SerializeField] private Behaviour[] turnProviders;

    private XRRayInteractor ray;
    private bool[] previousStates;

    private void OnEnable()
    {
        ray = GetComponent<XRRayInteractor>();
        ray.selectEntered.AddListener(OnSelectEntered);
        ray.selectExited.AddListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!ray.manipulateAttachTransform || !(args.interactableObject is XRGrabInteractable) || previousStates != null)
            return;

        // The right stick manipulates the held block without also turning the player.
        previousStates = new bool[turnProviders.Length];
        for (int i = 0; i < turnProviders.Length; i++)
        {
            if (!turnProviders[i]) continue;
            previousStates[i] = turnProviders[i].enabled;
            turnProviders[i].enabled = false;
        }
    }

    private void OnSelectExited(SelectExitEventArgs args) => RestoreTurning();

    private void OnDisable()
    {
        ray.selectEntered.RemoveListener(OnSelectEntered);
        ray.selectExited.RemoveListener(OnSelectExited);
        RestoreTurning();
    }

    private void RestoreTurning()
    {
        if (previousStates == null) return;
        for (int i = 0; i < turnProviders.Length; i++)
            if (turnProviders[i]) turnProviders[i].enabled = previousStates[i];
        previousStates = null;
    }
}
