Public Class MainMenu
    Inherits BaseScreen
    Private Entries As New List(Of MenuEntry)
    Private MenuSelect As Integer = 0
    Private MenuSize As New Vector2(250, 160)
    Private MenuPos As New Vector2(380, 80)
    Public Sub New()
        Name = "MainMenu"
        State = ScreenState.Active
        AddEntry("New Game", True)
        AddEntry("Options", True)
        AddEntry("Credits", True)
        AddEntry("Quit Game", True)

        If GameObj.Achieved Then GameObj.Achievement("Open The Game!", "You opened the game for the first time.")
    End Sub
    Public Sub AddEntry(text As String, enabled As Boolean)
        Dim Entry As MenuEntry
        Entry = New MenuEntry
        With Entry
            .Text = text
            .Enabled = enabled
        End With
        Entries.Add(Entry)
    End Sub
    Public Overrides Sub HandleInput()
        If Input.pGA_Up Then
            MenuSelect -= 1
            If MenuSelect < 0 Then MenuSelect = Entries.Count - 1
            Do Until Entries(MenuSelect).Enabled = True
                MenuSelect -= 1
                If MenuSelect < 0 Then MenuSelect = Entries.Count - 1
            Loop
        End If
        If Input.pGA_Down Then
            MenuSelect += 1
            If MenuSelect > Entries.Count - 1 Then MenuSelect = 0
            Do Until Entries(MenuSelect).Enabled = True
                MenuSelect += 1
                If MenuSelect > Entries.Count - 1 Then MenuSelect = 0
            Loop
        End If
        If Input.pGA_Forward Then
            Select Case MenuSelect
                Case 0
                    ScreenManager.RemoveScreen("TitleScreen")
                    ScreenManager.RemoveScreen("MainMenu")
                    ScreenManager.AddScreen(New Default_Screen())
                Case 1
                    ScreenManager.RemoveScreen("TitleScreen")
                    ScreenManager.RemoveScreen("MainMenu")
                    ScreenManager.AddScreen(New Options())
                Case 2
                    ScreenManager.RemoveScreen("TitleScreen")
                    ScreenManager.RemoveScreen("MainMenu")
                    ScreenManager.AddScreen(New Credits())
                Case 3
                    End
            End Select
        End If
        If Input.pGA_Turbo Then
            GameObj.Achieved = True
        End If
    End Sub
    Public Overrides Sub Draw()

        GameObj.DrawMenu(MenuSelect, Entries, MenuSize, MenuPos, 2, 0)

        GameObj.DrawLetter(New Vector2(0, 220), GameVersion.Vers(), Color.Red, 0, 1)


    End Sub
End Class