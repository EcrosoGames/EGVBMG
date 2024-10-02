Public Class Credits
    Inherits BaseScreen

    Private Entries As New List(Of MenuEntry)
    Private MenuSelect As Integer = 0

    Private MenuSize As New Vector2(250, 160)
    Private MenuPos As New Vector2(120, 80)
    Private AniTime As Double = 0
    Public Sub New()
        Name = "Credits"
        State = ScreenState.Active

        ' ADD ENTRIES HERE
        AddEntry("Back To Main", True)
        AddEntry("Engine By: Brandon Ecroso", False)
        AddEntry("Engine Based on", False)
        AddEntry("Aardaerimus D'Aritonyss' design", False)
        AddEntry("Textures By: " & GameVersion.Artist, False)

        AddEntry("Language: VB.NET (XNA 4.0 framework)", False)

        AddEntry("Version: EGVBMG ver. " & Engine_Version.Vers, False)

        AddEntry("Game by: " & GameVersion.Author, False)
        AddEntry("Code by: " & GameVersion.Programmer, False)
        AddEntry("Music by: " & GameVersion.Musician, False)
        AddEntry("Release Date: " & GameVersion.ReleaseDate, False)
        AddEntry("Press " & TextHandler.KeyBindNames(Input.ActionMenuSel) & " to return to main.", False)
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
    Dim Creditstop As Integer = 3
    Dim creditscale As Integer = 30
    Dim cshow As Integer = 0
    Public Overrides Sub HandleInput()
        ' INVOKE MENU ITEM
        If Input.pGA_Forward Then
            Select Case MenuSelect
                Case 0
                    ScreenManager.RemoveScreen("Credits")
                    ScreenManager.AddScreen(New TitleScreen())
                    ScreenManager.AddScreen(New MainMenu())
            End Select
        End If
        If Input.GA_Down Then
            If MenuPos.Y > -(Entries.Count - Creditstop) * creditscale Then MenuPos.Y -= 3
        End If
        If Input.pGA_Backward Then
            cshow += 1
        End If
    End Sub
    Public Overrides Sub Update()
        'Example of how to control your updates
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If AniTime > 20 Then
            AniTime = 0
            If MenuPos.Y > -(Entries.Count - Creditstop) * creditscale Then MenuPos.Y -= 1
        End If
    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(0, 0, Globals.GameSize.X, Globals.GameSize.Y), New Color(50, 0, 100))
        Dim MenuY As Integer = MenuPos.Y + 20
        For x = 0 To Entries.Count - 1
            If x = MenuSelect Then
                GameObj.DrawLetter(New Vector2(200 - Entries.Item(x).Text.Length * 5, MenuY), Entries.Item(x).Text, Color.Red, 0, 1)
            ElseIf Entries.Item(x).Enabled = True Then
                GameObj.DrawLetter(New Vector2(200 - Entries.Item(x).Text.Length * 5, MenuY), Entries.Item(x).Text, Color.White, 0, 1)
            Else
                GameObj.DrawLetter(New Vector2(200 - Entries.Item(x).Text.Length * 5, MenuY), Entries.Item(x).Text, Color.Gray, 0, 1)
            End If
            MenuY += 30
        Next


        GameObj.ControlHint(cshow)

    End Sub
End Class
