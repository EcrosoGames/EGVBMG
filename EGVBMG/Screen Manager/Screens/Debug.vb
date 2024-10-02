Public Class Debug
    Inherits BaseScreen
    Public Shared Screens As String = ""
    Public FocusScreen As String = ""
    Private fps As Integer
    Private fpsCounter As Integer
    Private fpsTimer As Double
    Private fpsText As String = ""
    Private BGRect As Rectangle
    Private KeyDown As Boolean = False
    Public Sub New()
        Name = "Debug"
        State = ScreenState.Debug
        GrabFocus = False
        Permission = 5
    End Sub
    Public Overrides Sub HandleInput()
        If Input.KeyPressed(Keys.F1) Then
            If Globals.Debugging Then
                Globals.Debugging = False
            Else
                Globals.Debugging = True
            End If
        End If
        If Globals.Debugging Then
            If Input.KeyPressed(Keys.F2) Then
                Vsync.Switch()
            End If
            If Input.KeyPressed(Keys.F3) Then
                GameDeveloperKit.Show()
            End If
        End If
    End Sub
    Public Overrides Sub Update()
        MyBase.Update()
        If Screens.Length > 0 Then
            Screens = Screens.Substring(0, Screens.Length - 2)
        End If
        Dim txtWidth As Integer = 0
        Dim txtHeight As Integer = 0
        If Screens.Length * 10 > txtWidth Then
            txtWidth = Screens.Length * 10
        End If
        If Screens.Length * 10 > txtWidth Then
            txtWidth = Screens.Length * 10
        End If
        txtHeight = 50
        BGRect = New Rectangle(0, 0, txtWidth + 20, txtHeight + 20)
    End Sub
    Dim Spacing As Integer = 18
    Dim Xacing As Integer = 2
    Public Overrides Sub Draw()
        MyBase.Draw()
        If Globals.GameTime.TotalGameTime.TotalMilliseconds > fpsTimer Then
            fps = fpsCounter
            fpsTimer = Globals.GameTime.TotalGameTime.TotalMilliseconds + 1000
            fpsCounter = 1
            fpsText = "FPS: " & fps
        Else
            fpsCounter += 1
        End If
        GameObj.DrawLetter(New Vector2(Xacing, 2), fpsText, Color.White, 13, 1)
        GameObj.DrawLetter(New Vector2(Xacing, 20), "Screens: ", Color.White, 13, 1)
        For q As Integer = 0 To ScreenManager.Screens.Count - 1
            Select Case ScreenManager.Screens(q).State
                Case ScreenState.Active
                    GameObj.DrawLetter(New Vector2(Xacing, 36 + (q * Spacing)), ScreenManager.Screens(q).Name, Color.White, 13, 1)
                Case ScreenState.Shutdown 'Bug if can see this symbol/screen
                    GameObj.DrawLetter(New Vector2(Xacing, 36 + (q * Spacing)), ScreenManager.Screens(q).Name, Color.Red, 13, 1)
                Case ScreenState.Debug
                    GameObj.DrawLetter(New Vector2(Xacing, 36 + (q * Spacing)), ScreenManager.Screens(q).Name, Color.Gray, 13, 1)
                Case ScreenState.Paused
                    GameObj.DrawLetter(New Vector2(Xacing, 36 + (q * Spacing)), ScreenManager.Screens(q).Name, Color.Cyan, 13, 1)
                Case ScreenState.Disabled
                    GameObj.DrawLetter(New Vector2(Xacing, 36 + (q * Spacing)), ScreenManager.Screens(q).Name, Color.DarkRed, 13, 1)
                Case ScreenState.Privilaged
                    GameObj.DrawLetter(New Vector2(Xacing, 36 + (q * Spacing)), ScreenManager.Screens(q).Name, Color.Yellow, 13, 1)
            End Select
            ' GameObj.DrawLetter(New Vector2(10, 22 + (q * 12)), "Screens: ", Color.White, 0, 1)
        Next
        GameObj.DrawLetter(New Vector2(Xacing, 46 + (ScreenManager.Screens.Count * Spacing)), "Res:" & Globals.GameSize.X & "," & Globals.GameSize.Y, Color.White, 13, 1)
    End Sub
End Class