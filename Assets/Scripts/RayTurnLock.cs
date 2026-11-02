using System.Collections.Generic;
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
    private sealed class ProviderLock
    {
        public bool wasEnabled;
        public int users;
    }

    private static readonly Dictionary<Behaviour, ProviderLock> providerLocks = new Dictionary<Behaviour, ProviderLock>();
    private readonly List<Behaviour> heldProviders = new List<Behaviour>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetLocks() => providerLocks.Clear();

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
        if (!usesJoystick || !(args.interactableObject is XRGrabInteractable) || heldProviders.Count > 0)
            return;

        // Shared controls stay reserved until both hands have finished manipulating.
        foreach (var provider in turnProviders)
        {
            if (!provider || heldProviders.Contains(provider)) continue;
            if (!providerLocks.TryGetValue(provider, out var state))
            {
                state = new ProviderLock { wasEnabled = provider.enabled };
                providerLocks.Add(provider, state);
            }
            state.users++;
            heldProviders.Add(provider);
            provider.enabled = false;
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
        foreach (var provider in heldProviders)
        {
            if (!providerLocks.TryGetValue(provider, out var state)) continue;
            state.users--;
            if (state.users > 0) continue;
            if (provider) provider.enabled = state.wasEnabled;
            providerLocks.Remove(provider);
        }
        heldProviders.Clear();
    }
}
