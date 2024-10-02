Public Class Sounds
    'Public Shared sound As soundeffect
    'Public Shared sound_ as soundeffectinstance 'This part is needed for being able to use the effect multiple times/layered
    Public Shared Sub Load()
        'sound = Globals.Content.Load(Of SoundEffect)("Sounds/name")

    End Sub
    Public Shared Sub Volume()
        'Abandoned.Volume = PlayerSettings.Music / 100
        'Music2.Volume = PlayerSettings.Music / 100
        'Music3.Volume = PlayerSettings.Music / 100
    End Sub
    Public Shared Sub SwitchSong(PlayTrack As Integer)
        'Abandoned.Stop
        'Music2.Stop
        'Music3.Stop
        Select Case PlayTrack
            Case 0

        End Select
    End Sub
    Public Shared Sub KillSFX()
        'Abandoned.Stop
        'Music2.Stop
        'Music3.Stop
    End Sub
End Class