Public Class Save
    Public Shared CurrentSaveLoc As String = "Save"
    Public Shared loc As String = My.Application.Info.DirectoryPath & "\" & CurrentSaveLoc
    Public Shared Sub ChangeSavLoc(ByVal savenm As String)
        CurrentSaveLoc = savenm
        loc = My.Application.Info.DirectoryPath & "\" & CurrentSaveLoc
    End Sub
    Public Shared Sub Nuke()
        IO.Directory.Delete(loc, True)
    End Sub
    Public Shared Sub Save()
        If Not IO.Directory.Exists(loc) Then IO.Directory.CreateDirectory(loc)
        If Not IO.File.Exists(loc & "/Savegame.sav") Then IO.File.Create(loc & "/Savegame.sav").Dispose()
        IO.File.WriteAllText(loc & "Savegame.sav", "SaveData")
    End Sub
    Public Shared Sub Load()
        If IO.File.Exists(loc & "/Savegame.sav") Then
            Dim SaveData() As String = IO.File.ReadAllLines(loc & "Savegame.sav")
            Dim SaveInfo As String = SaveData(0)
        End If
    End Sub
End Class
