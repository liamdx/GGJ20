// GENERATED AUTOMATICALLY FROM 'Assets/Widgets/MainMenu_Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainMenu_Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainMenu_Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainMenu_Controls"",
    ""maps"": [
        {
            ""name"": ""MainMenu"",
            ""id"": ""f80e9043-2458-476f-ba43-0266b82627f0"",
            ""actions"": [
                {
                    ""name"": ""PlayGame"",
                    ""type"": ""Button"",
                    ""id"": ""43f19491-4ccb-40f0-976d-96c5845156ca"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dee8f570-2a41-4d5b-8c6a-f210b5867773"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""MenuScheme"",
                    ""action"": ""PlayGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MenuScheme"",
            ""bindingGroup"": ""MenuScheme"",
            ""devices"": []
        }
    ]
}");
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_PlayGame = m_MainMenu.FindAction("PlayGame", throwIfNotFound: true);
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

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_PlayGame;
    public struct MainMenuActions
    {
        private @MainMenu_Controls m_Wrapper;
        public MainMenuActions(@MainMenu_Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayGame => m_Wrapper.m_MainMenu_PlayGame;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @PlayGame.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPlayGame;
                @PlayGame.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPlayGame;
                @PlayGame.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPlayGame;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlayGame.started += instance.OnPlayGame;
                @PlayGame.performed += instance.OnPlayGame;
                @PlayGame.canceled += instance.OnPlayGame;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
    private int m_MenuSchemeSchemeIndex = -1;
    public InputControlScheme MenuSchemeScheme
    {
        get
        {
            if (m_MenuSchemeSchemeIndex == -1) m_MenuSchemeSchemeIndex = asset.FindControlSchemeIndex("MenuScheme");
            return asset.controlSchemes[m_MenuSchemeSchemeIndex];
        }
    }
    public interface IMainMenuActions
    {
        void OnPlayGame(InputAction.CallbackContext context);
    }
}
