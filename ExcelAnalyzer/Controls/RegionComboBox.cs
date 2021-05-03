using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelAnalyzer.Controls
{
    public class RegionComboBox: BaseComboBox
    {

        //    Private collection As TreeRegion
        //Private regions As IEnumerable(Of TreeRegion.Region)
        //Private _SelectedRegion As TreeRegion.Region

        //Public Sub SetRegion(ByVal code As Integer)
        //    For i As Integer = 0 To Me.regions.Count - 1
        //        If Me.regions(i).Code = code Then
        //            Me.SelectedIndex = i
        //            Me._SelectedRegion = Me.regions(MyBase.SelectedIndex)
        //            Exit Sub
        //        End If
        //    Next
        //End Sub

        //Public ReadOnly Property SelectedRegion() As TreeRegion.Region
        //    Get
        //        Return Me._SelectedRegion
        //    End Get
        //End Property

        #region Initialize
        public RegionComboBox() : base() { }

        [System.Diagnostics.DebuggerNonUserCode()]
        public RegionComboBox(System.ComponentModel.IContainer container):base(container: container) { }

        public override int Add(int code, string text)
        {
           return this.Add(new RegionItem(code: code, text:text));
        }

        #endregion

        //#Region "Events"

        //    Public Sub SetRegions(ByVal collection As TreeRegion)
        //        Me.collection = collection
        //        If IsNothing(Me.collection) Then Exit Sub
        //        Me.regions = collection.GetRegions
        //        Me.Clear()
        //        Dim w As Integer = 0
        //        Dim g As Graphics = Me.CreateGraphics

        //        For i As Integer = 0 To Me.regions.Count - 1
        //            Me.Add(i)
        //            Dim s As SizeF = g.MeasureString(Me.regions(i).Code & Me.regions(i).Caption & "FFFFFF", Me.Font)
        //            If w<s.Width Then w = s.Width
        //        Next
        //        Me.DropDownWidth = w + SystemInformation.VerticalScrollBarWidth
        //        If Me.Items.Count > 0 Then Me.SelectedIndex = 0
        //    End Sub

        //    Private Sub Control_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectedIndexChanged
        //        If MyBase.SelectedIndex< 0 _
        //        OrElse IsNothing(Me.regions) Then
        //            Me._SelectedRegion = Nothing
        //        Else
        //            Me._SelectedRegion = Me.regions(MyBase.SelectedIndex)
        //        End If
        //    End Sub

        //#End Region


        public class RegionItem : BaseComboBox.IComboBoxItem
        {

            public RegionItem(int code, string text)
            {
                this.Code = code;
                this.Text = text;
            }

            public int Code { get; }
            public string Text { get; }            
        }
    }
}
