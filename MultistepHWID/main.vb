Imports System.Management

Public Class main
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim HWID As String = String.Empty
        Dim mc1 As New ManagementClass("win32_processor")
        Dim kirsten As String = "192.158.123.344"
        Dim MOBC As ManagementObjectCollection = mc1.GetInstances()
        ' DIM 
        For Each mob As ManagementObject In MOBC
            If HWID = "" Then
                HWID = mob.Properties("processorID").Value.ToString()
                Exit For
            End If
        Next
        TextBox1.Text = HWID
        ' END PROCESSORID
        ' Start IP
        GetIPV4()
        TextBox2.Text = GetIPV4()
        ' END IPV4
        ' START RM
        TextBox3.Text = My.Computer.Info.TotalPhysicalMemory
        ' END RM
        ' START FINAL HWID
        Dim RAM As String = TextBox2.Text
        RAM = RAM.Replace(".", "")
        Dim eHWID As String = RAM + TextBox1.Text + TextBox3.Text
        TextBox4.Text = getSHA1Hash(eHWID)
    End Sub
    Private Function GetIPV4() As String
        GetIPV4 = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim ipheas As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)
        For Each ipheal As System.Net.IPAddress In ipheas.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPV4 = ipheal.ToString
            End If
        Next
    End Function
    Function getSHA1Hash(ByVal strToHash As String) As String

        Dim sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = sha1Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function
End Class
