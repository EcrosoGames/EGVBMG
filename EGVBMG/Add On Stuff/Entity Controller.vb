Public Class Entity_Controller
    Public Shared EController As List(Of Entity)
    Public Shared PController As List(Of Particle)
    Public Shared Sub Init()
        EController = New List(Of Entity)
        PController = New List(Of Particle)

    End Sub
    Public Shared Sub Add(ByVal Label As String)
        Dim e As New Entity
        e.Label = Label
        EController.Add(e)
    End Sub
    Public Shared Sub RemoveAt(ByVal Index As Integer)
        EController.RemoveAt(Index)
    End Sub
    Public Shared Sub Update()
        For Each entity In EController
            entity.UpdateAI()
        Next
    End Sub
    Public Shared Sub Draw()
        For Each entity In EController
            Select Case entity.Value
                Case 0

            End Select
        Next
    End Sub
End Class