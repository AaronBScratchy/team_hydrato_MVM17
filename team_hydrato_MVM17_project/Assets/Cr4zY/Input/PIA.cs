//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Cr4zY/Input/PIA.inputactions
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

public partial class @PIA : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PIA()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PIA"",
    ""maps"": [
        {
            ""name"": ""World"",
            ""id"": ""3b51cfb1-ee51-4333-99e4-6ed252532f61"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""bbdb66ae-3122-4af5-9c94-9c524c268ca1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""17bc01fd-d4e8-4b63-82a6-e6b908d33e7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Value"",
                    ""id"": ""3d81d085-87d8-4a89-9cdf-de232ea3da8f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""8773aecb-0619-4510-809b-16b7436e7cce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""6a7fe2d1-7786-4e6a-8275-5958f42994fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CharacterSwitchFwd"",
                    ""type"": ""Button"",
                    ""id"": ""913010d6-0809-4eae-a1b2-32403825c83d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CharacterSwitchBack"",
                    ""type"": ""Button"",
                    ""id"": ""4751aab1-81b4-4661-9e1c-1476ecb96191"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""aff8269d-014b-46b3-83a1-c1794bbbf5b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""4281542d-97a0-417b-a5ce-c49e831a6a48"",
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
                    ""id"": ""a1888eac-bcb7-492f-9309-656947b9a0bc"",
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
                    ""id"": ""996c830d-ceef-491f-9595-1ddeb0b74a5b"",
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
                    ""id"": ""ba0eb31b-9882-4905-a77b-985e73647d66"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""b5115dc0-a00a-4935-85d3-73a35cab22f4"",
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
                    ""id"": ""4bc289da-88f9-4a46-b741-4cd9b9a4721a"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2dbfa895-4bfe-4949-ad2c-2058c2df7862"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""a2f8fa3c-ff2a-4394-a56c-0e792d8b8108"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3e9d9a1d-ac50-476b-a636-3d342204d053"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""150c3c26-9866-4a8f-be83-d07e7d956f70"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f5a1f89f-1be9-4dfe-a75d-52b13a2d37e2"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ce61efb-05fd-4761-8d6e-60af219d68dd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""562dab03-ef3e-4c0a-b3b4-4090170d6190"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e59a81a-a970-4d36-b7c1-1be315173971"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81f0e02e-0b77-4317-a431-ef8239dd8c31"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d525369e-5d3a-4fde-bb3a-da8a744ce32f"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ff91736-640c-42da-97ca-d54b31759da6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CharacterSwitchFwd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17372398-d4c4-4917-b8a2-0191de42b531"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CharacterSwitchBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""546a8663-2cdd-4f5a-8b88-04c2d794ce5c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b79bf2d5-9ad4-4ca8-b828-991b50802eed"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bc04d06-28a7-408b-a438-acf1cbf6851c"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""601b9f64-853d-4929-85cb-0940b3e38117"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebcc07db-a2ef-49f9-88a2-4b50418cf9e5"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aae6cc63-9065-4eea-8838-73875380de16"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""BrokenHorn"",
            ""id"": ""9d00d2b6-cb15-4270-a9fc-eaade6ef4f2f"",
            ""actions"": [
                {
                    ""name"": ""HornExclusive"",
                    ""type"": ""Button"",
                    ""id"": ""6e8224d9-60f3-42cc-bf24-9fad5857941e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3a6b80f5-c9d4-4c4a-ab34-f8e66926bae9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""09bfe964-d384-4dee-8c05-685b188d1d77"",
                    ""path"": ""<Keyboard>/comma"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HornExclusive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4bfd7129-a9fd-47c3-8550-540173ebade3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c79b521f-6dd8-4216-9e52-fb85420cb1ee"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d44d41a-7b08-47b4-86a9-433326ac997a"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0eff897f-9a98-4155-b383-41be14648e88"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fafe5c9-a74d-4de2-b25f-d72a90823ea7"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Scythe"",
            ""id"": ""db3388b7-dc1a-4554-a723-eb00efb4b1ac"",
            ""actions"": [
                {
                    ""name"": ""Ability1"",
                    ""type"": ""Button"",
                    ""id"": ""6942f9d5-f4dc-4289-b1a0-a9b543daf142"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""929627db-64a7-4f4a-b5e5-feafeec2779b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8dd96f13-10fb-4196-8d93-41327fed8f68"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82be913c-75f9-491d-b197-42574fd8a99b"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e585f6cd-1af3-4e81-9ba7-15ee5cf3e658"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73fb611f-56c0-4263-82f4-0fc71ac9d658"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""491c24ac-9dcf-4f1e-bbda-910135aa6981"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50582490-14b7-4055-bc61-0ec770932ddd"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e9d7124-e7be-4c2f-8f47-bae5052d34d0"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // World
        m_World = asset.FindActionMap("World", throwIfNotFound: true);
        m_World_Horizontal = m_World.FindAction("Horizontal", throwIfNotFound: true);
        m_World_Jump = m_World.FindAction("Jump", throwIfNotFound: true);
        m_World_Vertical = m_World.FindAction("Vertical", throwIfNotFound: true);
        m_World_Crouch = m_World.FindAction("Crouch", throwIfNotFound: true);
        m_World_Exit = m_World.FindAction("Exit", throwIfNotFound: true);
        m_World_CharacterSwitchFwd = m_World.FindAction("CharacterSwitchFwd", throwIfNotFound: true);
        m_World_CharacterSwitchBack = m_World.FindAction("CharacterSwitchBack", throwIfNotFound: true);
        m_World_Attack = m_World.FindAction("Attack", throwIfNotFound: true);
        // BrokenHorn
        m_BrokenHorn = asset.FindActionMap("BrokenHorn", throwIfNotFound: true);
        m_BrokenHorn_HornExclusive = m_BrokenHorn.FindAction("HornExclusive", throwIfNotFound: true);
        m_BrokenHorn_Jump = m_BrokenHorn.FindAction("Jump", throwIfNotFound: true);
        // Scythe
        m_Scythe = asset.FindActionMap("Scythe", throwIfNotFound: true);
        m_Scythe_Ability1 = m_Scythe.FindAction("Ability1", throwIfNotFound: true);
        m_Scythe_Jump = m_Scythe.FindAction("Jump", throwIfNotFound: true);
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

    // World
    private readonly InputActionMap m_World;
    private IWorldActions m_WorldActionsCallbackInterface;
    private readonly InputAction m_World_Horizontal;
    private readonly InputAction m_World_Jump;
    private readonly InputAction m_World_Vertical;
    private readonly InputAction m_World_Crouch;
    private readonly InputAction m_World_Exit;
    private readonly InputAction m_World_CharacterSwitchFwd;
    private readonly InputAction m_World_CharacterSwitchBack;
    private readonly InputAction m_World_Attack;
    public struct WorldActions
    {
        private @PIA m_Wrapper;
        public WorldActions(@PIA wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_World_Horizontal;
        public InputAction @Jump => m_Wrapper.m_World_Jump;
        public InputAction @Vertical => m_Wrapper.m_World_Vertical;
        public InputAction @Crouch => m_Wrapper.m_World_Crouch;
        public InputAction @Exit => m_Wrapper.m_World_Exit;
        public InputAction @CharacterSwitchFwd => m_Wrapper.m_World_CharacterSwitchFwd;
        public InputAction @CharacterSwitchBack => m_Wrapper.m_World_CharacterSwitchBack;
        public InputAction @Attack => m_Wrapper.m_World_Attack;
        public InputActionMap Get() { return m_Wrapper.m_World; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WorldActions set) { return set.Get(); }
        public void SetCallbacks(IWorldActions instance)
        {
            if (m_Wrapper.m_WorldActionsCallbackInterface != null)
            {
                @Horizontal.started -= m_Wrapper.m_WorldActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_WorldActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_WorldActionsCallbackInterface.OnHorizontal;
                @Jump.started -= m_Wrapper.m_WorldActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_WorldActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_WorldActionsCallbackInterface.OnJump;
                @Vertical.started -= m_Wrapper.m_WorldActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_WorldActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_WorldActionsCallbackInterface.OnVertical;
                @Crouch.started -= m_Wrapper.m_WorldActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_WorldActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_WorldActionsCallbackInterface.OnCrouch;
                @Exit.started -= m_Wrapper.m_WorldActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_WorldActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_WorldActionsCallbackInterface.OnExit;
                @CharacterSwitchFwd.started -= m_Wrapper.m_WorldActionsCallbackInterface.OnCharacterSwitchFwd;
                @CharacterSwitchFwd.performed -= m_Wrapper.m_WorldActionsCallbackInterface.OnCharacterSwitchFwd;
                @CharacterSwitchFwd.canceled -= m_Wrapper.m_WorldActionsCallbackInterface.OnCharacterSwitchFwd;
                @CharacterSwitchBack.started -= m_Wrapper.m_WorldActionsCallbackInterface.OnCharacterSwitchBack;
                @CharacterSwitchBack.performed -= m_Wrapper.m_WorldActionsCallbackInterface.OnCharacterSwitchBack;
                @CharacterSwitchBack.canceled -= m_Wrapper.m_WorldActionsCallbackInterface.OnCharacterSwitchBack;
                @Attack.started -= m_Wrapper.m_WorldActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_WorldActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_WorldActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_WorldActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
                @CharacterSwitchFwd.started += instance.OnCharacterSwitchFwd;
                @CharacterSwitchFwd.performed += instance.OnCharacterSwitchFwd;
                @CharacterSwitchFwd.canceled += instance.OnCharacterSwitchFwd;
                @CharacterSwitchBack.started += instance.OnCharacterSwitchBack;
                @CharacterSwitchBack.performed += instance.OnCharacterSwitchBack;
                @CharacterSwitchBack.canceled += instance.OnCharacterSwitchBack;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public WorldActions @World => new WorldActions(this);

    // BrokenHorn
    private readonly InputActionMap m_BrokenHorn;
    private IBrokenHornActions m_BrokenHornActionsCallbackInterface;
    private readonly InputAction m_BrokenHorn_HornExclusive;
    private readonly InputAction m_BrokenHorn_Jump;
    public struct BrokenHornActions
    {
        private @PIA m_Wrapper;
        public BrokenHornActions(@PIA wrapper) { m_Wrapper = wrapper; }
        public InputAction @HornExclusive => m_Wrapper.m_BrokenHorn_HornExclusive;
        public InputAction @Jump => m_Wrapper.m_BrokenHorn_Jump;
        public InputActionMap Get() { return m_Wrapper.m_BrokenHorn; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BrokenHornActions set) { return set.Get(); }
        public void SetCallbacks(IBrokenHornActions instance)
        {
            if (m_Wrapper.m_BrokenHornActionsCallbackInterface != null)
            {
                @HornExclusive.started -= m_Wrapper.m_BrokenHornActionsCallbackInterface.OnHornExclusive;
                @HornExclusive.performed -= m_Wrapper.m_BrokenHornActionsCallbackInterface.OnHornExclusive;
                @HornExclusive.canceled -= m_Wrapper.m_BrokenHornActionsCallbackInterface.OnHornExclusive;
                @Jump.started -= m_Wrapper.m_BrokenHornActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BrokenHornActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BrokenHornActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_BrokenHornActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HornExclusive.started += instance.OnHornExclusive;
                @HornExclusive.performed += instance.OnHornExclusive;
                @HornExclusive.canceled += instance.OnHornExclusive;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public BrokenHornActions @BrokenHorn => new BrokenHornActions(this);

    // Scythe
    private readonly InputActionMap m_Scythe;
    private IScytheActions m_ScytheActionsCallbackInterface;
    private readonly InputAction m_Scythe_Ability1;
    private readonly InputAction m_Scythe_Jump;
    public struct ScytheActions
    {
        private @PIA m_Wrapper;
        public ScytheActions(@PIA wrapper) { m_Wrapper = wrapper; }
        public InputAction @Ability1 => m_Wrapper.m_Scythe_Ability1;
        public InputAction @Jump => m_Wrapper.m_Scythe_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Scythe; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ScytheActions set) { return set.Get(); }
        public void SetCallbacks(IScytheActions instance)
        {
            if (m_Wrapper.m_ScytheActionsCallbackInterface != null)
            {
                @Ability1.started -= m_Wrapper.m_ScytheActionsCallbackInterface.OnAbility1;
                @Ability1.performed -= m_Wrapper.m_ScytheActionsCallbackInterface.OnAbility1;
                @Ability1.canceled -= m_Wrapper.m_ScytheActionsCallbackInterface.OnAbility1;
                @Jump.started -= m_Wrapper.m_ScytheActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ScytheActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ScytheActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_ScytheActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Ability1.started += instance.OnAbility1;
                @Ability1.performed += instance.OnAbility1;
                @Ability1.canceled += instance.OnAbility1;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public ScytheActions @Scythe => new ScytheActions(this);
    public interface IWorldActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
        void OnCharacterSwitchFwd(InputAction.CallbackContext context);
        void OnCharacterSwitchBack(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
    public interface IBrokenHornActions
    {
        void OnHornExclusive(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IScytheActions
    {
        void OnAbility1(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
