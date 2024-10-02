Public Class Game1
    'A lot of the original code found here was made by Aardaerimus D'Aritonyss, I simply followed his tutorials to get started but added my own code snippets to build the engine
    Inherits Microsoft.Xna.Framework.Game
    Private ScreenManager As ScreenManager
    Public Sub New()
        Globals.Graphics = New GraphicsDeviceManager(Me)
        Globals.Graphics.ApplyChanges()
        DrawLive.freedraw = Globals.Graphics
        Content.RootDirectory = "Content"
        Thread = New List(Of Task)
    End Sub
    Public Shared Change As Boolean = False
    Public Shared FPSmax As Integer = 60
    Public Sub Synch()
        If Globals.Graphics.SynchronizeWithVerticalRetrace = True Then
            Globals.Graphics.SynchronizeWithVerticalRetrace = False
            Me.IsFixedTimeStep = False
        Else
            Globals.Graphics.SynchronizeWithVerticalRetrace = True
            Me.IsFixedTimeStep = True
        End If
        Globals.Graphics.ApplyChanges()
    End Sub

    Protected Overrides Sub Initialize()
        Me.IsMouseVisible = True
        Window.AllowUserResizing = True
        Globals.GameSize = New Vector2(400, 240)
        Globals.Graphics.PreferredBackBufferWidth = Globals.GameSize.X
        Globals.Graphics.PreferredBackBufferHeight = Globals.GameSize.Y
        Globals.Graphics.ApplyChanges()
        Globals.BackBuffer = New RenderTarget2D(Globals.Graphics.GraphicsDevice, Globals.GameSize.X, Globals.GameSize.Y, False, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents)
        BaseBackGround = New Texture2D(Globals.Graphics.GraphicsDevice, Globals.BackBuffer.Width, Globals.BackBuffer.Height)
        MyBase.Initialize()
        Globals.Graphics.SynchronizeWithVerticalRetrace = True
        Me.IsFixedTimeStep = True
        Globals.Graphics.ApplyChanges()
        Globals.Debugging = False
        Save.Save()
        GameDeveloperKit.ChangeRes(New Vector2(2160, 1440))
    End Sub
    Protected Overrides Sub LoadContent()
        Globals.SpriteBatch = New SpriteBatch(GraphicsDevice)
        Globals.Content = Me.Content
        Fonts.Load()
        Textures.Load()
        Sounds.Load()
        Shaders.Load()
        ScreenManager = New ScreenManager()
        ScreenManager.AddScreen(New TitleScreen)
        ScreenManager.AddScreen(New MainMenu)
    End Sub
    Private AniTime As Double = 0
    Public Shared Aminate As Integer = 0
    Protected Overrides Sub Update(ByVal gameTime As GameTime)
        MyBase.Update(gameTime)
        Globals.WindowFocused = Me.IsActive
        Globals.GameTime = gameTime
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If AniTime > 20 Then
            AniTime = 0
            Aminate += 1
            If Aminate > 255 Then Aminate = 0
            If Change Then
                Synch()
                Change = False
            End If
            If Me.TargetElapsedTime <> TimeSpan.FromSeconds(1 / FPSmax) Then Me.TargetElapsedTime = TimeSpan.FromSeconds(1 / FPSmax)
            Globals.GameSize = New Vector2(Globals.Graphics.PreferredBackBufferWidth, Globals.Graphics.PreferredBackBufferHeight)
            ScreenManager.Update()
            Input.Update()
        End If
    End Sub
    Public Shared SSM As SpriteSortMode = SpriteSortMode.Immediate
    Public Shared BlS As BlendState = BlendState.AlphaBlend
    Public Shared SmS As SamplerState = SamplerState.PointClamp
    Public Shared DSS As DepthStencilState = DepthStencilState.Default
    Public Shared RrS As RasterizerState = RasterizerState.CullNone
    Public Shared SpE As Effect = Nothing
    Public Shared TempShader As Effect
    Public Shared BaseBackGround As Texture2D
    Dim Thread As List(Of Task)
    Public Shared Sub DrawInjectShaderBegin(Shader As Effect)
        Globals.SpriteBatch.End()
        TempShader = Shader
        Globals.SpriteBatch.Begin(SSM, BlS, SmS, DSS, RrS, TempShader)
    End Sub
    Public Shared Sub DrawInjectShaderEnd()
        Globals.SpriteBatch.End()
        Globals.SpriteBatch.Begin(SSM, BlS, SmS, DSS, RrS, SpE)
    End Sub
    Protected Overrides Sub Draw(ByVal gameTime As GameTime)
        If Globals.ScreenShakeCD >= 0 Then
            Globals.ScreenShakeCD -= 1
            ScreenEffects.Screenshake(Globals.Lastscreenshaketype)
        Else
            ScreenEffects.Screenshake(-1)
        End If
        GraphicsDevice.Clear(Color.Black)
        MyBase.Draw(gameTime)

        Globals.SpriteBatch.Begin(SSM, BlS, SmS, DSS, RrS, SpE)
        Globals.SpriteBatch.Draw(BaseBackGround, New Rectangle(Globals.ScreenPos.X, Globals.ScreenPos.Y, Globals.Graphics.GraphicsDevice.Viewport.Width, Globals.Graphics.GraphicsDevice.Viewport.Height), New Rectangle(0, 0, Globals.BackBuffer.Width, Globals.BackBuffer.Height), Color.White, 0, New Vector2(0, 0), SpriteEffects.None, 0)
        Globals.SpriteBatch.End()

        Globals.Graphics.GraphicsDevice.SetRenderTarget(Globals.BackBuffer)
        Globals.SpriteBatch.Begin(SSM, BlS, SmS, DSS, RrS, SpE)
        ScreenManager.Draw()
        Globals.SpriteBatch.End()
        'Back Buffer Draw
        Globals.Graphics.GraphicsDevice.SetRenderTarget(Nothing)
        Globals.SpriteBatch.Begin(SSM, BlS, SmS, DSS, RrS, SpE)
        'ScreenManager.Draw()

        Globals.SpriteBatch.Draw(Globals.BackBuffer, New Rectangle(Globals.ScreenPos.X, Globals.ScreenPos.Y, Globals.Graphics.GraphicsDevice.Viewport.Width, Globals.Graphics.GraphicsDevice.Viewport.Height), New Rectangle(0, 0, Globals.BackBuffer.Width, Globals.BackBuffer.Height), Color.White, 0, New Vector2(0, 0), SpriteEffects.None, 0)

        Globals.SpriteBatch.End()
    End Sub

End Class
