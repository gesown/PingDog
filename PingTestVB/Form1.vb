Imports Microsoft.VisualBasic.Devices
Public Class Form1
    Friend PortCollection
    Friend PortName
    Friend bytesInCount
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PortCollection = My.Computer.Ports.SerialPortNames()
        PortName = PortCollection(0)
        port.PortName = PortName
        port.Open()
        port.WriteLine("Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This ")
        txtOut.Text = "Form Loaded."
    End Sub

    Private Sub port_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles port.DataReceived

        txtOut.Text = "TEST THIS"
        ' txtOut.Text = txtOut.Text + "Data Received."
    End Sub

    Private Sub port_ErrorReceived(sender As Object, e As IO.Ports.SerialErrorReceivedEventArgs) Handles port.ErrorReceived
        txtOut.Text = txtOut.Text + "Error Received."

    End Sub

    Private Sub port_PinChanged(sender As Object, e As IO.Ports.SerialPinChangedEventArgs) Handles port.PinChanged
        txtOut.Text = txtOut.Text + "Pin Changed."

    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        port.WriteLine("Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This Test This ")
        bytesInCount = port.BytesToRead
        txtOut.Text = txtOut.Text + "bytes: " + bytesInCount
    End Sub
End Class
