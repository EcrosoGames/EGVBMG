Public Class Input
    Shared CurrentKeyState As KeyboardState
    Shared LastKeyState As KeyboardState
    Public Shared Sub Update()
        LastKeyState = CurrentKeyState
        CurrentKeyState = Keyboard.GetState
        LastGamepadState = CurrentGamepadState
        CurrentGamepadState = GamePad.GetState(PlayerIndex.One)
        If KeyDown(ActionUp) Or KeyDown(ActionUpAlt) Or ButtonDown(Buttons.LeftThumbstickUp) Or ButtonDown(Buttons.RightThumbstickUp) Or ButtonPressed(Buttons.DPadUp) Then
            GA_Up = True
        Else
            GA_Up = False
        End If
        If KeyDown(ActionDown) Or KeyDown(ActionDownAlt) Or ButtonDown(Buttons.LeftThumbstickDown) Or ButtonDown(Buttons.RightThumbstickDown) Or ButtonPressed(Buttons.DPadDown) Then
            GA_Down = True
        Else
            GA_Down = False
        End If
        If KeyDown(ActionLeft) Or KeyDown(ActionLeftAlt) Or ButtonDown(Buttons.LeftThumbstickLeft) Or ButtonDown(Buttons.RightThumbstickLeft) Or ButtonPressed(Buttons.DPadLeft) Then
            GA_Left = True
        Else
            GA_Left = False
        End If
        If KeyDown(ActionRight) Or KeyDown(ActionRightAlt) Or ButtonDown(Buttons.LeftThumbstickRight) Or ButtonDown(Buttons.RightThumbstickRight) Or ButtonPressed(Buttons.DPadRight) Then
            GA_Right = True
        Else
            GA_Right = False
        End If
        If KeyPressed(ActionSpace) Or KeyPressed(ActionMenuSel) Or ButtonPressed(Buttons.A) Then
            GA_Forward = True
        Else
            GA_Forward = False
        End If
        If KeyPressed(ActionMenuBack) Or ButtonPressed(Buttons.B) Then
            GA_Backward = True
        Else
            GA_Backward = False
        End If
        If KeyPressed(ActionShoot) Or ButtonPressed(Buttons.Y) Then
            GA_Shoot = True
        Else
            GA_Shoot = False
        End If
        If KeyPressed(ActionQuest) Or ButtonPressed(Buttons.X) Then
            GA_Quest = True
        Else
            GA_Quest = False
        End If
        If KeyPressed(ActionTablet) Or ButtonPressed(Buttons.Start) Then
            GA_Tablet = True
        Else
            GA_Tablet = False
        End If
        If KeyPressed(ActionOres) Or ButtonPressed(Buttons.LeftShoulder) Then
            GA_OreMenu = True
        Else
            GA_OreMenu = False
        End If
        If KeyDown(ActionShift) Or ButtonDown(Buttons.LeftTrigger) Then
            GA_Turbo = True
        Else
            GA_Turbo = False
        End If
        If KeyPressed(ActionReloadMods) Or ButtonPressed(Buttons.BigButton) Then
            GA_DevReload = True
        Else
            GA_DevReload = False
        End If
        If KeyPressed(ActionTab) Or ButtonPressed(Buttons.RightTrigger) Then
            GA_Cling = True
        Else
            GA_Cling = False
        End If
        If ButtonPressed(Buttons.RightShoulder) Or KeyPressed(ActionPew) Then
            GA_Pew = True
        Else
            GA_Pew = False
        End If

        If LastKeyState = CurrentKeyState And LastGamepadState = CurrentGamepadState Then
            pGA_Up = False
            pGA_Left = False
            pGA_Down = False
            pGA_Right = False
            pGA_Forward = False
            pGA_Backward = False
            pGA_Shoot = False
            pGA_Quest = False
            pGA_Tablet = False
            pGA_OreMenu = False
            pGA_Turbo = False
            pGA_DevReload = False
            pGA_Cling = False
            pGA_Pew = False
        Else
            pGA_Up = GA_Up
            pGA_Left = GA_Left
            pGA_Down = GA_Down
            pGA_Right = GA_Right
            pGA_Forward = GA_Forward
            pGA_Backward = GA_Backward
            pGA_Shoot = GA_Shoot
            pGA_Quest = GA_Quest
            pGA_Tablet = GA_Tablet
            pGA_OreMenu = GA_OreMenu
            pGA_Turbo = GA_Turbo
            pGA_DevReload = GA_DevReload
            pGA_Cling = GA_Cling
            pGA_Pew = GA_Pew
        End If

        If Mouse.GetState.LeftButton = ButtonState.Pressed Then
            MouseClicked = True
        ElseIf Mouse.GetState.LeftButton = ButtonState.Released And MouseClicked Then
            MouseClicked = False
        End If
        If Mouse.GetState.RightButton = ButtonState.Pressed Then
            MouseRClicked = True
        ElseIf Mouse.GetState.RightButton = ButtonState.Released And MouseRClicked Then
            MouseRClicked = False
        End If
        If MouseScrollState <> Mouse.GetState.ScrollWheelValue Then
            If MouseScrollState > Mouse.GetState.ScrollWheelValue Then
                MouseScroll = 1
            ElseIf MouseScrollState < Mouse.GetState.ScrollWheelValue Then
                MouseScroll = -1
            End If
            MouseScrollState = Mouse.GetState.ScrollWheelValue
        End If
        If Maths.CursorOnScreen Then
            MouseAbsPos = New Vector2(Mouse.GetState.Position.X / Globals.Graphics.GraphicsDevice.Viewport.Width, Mouse.GetState.Position.Y / Globals.Graphics.GraphicsDevice.Viewport.Height)
        Else
            MouseAbsPos = New Vector2(-1, -1)
        End If
    End Sub
    Public Shared Function KeyDown(key As Keys) As Boolean
        If GamepadAnalogBypass(key) Then
            Return True
        Else
            Return CurrentKeyState.IsKeyDown(key)
        End If
    End Function
    Public Shared Function KeyPressed(key As Keys) As Boolean
        If CurrentKeyState.IsKeyDown(key) And LastKeyState.IsKeyUp(key) Then
            Return True
        Else
            Return False
        End If
    End Function



    Public Shared Function ButtonDown(Button As Buttons) As Boolean
        Return CurrentGamepadState.IsButtonDown(Button)
    End Function
    Public Shared Function ButtonPressed(Button As Buttons) As Boolean
        If CurrentGamepadState.IsButtonDown(Button) And LastGamepadState.IsButtonUp(Button) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function KeyPoll() As Integer
        For q As Integer = 0 To 200
            If Input.KeyDown(q) Then
                Return q
                Exit For
            End If
        Next
        Return -1
    End Function
    Public Shared ActionUp As Integer = AscW("W")
    Public Shared ActionLeft As Integer = AscW("A")
    Public Shared ActionDown As Integer = AscW("S")
    Public Shared ActionRight As Integer = AscW("D")
    Public Shared ActionUpAlt As Integer = 38 'U
    Public Shared ActionLeftAlt As Integer = 37 'L
    Public Shared ActionDownAlt As Integer = 40 'D
    Public Shared ActionRightAlt As Integer = 39 'R
    Public Shared ActionMenuSel As Integer = 13 'ENTER
    Public Shared ActionMenuBack As Integer = 27 'ESC
    Public Shared ActionQuest As Integer = AscW("Q")
    Public Shared ActionTablet As Integer = AscW("L")
    Public Shared ActionShoot As Integer = AscW("Y")
    Public Shared ActionSpace As Integer = 32 'Space
    Public Shared ActionCharge As Integer = AscW("C")
    Public Shared ActionMine As Integer = AscW("M")
    Public Shared ActionShift As Integer = 160
    Public Shared ActionOres As Integer = AscW("O")
    Public Shared ActionTab As Integer = 9
    Public Shared ActionReloadMods As Integer = 116
    Public Shared ActionPew As Integer = 8 'Backspace

    Public Shared GA_Up As Boolean = False
    Public Shared GA_Left As Boolean = False
    Public Shared GA_Down As Boolean = False
    Public Shared GA_Right As Boolean = False
    Public Shared GA_Forward As Boolean = False
    Public Shared GA_Backward As Boolean = False
    Public Shared GA_Shoot As Boolean = False
    Public Shared GA_Quest As Boolean = False
    Public Shared GA_Tablet As Boolean = False
    Public Shared GA_OreMenu As Boolean = False
    Public Shared GA_Turbo As Boolean = False
    Public Shared GA_DevReload As Boolean = False
    Public Shared GA_Cling As Boolean = False
    Public Shared GA_Pew As Boolean = False

    Public Shared pGA_Up As Boolean = False
    Public Shared pGA_Left As Boolean = False
    Public Shared pGA_Down As Boolean = False
    Public Shared pGA_Right As Boolean = False
    Public Shared pGA_Forward As Boolean = False
    Public Shared pGA_Backward As Boolean = False
    Public Shared pGA_Shoot As Boolean = False
    Public Shared pGA_Quest As Boolean = False
    Public Shared pGA_Tablet As Boolean = False
    Public Shared pGA_OreMenu As Boolean = False
    Public Shared pGA_Turbo As Boolean = False
    Public Shared pGA_DevReload As Boolean = False
    Public Shared pGA_Cling As Boolean = False
    Public Shared pGA_Pew As Boolean = False

    Public Shared MouseClicked As Boolean = False
    Public Shared MouseRClicked As Boolean = False
    Public Shared MouseScroll As Integer = 0
    Public Shared MouseScrollState As Integer = 0
    Public Shared MouseAbsPos As Vector2

    Public Shared ControlType As Integer = 0 '0=KBM|1=XBC

    Shared CurrentGamepadState As GamePadState
    Shared LastGamepadState As GamePadState
    Public Shared Function GamepadBypass(key As Keys)
        If CurrentGamepadState <> LastGamepadState And CurrentKeyState = LastKeyState Then
            'Triggers
            If GamePad.GetState(PlayerIndex.One).Triggers.Left > 0 Then
                If key = ActionShift Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).Triggers.Right > 0 Then
                If key = ActionTab Then Return True
            End If
            'Small buttons
            If GamePad.GetState(PlayerIndex.One).Buttons.Start = ButtonState.Pressed Then
                If key = ActionTablet Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed Then

            End If
            If GamePad.GetState(PlayerIndex.One).Buttons.BigButton = ButtonState.Pressed Then
                If key = ActionReloadMods Then Return True
            End If
            'Letter Buttons
            If GamePad.GetState(PlayerIndex.One).Buttons.A = ButtonState.Pressed Then
                If key = ActionMenuSel Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).Buttons.B = ButtonState.Pressed Then
                If key = ActionMenuBack Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).Buttons.X = ButtonState.Pressed Then
                If key = ActionQuest Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).Buttons.Y = ButtonState.Pressed Then
                If key = ActionShoot Then Return True
            End If
            'Dpad
            If GamePad.GetState(PlayerIndex.One).DPad.Down = ButtonState.Pressed Then
                If key = ActionDown Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).DPad.Up = ButtonState.Pressed Then
                If key = ActionUp Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).DPad.Left = ButtonState.Pressed Then
                If key = ActionLeft Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).DPad.Right = ButtonState.Pressed Then
                If key = ActionRight Then Return True
            End If
            'Analog Sticks
            If GamePad.GetState(PlayerIndex.One).Buttons.LeftStick = ButtonState.Pressed Then
                If key = ActionCharge Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).Buttons.RightStick = ButtonState.Pressed Then
                If key = ActionMine Then Return True
            End If
            'Shoulders
            If GamePad.GetState(PlayerIndex.One).Buttons.LeftShoulder = ButtonState.Pressed Then
                If key = ActionOres Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder = ButtonState.Pressed Then
                If key = ActionSpace Then Return True
            End If
        End If
    End Function
    Public Shared Throttle As Single
    Public Shared Function GamepadAnalogBypass(key As Keys)
        'Triggers
        If GamePad.GetState(PlayerIndex.One).Triggers.Left > 0 Then
            If key = ActionShift Then Return True
        End If
        'Thunbstick L
        If GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0 Then
            If key = ActionLeft Then
                Throttle = 0.6 + Math.Abs(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X) * 0.5
                Return True
            End If
        ElseIf GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0 Then
            If key = ActionRight Then
                Throttle = 0.6 + Math.Abs(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X) * 0.5
                Return True
            End If
        End If
        If GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0 Then
            If key = ActionUp Then
                Throttle = 0.6 + Math.Abs(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y) * 0.5
                Return True
            End If
        ElseIf GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0 Then
            If key = ActionDown Then
                Throttle = 0.6 + Math.Abs(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y) * 0.5
                Return True
            End If
        End If
        'Thunbstick R
        If GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X < 0 Then
            If key = ActionLeftAlt Then Return True
        ElseIf GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X > 0 Then
            If key = ActionRightAlt Then Return True
        End If
        If GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y > 0 Then
            If key = ActionUpAlt Then Return True
        ElseIf GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y < 0 Then
            If key = ActionDownAlt Then Return True
        End If
        'Dpad backup
        If CurrentGamepadState <> LastGamepadState Then
            If GamePad.GetState(PlayerIndex.One).DPad.Down = ButtonState.Pressed Then
                If key = ActionDown Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).DPad.Up = ButtonState.Pressed Then
                If key = ActionUp Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).DPad.Left = ButtonState.Pressed Then
                If key = ActionLeft Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).DPad.Right = ButtonState.Pressed Then
                If key = ActionRight Then Return True
            End If
        End If
    End Function
End Class