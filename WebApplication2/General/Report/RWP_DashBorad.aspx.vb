Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class RWP_DashBorad
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        working_year = DateTime.Now.ToString("yyyy")
        working_days_tilldate(working_year - 1, working_year)
        working_days_year(working_year - 1, working_year)
    End Sub
    Public wheel_type As New ArrayList
    Public wheel_type_value As New ArrayList
    Public qtr_type As New ArrayList
    Public qtr_type_value As New ArrayList

    Public quarter_wise_wheel_category_wise As New ArrayList
    Public quarter_wise_wheel_category_value1 As New ArrayList
    Public quarter_wise_wheel_category_value2 As New ArrayList
    Public quarter_wise_wheel_category_value3 As New ArrayList

    Public wheel_allotment As New ArrayList
    Public wheel_dispatch As New ArrayList
    Public wheel_cast As New ArrayList
    Public wheel_year As New ArrayList

    Public boxn_bgc_reject As New ArrayList
    Public bgc_reject As New ArrayList

    Public off_heat_reject As New ArrayList
    Public mr_reject As New ArrayList
    Public mg_utr_reject As New ArrayList
    Public mach_reject As New ArrayList

    Public working_year As String
    Dim nhday As Integer
    Dim n As Integer
    Dim ndays_year As Integer
    Dim list As New List(Of String)
    Dim start_year_now As Integer
    Dim end_year_now As Integer
    Dim tilldate As Integer

    Public wdays_tilldate As Integer
    Public wdays_year As Integer

    Public fyear As Integer = (DateTime.Now.ToString("yyyy")) - 4
    Public endyear As Integer = 4
    Public c As String = "-"
    Public str As String = CStr(fyear) & CStr(c) & CStr(fyear + 1)

    Dim con As SqlConnection = New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;Persist Security Info=True;User ID=sa;Password=sadev123")

    Public Sub reject_type()
        Dim rdr As SqlDataReader
        off_heat_reject = New ArrayList
        mr_reject = New ArrayList
        mg_utr_reject = New ArrayList
        mach_reject = New ArrayList

        wheel_year = New ArrayList
        Dim str As String = "select * from rejection_type"
        Dim str1 As String = "select description from rejection_type_description"
        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str)
        While rdr.Read
            wheel_year.Add(rdr.Item("fyear"))
            off_heat_reject.Add(rdr.Item("off_heat"))
            mr_reject.Add(rdr.Item("mr_rejection"))
            mg_utr_reject.Add(rdr.Item("mg_utr"))
            mach_reject.Add(rdr.Item("mach_rejection"))
        End While
        rdr.Close()
        con.Close()
    End Sub

    Public Sub reject()
        Dim rdr As SqlDataReader
        boxn_bgc_reject = New ArrayList
        bgc_reject = New ArrayList
        wheel_year = New ArrayList
        Dim str As String = "select * from rejection"
        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str)
        While rdr.Read
            wheel_year.Add(rdr.Item("fyear"))
            boxn_bgc_reject.Add(rdr.Item("boxn_bgc"))
            bgc_reject.Add(rdr.Item("bgc"))
        End While
        con.Close()

    End Sub

    Public Sub allotment_dispatch(ByVal fnyear As Integer)
        Dim rdr As SqlDataReader
        wheel_allotment = New ArrayList
        wheel_dispatch = New ArrayList
        wheel_cast = New ArrayList
        Dim str As String = " select sum(CASE WHEN YEARS='" & fnyear & "' and qtr between 1 and 3 or years='" & (fnyear + 1) & "' and qtr=4 THEN wheel_qty ELSE 0 END) sumofvalue from WTA_ALLOTMENT$"
        Dim str1 As String = "select sum(CASE WHEN YEARS='" & fnyear & "' and qtr between 1 and 3 or years='" & (fnyear + 1) & "' and qtr=4 THEN Qty_M ELSE 0 END) sumofvalue1 from wheel_dispatch_casting$ where wheel_category=2"
        Dim str2 As String = "select sum(CASE WHEN YEARS='" & fnyear & "' and qtr between 1 and 3 or years='" & (fnyear + 1) & "' and qtr=4 THEN Qty_M ELSE 0 END) sumofvalue2 from wheel_dispatch_casting$ where wheel_category=3 and wheel_type=1"


        'Dim str As String = "SELECT fyear,sumofvalue FROM (select fyear,sum(CASE WHEN YEARS='" & fnyear & "' and qtr between 1 and 3 or years='" & (fnyear + 1) & "' and qtr=4 THEN wheel_qty ELSE 0 END) sumofvalue from WTA_ALLOTMENT$ group by fyear) AS TS where sumofvalue <> 0"
        ' Dim str1 As String = "SELECT fyear,sumofvalue1 FROM (select fyear,sum(CASE WHEN YEARS='" & fnyear & "' and qtr between 1 and 3 or years='" & (fnyear + 1) & "' and qtr=4 THEN Qty_M ELSE 0 END) sumofvalue1 from wheel_dispatch_casting$ where wheel_category=2  group by fyear) AS TS1 where sumofvalue1 <> 0"
        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str)
        While rdr.Read
            wheel_allotment.Add(rdr.Item("sumofvalue"))
        End While
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        While rdr.Read
            wheel_dispatch.Add(rdr.Item("sumofvalue1"))
        End While
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        While rdr.Read
            wheel_cast.Add(rdr.Item("sumofvalue2"))
        End While
        rdr.Close()
        con.Close()

    End Sub
    Public Sub allotment_cast(ByVal fnyear As Integer)
        Dim rdr As SqlDataReader
        wheel_allotment = New ArrayList
        wheel_cast = New ArrayList
        Dim str As String = " select sum(CASE WHEN YEARS='" & fnyear & "' and qtr between 1 and 3 or years='" & (fnyear + 1) & "' and qtr=4 THEN wheel_qty ELSE 0 END) sumofvalue from WTA_ALLOTMENT$"
        Dim str1 As String = "select sum(CASE WHEN YEARS='" & fnyear & "' and qtr between 1 and 3 or years='" & (fnyear + 1) & "' and qtr=4 THEN Qty_M ELSE 0 END) sumofvalue1 from wheel_dispatch_casting$ where wheel_category=3 and wheel_type=1"

        'Dim str As String = "SELECT fyear,sumofvalue FROM (select fyear,sum(CASE WHEN YEARS='" & fnyear & "' and qtr between 1 and 3 or years='" & (fnyear + 1) & "' and qtr=4 THEN wheel_qty ELSE 0 END) sumofvalue from WTA_ALLOTMENT$ group by fyear) AS TS where sumofvalue <> 0"
        ' Dim str1 As String = "SELECT fyear,sumofvalue1 FROM (select fyear,sum(CASE WHEN YEARS='" & fnyear & "' and qtr between 1 and 3 or years='" & (fnyear + 1) & "' and qtr=4 THEN Qty_M ELSE 0 END) sumofvalue1 from wheel_dispatch_casting$ where wheel_category=2  group by fyear) AS TS1 where sumofvalue1 <> 0"
        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str)
        While rdr.Read
            wheel_allotment.Add(rdr.Item("sumofvalue"))
        End While
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        While rdr.Read
            wheel_cast.Add(rdr.Item("sumofvalue1"))
        End While
        rdr.Close()
        con.Close()

    End Sub
    Public Sub dispatch_cast(ByVal fnyear As Integer)
        Dim rdr As SqlDataReader
        wheel_dispatch = New ArrayList
        wheel_cast = New ArrayList
        Dim str As String = "select sum(CASE WHEN YEARS='" & fnyear & "' and qtr between 1 and 3 or years='" & (fnyear + 1) & "' and qtr=4 THEN Qty_M ELSE 0 END) sumofvalue from wheel_dispatch_casting$ where wheel_category=2"
        Dim str1 As String = "select sum(CASE WHEN YEARS='" & fnyear & "' and qtr between 1 and 3 or years='" & (fnyear + 1) & "' and qtr=4 THEN Qty_M ELSE 0 END) sumofvalue1 from wheel_dispatch_casting$ where wheel_category=3 and wheel_type=1"

        'Dim str As String = "SELECT fyear,sumofvalue FROM (select fyear,sum(CASE WHEN YEARS='" & fnyear & "' and qtr between 1 and 3 or years='" & (fnyear + 1) & "' and qtr=4 THEN wheel_qty ELSE 0 END) sumofvalue from WTA_ALLOTMENT$ group by fyear) AS TS where sumofvalue <> 0"
        ' Dim str1 As String = "SELECT fyear,sumofvalue1 FROM (select fyear,sum(CASE WHEN YEARS='" & fnyear & "' and qtr between 1 and 3 or years='" & (fnyear + 1) & "' and qtr=4 THEN Qty_M ELSE 0 END) sumofvalue1 from wheel_dispatch_casting$ where wheel_category=2  group by fyear) AS TS1 where sumofvalue1 <> 0"
        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str)
        While rdr.Read
            wheel_dispatch.Add(rdr.Item("sumofvalue"))
        End While
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        While rdr.Read
            wheel_cast.Add(rdr.Item("sumofvalue1"))
        End While
        rdr.Close()
        con.Close()

    End Sub


    Public Sub wheel_allotment_year(ByVal fnyear As Integer, ByVal category As Integer)

        Dim rdr As SqlDataReader
        wheel_type = New ArrayList()
        wheel_type_value = New ArrayList()

        Dim str As String = "select wheel_type_full_desc wheel_type,sum(CASE WHEN YEARS='" & fnyear & "'and qtr between 1 and 3 or years='" & (fnyear + 1) & "' and qtr=4 THEN wheel_qty ELSE 0 END) sumofvalue from WTA_ALLOTMENT$ wa, wheel_type wt where wa.wheel_allotment='1'
            and wa.type=wt.wheel_type_seq group by wheel_type_full_desc"
        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str)
        While rdr.Read
            wheel_type.Add(Trim(rdr.Item("wheel_type")))
            wheel_type_value.Add(rdr.Item("sumofvalue"))

        End While
        con.Close()
    End Sub
    Public Sub wheel_dispatch_cast_year(ByVal fnyear As Integer, ByVal category As Integer)

        Dim rdr As SqlDataReader
        wheel_type = New ArrayList()
        wheel_type_value = New ArrayList()

        Dim str As String = "select wheel_type_full_desc wheel_type,sum(CASE WHEN YEARS='" & fnyear & "' and f_month between 1 and 9 or years='" & (fnyear + 1) & "' and f_month between 10 and 12 THEN Qty_M ELSE 0 END) sumofvalue from WHEEL_DISPATCH_CASTING$ wa, wheel_type wt where wa.wheel_category='" & category & "'
            and wa.wheel_type=wt.wheel_type_seq group by wheel_type_full_desc"
        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str)
        While rdr.Read
            wheel_type.Add(Trim(rdr.Item("wheel_type")))
            wheel_type_value.Add(rdr.Item("sumofvalue"))

        End While
        con.Close()

    End Sub
    Public Sub ch()
        Dim rdr As SqlDataReader
        qtr_type = New ArrayList()
        qtr_type_value = New ArrayList()
        Dim str1 As String = "select q.fin_qtr_desc,wa.qtr,wa.wheel_qty from qtr_master q,WTA_ALLOTMENT$ wa where years='2018' and wa.qtr between 1 and 3 and wa.qtr=q.fin_qtr_seq"
        Dim str2 As String = "select q.fin_qtr_desc,wa.qtr,wa.wheel_qty from qtr_master q,WTA_ALLOTMENT$ wa where years='2019' and wa.qtr=4 and wa.qtr=q.fin_qtr_seq"
        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        While rdr.Read
            qtr_type.Add(Trim(rdr.Item("fin_qtr_desc")))
            qtr_type_value.Add(rdr.Item("wheel_qty"))

        End While
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        While rdr.Read
            qtr_type.Add(Trim(rdr.Item("fin_qtr_desc")))
            qtr_type_value.Add(rdr.Item("wheel_qty"))

        End While
        con.Close()
        Response.Write(qtr_type_value.Item(0))
        Response.Write(qtr_type_value.Item(3))
    End Sub

    Public Sub wheel_data_quarter(ByVal category As Integer)
        Dim rdr As SqlDataReader
        quarter_wise_wheel_category_wise = New ArrayList()
        quarter_wise_wheel_category_value1 = New ArrayList()
        quarter_wise_wheel_category_value2 = New ArrayList()
        quarter_wise_wheel_category_value3 = New ArrayList()

        Dim str As String = "select fyear,sum(CASE WHEN wheel_category=2 THEN p.QTY_M ELSE 0 END) sum2,sum(CASE WHEN wheel_category=3 THEN p.QTY_M 
