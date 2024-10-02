Public Class ScreenEffects
    Public Shared Sub Screenshake(shaketype As Integer)
        Globals.Lastscreenshaketype = shaketype
        Select Case shaketype
            Case -1
                Globals.ScreenPos = New Vector2(0, 0)
            Case 0 'Sideways
                Globals.ScreenPos.X = RNG.Free(-4, 4)
            Case 1 'All directions
                Globals.ScreenPos = New Vector2(RNG.Free(-4, 4), RNG.Free(-4, 4))
            Case 2 'Down only
                Globals.ScreenPos.Y = RNG.Free(0, 4)
        End Select
    End Sub
End Class
