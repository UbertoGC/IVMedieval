//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/EntradaMovimiento.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InteraccionControles: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InteraccionControles()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""EntradaMovimiento"",
    ""maps"": [
        {
            ""name"": ""Interaccion"",
            ""id"": ""0ca510ae-c9b9-488b-b056-26ad1c6b40ed"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ed8eb06f-a72e-4143-88ca-de379e829fe2"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Salto"",
                    ""type"": ""PassThrough"",
                    ""id"": ""227fc311-9994-4386-82b4-499235e081c8"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Disparo"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8755a762-f0cc-45c8-a774-31d8e26b1750"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Flechas"",
                    ""id"": ""2c1c3c30-9e32-4fea-b3a8-71516ed7d1ae"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3dd13ddf-2d09-43c3-a805-9ebc97db3917"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""cfd0ebe8-53b2-47dc-8c67-6839f9dbedee"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8db30f94-1c74-4118-8d77-fa836526730d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Salto"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d08b8ace-b726-401e-a246-756fecf40fa4"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Disparo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Interaccion
        m_Interaccion = asset.FindActionMap("Interaccion", throwIfNotFound: true);
        m_Interaccion_Horizontal = m_Interaccion.FindAction("Horizontal", throwIfNotFound: true);
        m_Interaccion_Salto = m_Interaccion.FindAction("Salto", throwIfNotFound: true);
        m_Interaccion_Disparo = m_Interaccion.FindAction("Disparo", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Interaccion
    private readonly InputActionMap m_Interaccion;
    private List<IInteraccionActions> m_InteraccionActionsCallbackInterfaces = new List<IInteraccionActions>();
    private readonly InputAction m_Interaccion_Horizontal;
    private readonly InputAction m_Interaccion_Salto;
    private readonly InputAction m_Interaccion_Disparo;
    public struct InteraccionActions
    {
        private @InteraccionControles m_Wrapper;
        public InteraccionActions(@InteraccionControles wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_Interaccion_Horizontal;
        public InputAction @Salto => m_Wrapper.m_Interaccion_Salto;
        public InputAction @Disparo => m_Wrapper.m_Interaccion_Disparo;
        public InputActionMap Get() { return m_Wrapper.m_Interaccion; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteraccionActions set) { return set.Get(); }
        public void AddCallbacks(IInteraccionActions instance)
        {
            if (instance == null || m_Wrapper.m_InteraccionActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InteraccionActionsCallbackInterfaces.Add(instance);
            @Horizontal.started += instance.OnHorizontal;
            @Horizontal.performed += instance.OnHorizontal;
            @Horizontal.canceled += instance.OnHorizontal;
            @Salto.started += instance.OnSalto;
            @Salto.performed += instance.OnSalto;
            @Salto.canceled += instance.OnSalto;
            @Disparo.started += instance.OnDisparo;
            @Disparo.performed += instance.OnDisparo;
            @Disparo.canceled += instance.OnDisparo;
        }

        private void UnregisterCallbacks(IInteraccionActions instance)
        {
            @Horizontal.started -= instance.OnHorizontal;
            @Horizontal.performed -= instance.OnHorizontal;
            @Horizontal.canceled -= instance.OnHorizontal;
            @Salto.started -= instance.OnSalto;
            @Salto.performed -= instance.OnSalto;
            @Salto.canceled -= instance.OnSalto;
            @Disparo.started -= instance.OnDisparo;
            @Disparo.performed -= instance.OnDisparo;
            @Disparo.canceled -= instance.OnDisparo;
        }

        public void RemoveCallbacks(IInteraccionActions instance)
        {
            if (m_Wrapper.m_InteraccionActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInteraccionActions instance)
        {
            foreach (var item in m_Wrapper.m_InteraccionActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InteraccionActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InteraccionActions @Interaccion => new InteraccionActions(this);
    public interface IInteraccionActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnSalto(InputAction.CallbackContext context);
        void OnDisparo(InputAction.CallbackContext context);
    }
}
