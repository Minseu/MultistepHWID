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
        ' Start HDD ID
        TextBox2.Text = GetDriveSerialNumber()
        ' END HDD ID
        ' START RM
        TextBox3.Text = My.Computer.Info.TotalPhysicalMemory
        ' END RM
        ' START FINAL HWID
        Dim RAM As String = TextBox2.Text
        RAM = RAM.Replace(".", "")
        Dim eHWID As String = RAM + TextBox1.Text + TextBox3.Text
        TextBox4.Text = getSHA1Hash(eHWID)
    End Sub
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
    Public Function GetDriveSerialNumber() As String
        Dim DriveSerial As Integer
        'Create a FileSystemObject object
        Dim fso As Object = CreateObject("Scripting.FileSystemObject")
        Dim Drv As Object = fso.GetDrive(fso.GetDriveName(Application.StartupPath))
        With Drv
            If .IsReady Then
                DriveSerial = .SerialNumber
            Else    '"Drive Not Ready!"
                DriveSerial = -1
            End If
        End With
        Return DriveSerial.ToString("X2")
    End Function
End Class
