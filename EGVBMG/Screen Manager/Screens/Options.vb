Public Class Options
    Inherits BaseScreen

    Private Entries As New List(Of MenuEntry)
    Private MenuSelect As Integer = 0
    Dim MenuCD As Integer = 0

    Private MenuSize As New Vector2(250, 160)
    Private MenuPos As New Vector2(380, 80)

    Public Sub New()
        Name = "Options"
        State = ScreenState.Active

        ' ADD ENTRIES HERE
        AddEntry("Difficulty: Easy", True)
        AddEntry("Vsync: " & Vsync.Synced, True)
        AddEntry("Back To Main", True)
        AddEntry("Debug: 'F1'", False)
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
        ' MENU UP
        If Input.pGA_Up Then
            MenuSelect -= 1
            If MenuSelect < 0 Then MenuSelect = Entries.Count - 1
            ' SKIP DISABLED ENTRIES
            Do Until Entries(MenuSelect).Enabled = True
                MenuSelect -= 1
                If MenuSelect < 0 Then MenuSelect = Entries.Count - 1
            Loop
        End If

        ' MENU DOWN
        If Input.pGA_Down Then
            MenuSelect += 1
            If MenuSelect > Entries.Count - 1 Then MenuSelect = 0
            ' SKIP DISABLED ENTRIES
            Do Until Entries(MenuSelect).Enabled = True
                MenuSelect += 1
                If MenuSelect > Entries.Count - 1 Then MenuSelect = 0
            Loop
        End If


        ' INVOKE MENU ITEM
        If Input.pGA_Forward Then
            Select Case MenuSelect
                Case 0

                Case 1
                    Vsync.Switch()
                    Entries(MenuSelect).Text = "Vsync: " & Vsync.Synced
                Case 2
                    ScreenManager.RemoveScreen("Options")
                    ScreenManager.AddScreen(New TitleScreen())
                    ScreenManager.AddScreen(New MainMenu())
            End Select
        End If
    End Sub

    Public Overrides Sub Draw()
        Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(0, 0, Globals.BackBuffer.Width, Globals.BackBuffer.Height), New Color(100, 0, 200))

        GameObj.DrawLetter(New Vector2(10, 10), "Options", Color.Red, 0, 2)

        GameObj.DrawMenu(MenuSelect, Entries, MenuSize, MenuPos, 1, 1)

    End Sub
End Class
