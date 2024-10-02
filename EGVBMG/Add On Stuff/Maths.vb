Public Class Maths
    Public Shared Function Distance(ByVal p1 As Vector2, ByVal p2 As Vector2) As Double
        Dim dist As Double = 0
        dist = Math.Abs(Math.Sqrt((p2.X - p1.X) ^ 2 + (p2.Y - p1.Y) ^ 2))
        Return dist
    End Function
    Public Shared Function Circollision(ByVal p1 As Vector2, ByVal p2 As Vector2, ByVal dist As Vector2) As Boolean
        If Distance(p1, p2) > dist.X And Distance(p1, p2) < dist.Y Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function Collision(ByVal B1 As Rectangle, ByVal B2 As Rectangle, ByVal Vectoring As Boolean) As Boolean
        If Vectoring Then
            If B1.X - B1.Width / 2 < B2.X + B2.Width / 2 And
                         B1.X + B1.Width / 2 > B2.X - B2.Width / 2 And
                        B1.Y - B1.Height / 2 < B2.Y + B2.Height / 2 And
                         B1.Y + B1.Height / 2 > B2.Y - B2.Height / 2 Then
                Return True
            Else
                Return False
            End If
        Else
            If B1.X < B2.X + B2.Width And
             B1.X + B1.Width > B2.X And
             B1.Y < B2.Y + B2.Height And
             B1.Y + B1.Height > B2.Y Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Public Shared Function Inside(ByVal B1 As Rectangle, ByVal B2 As Rectangle) As Boolean
        If B1.X < B2.X + B2.Width And
            B1.X + B1.Width > B2.X And
            B1.X + B1.Width < B2.X + B2.Width And
            B1.X > B2.X And
            B1.Y < B2.Y + B2.Height And
            B1.Y + B1.Height > B2.Y Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function CursorOnScreen() As Boolean
        Return Collision(New Rectangle(Mouse.GetState.X, Mouse.GetState.Y, 5, 5), New Rectangle(0, 0, Globals.GameSize.X, Globals.GameSize.Y), False)
    End Function
    Public Shared Function RGBtoK(ByVal c As Color) As Color
        Dim Kel As Color = c
        If Kel.G < Kel.R And Kel.G < Kel.B Then
            If Kel.B < Kel.R Then
                Kel.B = 0
                Kel.R = 255
            Else
                Kel.R = 0
                Kel.B = 255
            End If
        ElseIf Kel.G > Kel.R And Kel.G > Kel.B Then
            If Kel.B > Kel.R Then
                Kel.B = 255
            Else
                Kel.R = 255
            End If
        ElseIf Kel.G > Kel.R And Kel.G <= Kel.B Then
            Kel.B = 255
            Kel.R = 0
        ElseIf Kel.G <= Kel.R And Kel.G > Kel.B Then
            Kel.R = 255
            Kel.B = 0
        ElseIf Kel.G = Kel.R And Kel.R = Kel.B Then
            Kel.R = 255
            Kel.B = 255
            Kel.G = 255
        ElseIf Kel.R > Kel.G And Kel.G = Kel.B And Kel.G > 100 Then
            Kel.G = 0
            Kel.B = 0
            Kel.R = 255
        ElseIf Kel.R = Kel.G And Kel.G < Kel.B Then
            Kel.G = 0
            Kel.R = 0
            Kel.B = 255
        End If
        Dim all As Integer = Kel.R
        all += Kel.G
        all += Kel.B
        If all > 550 Then
            Kel = Color.White
        End If
        Return Kel
    End Function
    Public Shared Function Posmark(axis As String, part As Integer, parts As Integer)
        If axis.ToUpper = "X" Then 'x
            Return Globals.GameSize.X / parts * part
        ElseIf axis.ToUpper = "Y" Then 'y
            Return Globals.GameSize.Y / parts * part
        Else
            Return 0
        End If
    End Function
    Public Shared Function ScaledMousePos() As Vector2
        Globals.ScreenMargins = New Vector2(Globals.Graphics.GraphicsDevice.Viewport.Width - Globals.GameSize.X, Globals.Graphics.GraphicsDevice.Viewport.Height - Globals.GameSize.Y)
        Return New Vector2(Mouse.GetState.X + Globals.ScreenPos.X - Globals.ScreenMargins.X / 2, Mouse.GetState.Y + Globals.ScreenPos.Y - Globals.ScreenMargins.Y / 2)
    End Function
    Public Shared Function ActualScreen() As Rectangle
        Return New Rectangle(Globals.Graphics.GraphicsDevice.Viewport.Width / 2 - Globals.BackBuffer.Width / 2 + Globals.ScreenPos.X, Globals.Graphics.GraphicsDevice.Viewport.Height / 2 - Globals.BackBuffer.Height / 2 + Globals.ScreenPos.Y, Globals.BackBuffer.Width, Globals.BackBuffer.Height)
    End Function
    Public Shared Function GetGlobalTick() As Single
        Return Globals.GameTime.TotalGameTime.TotalMilliseconds + DateTime.Now.DayOfYear * 1000 + DateTime.Now.Year * 10000
    End Function
    Public Function Radians(ra As Single) As Single
        Return Math.PI * 2 * ra
    End Function
End Class