Public Class Textures
    'Public Shared texture As Texture2D
    Public Shared Null As Texture2D
    Public Shared TRANSLATE As Texture2D

    Public Shared TRANSLATEx2 As Texture2D
    Public Shared GUIFRAMES As Texture2D
    Public Shared Sub Load()
        'texture = Globals.Content.Load(Of Texture2D)("GFX/name")
        Null = Globals.Content.Load(Of Texture2D)("menuscreen")
        TRANSLATE = Globals.Content.Load(Of Texture2D)("fonts")
        TRANSLATEx2 = Globals.Content.Load(Of Texture2D)("fonts2X")
        GUIFRAMES = Globals.Content.Load(Of Texture2D)("Textbox GUI Frames")
    End Sub
End Class
