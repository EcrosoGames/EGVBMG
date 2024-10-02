Public Class Default_Screen
    Inherits BaseScreen
    Private AniTime As Double = 0
    Public Sub New()
        Name = "DefaultScreen"
        State = ScreenState.Active
    End Sub
    Dim ProgressD As Integer = 0
    Dim ProgressCD As Integer = 15
    Public Overrides Sub HandleInput()
        If Input.GA_Forward And ProgressCD = 0 Then
            ProgressCD = 15
            ProgressD += 1
        ElseIf Not Input.GA_Forward Then
            ProgressCD = 0
        End If
    End Sub
    Public Overrides Sub Update()
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If AniTime > 25 Then
            AniTime = 0
            ' If ProgressCD > 0 Then ProgressCD -= 1
        End If
    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(0, 0, Globals.BackBuffer.Width, Globals.BackBuffer.Height), New Color(0, 0, 0))
        Select Case ProgressD
            Case 0
                GameObj.Textbox(New Vector2(0, Globals.BackBuffer.Height - 63), "Testing GUI Textbox for 400x240", Color.White, 0, 1, 0, 0, 0)
            Case 1
                GameObj.Textbox(New Vector2(0, Globals.BackBuffer.Height - 63), "Want to Continue?", Color.White, 0, 1, 0, 0, 1)
            Case 2
                GameObj.Textbox(New Vector2(0, Globals.BackBuffer.Height - 63), "Want to Continue?", Color.White, 0, 1, 0, 0, 2)
            Case 3
                GameObj.Textbox(New Vector2(0, Globals.BackBuffer.Height - 63), "What would you like to do?", Color.White, 0, 1, 0, 0, 3)
            Case 4
                GameObj.Textbox(New Vector2(0, Globals.BackBuffer.Height - 63), "What would you like to do?", Color.White, 0, 1, 0, 0, 4)
            Case 5
                GameObj.Textbox(New Vector2(0, Globals.BackBuffer.Height - 63), "What would you like to do?", Color.White, 0, 1, 0, 0, 5)
            Case 6
                GameObj.Textbox(New Vector2(0, Globals.BackBuffer.Height - 63), "What will" & vbCrLf & "you" & vbCrLf & "do?", Color.White, 0, 1, 0, 0, 6)
            Case 7
                GameObj.Textbox(New Vector2(0, Globals.BackBuffer.Height - 63), "What will" & vbCrLf & "you" & vbCrLf & "do?", Color.White, 0, 1, 0, 0, 7)
            Case 8
                GameObj.Textbox(New Vector2(0, Globals.BackBuffer.Height - 63), "What will" & vbCrLf & "you" & vbCrLf & "do?", Color.White, 0, 1, 0, 0, 8)
            Case 9
                GameObj.Textbox(New Vector2(0, Globals.BackBuffer.Height - 63), "What will" & vbCrLf & "you" & vbCrLf & "do?", Color.White, 0, 1, 0, 0, 9)
            Case 10
                GameObj.Textbox(New Vector2(0, Globals.BackBuffer.Height - 63), "What will" & vbCrLf & "you" & vbCrLf & "do?", Color.White, 0, 1, 0, 0, 10)
            Case 11
                GameObj.Textbox(New Vector2(0, Globals.BackBuffer.Height - 63), "What will" & vbCrLf & "you" & vbCrLf & "do?", Color.White, 0, 1, 0, 0, 11)
            Case 12
                GameObj.Textbox(New Vector2(0, Globals.BackBuffer.Height - 63), "You" & vbCrLf & "Used Attack Name!" & vbCrLf & "...", Color.White, 0, 1, 0, 0, 0)
            Case 13

            Case 14

            Case 15

            Case 16

            Case 17

        End Select

    End Sub
End Class