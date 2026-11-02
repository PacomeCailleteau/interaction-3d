using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Attachment;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[DisallowMultipleComponent]
public class RayTurnLock : MonoBehaviour
{
    [SerializeField] private Behaviour[] turnProviders;

    private XRRayInteractor ray;
    private XRBaseInputInteractor interactor;
    private NearFarInteractor nearFar;
    private InteractionAttachController nearAttach;
    private bool[] previousStates;

    private void OnEnable()
    {
        ray = GetComponent<XRRayInteractor>();
        interactor = GetComponent<XRBaseInputInteractor>();
        nearFar = GetComponent<NearFarInteractor>();
        nearAttach = GetComponent<InteractionAttachController>();
        interactor.selectEntered.AddListener(OnSelectEntered);
        interactor.selectExited.AddListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        bool usesJoystick = ray ? ray.manipulateAttachTransform
            : nearFar && nearAttach && nearAttach.useManipulationInput && nearAttach.hasOffset;
        if (!usesJoystick || !(args.interactableObject is XRGrabInteractable) || previousStates != null)
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
        interactor.selectEntered.RemoveListener(OnSelectEntered);
        interactor.selectExited.RemoveListener(OnSelectExited);
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