ELSE 0 END) sum3  from WHEEL_DISPATCH_CASTING$ p where  qtr='" & category & "' and wheel_type=1 group by fyear"
        Dim str1 As String = "select fyear,sum(CASE WHEN wheel_allotment=1 THEN p.wheel_qty ELSE 0 END) sum1 from WTA_ALLOTMENT$ p where  qtr='" & category & "' group by fyear"
        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str)
        While rdr.Read
            ' quarter_wise_wheel_category_wise.Add(Trim(rdr.Item("year")))
            'quarter_wise_wheel_category_value1.Add(rdr.Item("sum1"))
            quarter_wise_wheel_category_value2.Add(rdr.Item("sum2"))
            quarter_wise_wheel_category_value3.Add(rdr.Item("sum3"))
        End While
        rdr.Close()

        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        While rdr.Read
            quarter_wise_wheel_category_wise.Add(Trim(rdr.Item("fyear")))
            quarter_wise_wheel_category_value1.Add(rdr.Item("sum1"))
        End While

        con.Close()
    End Sub

    Sub working_days_year(ByVal syr As String, ByVal eyr As String)
        Dim rdr As SqlDataReader

        ' Dim con As SqlConnection = New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;Persist Security Info=True;User ID=sa;Password=sadev123")
        Dim str1 As String = "select count(distinct date) holiday from mm_calendar_dump where date between '" & syr & "-04-01 00:00:00' and '" & eyr & "-03-31 00:00:00'"
        Dim str2 As String = "select distinct convert(varchar, date, 111) hday from mm_calendar_dump where date between '" & syr & "-04-01 00:00:00' and '" & eyr & "-03-31 00:00:00' order by hday"
        Dim str4 As String = "select DATEDIFF(day,'" & syr & "-04-01 00:00:00','" & eyr & "-03-31 00:00:00') as ndays_year"

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        While rdr.Read
            nhday = rdr.Item("holiday")
        End While
        rdr.Close()

        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        While rdr.Read
            list.Add(rdr.Item("hday"))
        End While
        rdr.Close()

        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str4)
        While rdr.Read
            ndays_year = rdr.Item("ndays_year")
        End While
        rdr.Close()

        Dim startyr As Integer = CInt(list.Item(0).Substring(0, 4))
        n = list.Count
        Dim endyr As Integer = CInt(list.Item(n - 1).Substring(0, 4))
        Dim mno As Integer = CInt(list.Item(0).Substring(5, 2))

        If mno <= 3 Then
            start_year_now = endyr
            end_year_now = endyr + 1
        Else
            start_year_now = startyr
            end_year_now = endyr
        End If

        'Response.Write(start_year_now)
        'Response.Write(end_year_now)

        wdays_year = ndays_year - nhday
        'Response.Write(wdays_year)
        'Dim sundays As Integer
        'If ndays_year = 365 Then
        '    sundays = 52
        'Else

        'End If
        con.Close()
    End Sub

    Sub working_days_tilldate(ByVal syr As String, ByVal eyr As String)
        Dim rdr As SqlDataReader

        '  Dim con As SqlConnection = New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;Persist Security Info=True;User ID=sa;Password=sadev123")
        Dim str1 As String = "select count(distinct date) holiday from mm_calendar_dump where date between '" & syr & "-04-01 00:00:00' and getdate()"
        Dim str2 As String = "select distinct convert(varchar, date, 111) hday from mm_calendar_dump where date between '" & syr & "-04-01 00:00:00' and getdate() order by hday"
        Dim str3 As String = "select DATEDIFF(day,getdate(),'" & eyr & "-03-31 00:00:00') as tilldate"
        Dim str4 As String = "select DATEDIFF(day,'" & syr & "-04-01 00:00:00','" & eyr & "-03-31 00:00:00') as ndays_year"

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        While rdr.Read
            nhday = rdr.Item("holiday")
        End While
        rdr.Close()

        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        While rdr.Read
            list.Add(rdr.Item("hday"))
        End While
        rdr.Close()

        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str3)
        While rdr.Read
            tilldate = rdr.Item("tilldate")
        End While
        rdr.Close()

        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str4)
        While rdr.Read
            ndays_year = rdr.Item("ndays_year")
        End While
        rdr.Close()

        Dim startyr As Integer = CInt(list.Item(0).Substring(0, 4))
        n = list.Count
        Dim endyr As Integer = CInt(list.Item(n - 1).Substring(0, 4))
        Dim mno As Integer = CInt(list.Item(0).Substring(5, 2))

        If mno <= 3 Then
            start_year_now = endyr
            end_year_now = endyr + 1
        Else
            start_year_now = startyr
            end_year_now = endyr
        End If

        ' Response.Write(start_year_now)
        ' Response.Write(end_year_now)

        wdays_tilldate = ndays_year - nhday - tilldate
        'Response.Write(wdays_tilldate)
        con.Close()
    End Sub


End Class