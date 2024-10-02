Public Class TitleScreen
    Inherits BaseScreen
    Private AniTime As Double = 0
    Public Sub New()
        Name = "TitleScreen"
        State = ScreenState.Active
    End Sub
    Public Overrides Sub HandleInput()
        MyBase.HandleInput()
    End Sub
    Public Overrides Sub Update()
        'Example of how to control your updates
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If AniTime > 255 Then
            AniTime = 0

        End If
    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(0, 0, 400, 240), New Color(100, 0, 200))

        GameObj.DrawLetter(New Vector2(10, 10), GameVersion.Name, Color.Red, 1, 4)

    End Sub
    Public Overrides Sub remove()
        MyBase.remove()
    End Sub
End Class