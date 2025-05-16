Module modValidateInt
    Public Function validateInt(ByVal sinstr As String, ByVal maxLength As Integer,
                            ByVal allowDecimal As Boolean, ByVal allowNegative As Boolean) As Boolean
        Try
            If Not IsNumeric(sinstr) Then Return False

            If Not allowDecimal Then
                If InStr(sinstr, ".") Then
                    Return False
                End If
            End If

            Dim msgtokens() As String = sinstr.Split(".")
            If Len(msgtokens(0)) > maxLength Then
                Return False
            End If

            If Not allowNegative Then
                If CInt(sinstr) < 0 Then
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return False
        End Try
    End Function
End Module
