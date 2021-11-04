// GENERATED AUTOMATICALLY FROM 'Assets/Controls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Tetris.Controls
{
    public class @PlayerControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerOneControls"",
            ""id"": ""88435101-998a-4ab3-9e30-25af8c207168"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""59022b9f-9aa1-4391-acbe-6ae17a26ab86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""e1ab0af2-538c-4d23-8a43-a2e0af636618"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""e7136333-1fae-4d87-94e3-208a32b7a793"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""ad26b6ff-cb62-4f2e-937b-58500ba8a225"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""403b2339-4606-4406-b3e0-c650fc087bfa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8516cd45-64ea-4bfd-99ee-084d85175f24"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7196cc6e-c354-4f68-8ba7-413dc5097a8c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c0084d5-3e93-407a-b846-03c3706c6a20"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f72283c-75d6-47fd-8c85-39c7e5bf0bbc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db6e9039-ed9b-4e6b-857f-e8a07d895fa6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerOneControls
            m_PlayerOneControls = asset.FindActionMap("PlayerOneControls", throwIfNotFound: true);
            m_PlayerOneControls_Left = m_PlayerOneControls.FindAction("Left", throwIfNotFound: true);
            m_PlayerOneControls_Right = m_PlayerOneControls.FindAction("Right", throwIfNotFound: true);
            m_PlayerOneControls_Down = m_PlayerOneControls.FindAction("Down", throwIfNotFound: true);
            m_PlayerOneControls_Rotate = m_PlayerOneControls.FindAction("Rotate", throwIfNotFound: true);
            m_PlayerOneControls_Pause = m_PlayerOneControls.FindAction("Pause", throwIfNotFound: true);
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

        // PlayerOneControls
        private readonly InputActionMap m_PlayerOneControls;
        private IPlayerOneControlsActions m_PlayerOneControlsActionsCallbackInterface;
        private readonly InputAction m_PlayerOneControls_Left;
        private readonly InputAction m_PlayerOneControls_Right;
        private readonly InputAction m_PlayerOneControls_Down;
        private readonly InputAction m_PlayerOneControls_Rotate;
        private readonly InputAction m_PlayerOneControls_Pause;
        public struct PlayerOneControlsActions
        {
            private @PlayerControls m_Wrapper;
            public PlayerOneControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Left => m_Wrapper.m_PlayerOneControls_Left;
            public InputAction @Right => m_Wrapper.m_PlayerOneControls_Right;
            public InputAction @Down => m_Wrapper.m_PlayerOneControls_Down;
            public InputAction @Rotate => m_Wrapper.m_PlayerOneControls_Rotate;
            public InputAction @Pause => m_Wrapper.m_PlayerOneControls_Pause;
            public InputActionMap Get() { return m_Wrapper.m_PlayerOneControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerOneControlsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerOneControlsActions instance)
            {
                if (m_Wrapper.m_PlayerOneControlsActionsCallbackInterface != null)
                {
                    @Left.started -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnLeft;
                    @Left.performed -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnLeft;
                    @Left.canceled -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnLeft;
                    @Right.started -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnRight;
                    @Right.performed -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnRight;
                    @Right.canceled -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnRight;
                    @Down.started -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnDown;
                    @Down.performed -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnDown;
                    @Down.canceled -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnDown;
                    @Rotate.started -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnRotate;
                    @Rotate.performed -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnRotate;
                    @Rotate.canceled -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnRotate;
                    @Pause.started -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnPause;
                    @Pause.performed -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnPause;
                    @Pause.canceled -= m_Wrapper.m_PlayerOneControlsActionsCallbackInterface.OnPause;
                }
                m_Wrapper.m_PlayerOneControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Left.started += instance.OnLeft;
                    @Left.performed += instance.OnLeft;
                    @Left.canceled += instance.OnLeft;
                    @Right.started += instance.OnRight;
                    @Right.performed += instance.OnRight;
                    @Right.canceled += instance.OnRight;
                    @Down.started += instance.OnDown;
                    @Down.performed += instance.OnDown;
                    @Down.canceled += instance.OnDown;
                    @Rotate.started += instance.OnRotate;
                    @Rotate.performed += instance.OnRotate;
                    @Rotate.canceled += instance.OnRotate;
                    @Pause.started += instance.OnPause;
                    @Pause.performed += instance.OnPause;
                    @Pause.canceled += instance.OnPause;
                }
            }
        }
        public PlayerOneControlsActions @PlayerOneControls => new PlayerOneControlsActions(this);
        public interface IPlayerOneControlsActions
        {
            void OnLeft(InputAction.CallbackContext context);
            void OnRight(InputAction.CallbackContext context);
            void OnDown(InputAction.CallbackContext context);
            void OnRotate(InputAction.CallbackContext context);
            void OnPause(InputAction.CallbackContext context);
        }
    }
}
