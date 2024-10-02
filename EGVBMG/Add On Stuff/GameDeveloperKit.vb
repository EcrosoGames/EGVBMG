Public Class GameDeveloperKit
    Private Sub X720ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X720ToolStripMenuItem.Click
        ChangeRes(New Vector2(1280, 720))
    End Sub
    Private Sub FPSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FPSToolStripMenuItem.Click
        Game1.FPSmax = 30
    End Sub
    Private Sub FPSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FPSToolStripMenuItem1.Click
        Game1.FPSmax = 60
    End Sub
    Private Sub FPSToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles FPSToolStripMenuItem2.Click
        Game1.FPSmax = 90
    End Sub
    Private Sub FPSToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles FPSToolStripMenuItem3.Click
        Game1.FPSmax = 120
    End Sub

    Private Sub FPSToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles FPSToolStripMenuItem4.Click
        Game1.FPSmax = 144
    End Sub

    Private Sub FPSToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles FPSToolStripMenuItem5.Click
        Game1.FPSmax = 240
    End Sub

    Private Sub FPSToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles FPSToolStripMenuItem6.Click
        Game1.FPSmax = 360
    End Sub

    Private Sub X240ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X240ToolStripMenuItem.Click
        ChangeRes(New Vector2(400, 240))
    End Sub

    Private Sub X480ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X480ToolStripMenuItem.Click
        ChangeRes(New Vector2(640, 480))
    End Sub

    Private Sub X640ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X640ToolStripMenuItem.Click
        ChangeRes(New Vector2(1024, 640))
    End Sub

    Private Sub X1080ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X1080ToolStripMenuItem.Click
        ChangeRes(New Vector2(1920, 1080))
    End Sub

    Private Sub X1440ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X1440ToolStripMenuItem.Click
        ChangeRes(New Vector2(2560, 1440))
    End Sub

    Private Sub X2160ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X2160ToolStripMenuItem.Click
        ChangeRes(New Vector2(3840, 2160))
    End Sub
    Public Sub ChangeRes(v As Vector2)
        Globals.GameSize = v
        Globals.Graphics.PreferredBackBufferWidth = Globals.GameSize.X
        Globals.Graphics.PreferredBackBufferHeight = Globals.GameSize.Y
        If Backbuffer Then
            Globals.BackBuffer = New RenderTarget2D(Globals.Graphics.GraphicsDevice, Globals.GameSize.X, Globals.GameSize.Y, False, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents)
        End If
        Globals.Graphics.ApplyChanges()
    End Sub
    Private Sub ExitGDKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitGDKToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub GameDeveloperKit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    'Scene Save Load
    Private Sub SaveSceneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveSceneToolStripMenuItem.Click
        IO.File.Create(Save.CurrentSaveLoc & "/Scene1.ecr").Dispose()
        IO.File.WriteAllText(Save.CurrentSaveLoc & "/Scene1.ecr", Scene.ChangeMap("Demo"))
    End Sub

    Private Sub LoadSceneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadSceneToolStripMenuItem.Click

    End Sub
    Dim Backbuffer As Boolean = False
    Private Sub BackBufferIncludedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackBufferIncludedToolStripMenuItem.Click
        If Not Backbuffer Then
            BackBufferIncludedToolStripMenuItem.Text = "Back Buffer Included"
            Backbuffer = True
        Else
            BackBufferIncludedToolStripMenuItem.Text = "Back Buffer Excluded"
            Backbuffer = False
        End If
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub RPGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RPGToolStripMenuItem.Click

    End Sub
End Class