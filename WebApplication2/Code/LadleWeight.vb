Namespace LadleWeight
    Public Class Values
        Public Shared Function EmptyWt(ByVal HeatNumber As Long) As Decimal
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = " select @w1 = w1 from mm_ladleweights where heat_number = @HeatNumber "
                oCmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8).Value = HeatNumber
                oCmd.Parameters.Add("@w1", SqlDbType.Float, 8).Direction = ParameterDirection.Output
                oCmd.ExecuteScalar()
                Return IIf(IsDBNull(oCmd.Parameters("@w1").Value), 0, oCmd.Parameters("@w1").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function AfterTapWt(ByVal HeatNumber As Long) As Decimal
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = " select @w2 = w2 from mm_ladleweights where heat_number = @HeatNumber "
                oCmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8).Value = HeatNumber
                oCmd.Parameters.Add("@w2", SqlDbType.Float, 8).Direction = ParameterDirection.Output
                oCmd.ExecuteScalar()
                Return IIf(IsDBNull(oCmd.Parameters("@w2").Value), 0, oCmd.Parameters("@w2").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function AfterPouringWt(ByVal HeatNumber As Long) As Decimal
           Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = " select @w3 = w3 from mm_ladleweights where heat_number = @HeatNumber "
                oCmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8).Value = HeatNumber
                oCmd.Parameters.Add("@w3", SqlDbType.Float, 8).Direction = ParameterDirection.Output
                oCmd.ExecuteScalar()
                Return IIf(IsDBNull(oCmd.Parameters("@w3").Value), 0.0, oCmd.Parameters("@w3").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
        End Function
    End Class
    Public Class Empty
        Public Sub New(ByVal HeatNumber As Long, ByVal EmptyWt As Double)
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8).Value = HeatNumber
                oCmd.Parameters.Add("@EmptyWt", SqlDbType.Float, 8).Value = Val(EmptyWt)
                oCmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = " select @Cnt = count(*) from mm_ladleweights where heat_number = @HeatNumber "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@Cnt").Value), 0, oCmd.Parameters("@Cnt").Value) = 0 Then
                    oCmd.CommandText = "insert into mm_ladleweights " & _
                                                    " ( heat_number , w1  ) " & _
                                                    " values ( @HeatNumber , @EmptyWt   ) "
                Else
                    oCmd.CommandText = " Update mm_ladleweights " & _
                                                    " set w1 = @EmptyWt  " & _
                                                    " where heat_number = @HeatNumber "
                End If

                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Throw New Exception(" updation of Ladle Weights data failed !")
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
            Done = Nothing
        End Sub
    End Class
    Public Class AfterTap
        Public Sub New(ByVal HeatNumber As Long, ByVal AfterTap As Double)
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8).Value = HeatNumber
                oCmd.Parameters.Add("@AfterTap", SqlDbType.Float, 8).Value = Val(AfterTap)
                oCmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = " select @Cnt = count(*) from mm_ladleweights where heat_number = @HeatNumber "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@Cnt").Value), 0, oCmd.Parameters("@Cnt").Value) = 0 Then
                    oCmd.CommandText = "insert into mm_ladleweights " & _
                                                    " ( heat_number , w2  ) " & _
                                                    " values ( @HeatNumber , @AfterTap   ) "
                Else
                    oCmd.CommandText = " Update mm_ladleweights " & _
                                                    " set w2 = @AfterTap  " & _
                                                    " where heat_number = @HeatNumber "
                End If

                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Throw New Exception(" updation of Ladle Weights data failed !")
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
            Done = Nothing
        End Sub
    End Class
    Public Class AfterPouring
        Public Sub New(ByVal HeatNumber As Long, ByVal AfterPouring As Double)
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8).Value = HeatNumber
                oCmd.Parameters.Add("@AfterPouring", SqlDbType.Float, 8).Value = Val(AfterPouring)
                oCmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = " select @Cnt = count(*) from mm_ladleweights where heat_number = @HeatNumber "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@Cnt").Value), 0, oCmd.Parameters("@Cnt").Value) = 0 Then
                    oCmd.CommandText = "insert into mm_ladleweights " & _
                                                    " ( heat_number , w3  ) " & _
                                                    " values ( @HeatNumber , @AfterPouring   ) "
                Else
                    oCmd.CommandText = " Update mm_ladleweights " & _
                                                    " set w3 = @AfterPouring  " & _
                                                    " where heat_number = @HeatNumber "
                End If

                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Throw New Exception(" updation of Ladle Weights data failed !")
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
            Done = Nothing
        End Sub
    End Class
End Namespace
