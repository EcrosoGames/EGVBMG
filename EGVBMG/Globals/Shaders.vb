Public Class Shaders
    Public Shared DefaultFX As Effect
    Public Shared Sub Load()
        'texture = Globals.Content.Load(Of Texture2D)("GFX/name")
        DefaultFX = Globals.Content.Load(Of Effect)("DefaultFX")
    End Sub
End Class
