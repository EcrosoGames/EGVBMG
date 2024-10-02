Public Class Entity
    Public Pos As Vector4 'Z=Zorder | W=Last Dir
    Public Vel As Vector4 'Z=Rotate | W = AnimCt
    Public Value As Integer = 1
    Public Label As String = "NULL"
    Public Target As Vector4
    Public Amination As String = "Idle"
    Public IncSpeed As Single = 5.0F
    Public Maxspeed As Single = 15.0F
    Public RotSpeed As Single = 1.0F
    Public Decisionct As Integer = 0
    Public Wireframe As Boolean = False
    Public Hitbox As Rectangle
    Public AImood As Integer = -1 '0=Wander|1=Follow|2=Attack
    Public Speech As List(Of String)
    Public Speaking As Boolean = False
    Public Task As Integer = 0
    Public NPCtgt As Integer = 5
    Public Sub UpdateAI()
        Pos.X += Vel.X
        Pos.Y += Vel.Y
        Vel.Z += RotSpeed
        Decisionct += 1
        If Decisionct > 100 Then
            Decisionct = 0
            Task -= 1 'Add Logic
            'Pathing

        End If

    End Sub
End Class