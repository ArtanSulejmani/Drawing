Imports System.Drawing

Public Class Form1

    Dim Draw As Boolean
    Dim DrawColor As Color = Color.Black
    Dim DrawSize As Integer = 6

    Dim bmp As Bitmap

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 2

        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = bmp
    End Sub

    Private Sub PaintBrush(X As Integer, Y As Integer)
        Using g As Graphics = Graphics.FromImage(PictureBox1.Image)
            g.FillRectangle(New SolidBrush(DrawColor), New Rectangle(X, Y, DrawSize, DrawSize))
        End Using
        PictureBox1.Refresh()

    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        Draw = True

        PaintBrush(e.X, e.Y)
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If Draw = True Then
            PaintBrush(e.X, e.Y)
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        Draw = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = bmp
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        DrawSize = ComboBox1.SelectedItem
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            DrawColor = ColorDialog1.Color

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox1.DrawToBitmap(bmp, New Rectangle(0, 0, PictureBox1.Width, PictureBox1.Height))
        bmp.Save("Test1.png", Imaging.ImageFormat.Png)

        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
    End Sub


End Class
