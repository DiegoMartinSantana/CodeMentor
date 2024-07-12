<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdminInscripciones.aspx.cs" Inherits="CodeMentor.AspxAdmin.AdminInscripciones1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/AdminInscripciones.css" rel="stylesheet" />
    <div class="container mt-5">
        <div class="row col">

            <h2 class="mb-4 text-center">ADMINISTRACIÓN INSCRIPCIONES</h2>
            <div class="content-container">
                <div style="width: 100%">
                    <asp:Button Text="Todas" CssClass="btn btn-primary" runat="server" ID="BtnTodas" OnClick="BtnTodas_Click" />

                    <asp:Button Text="Pendientes de Habilitacion" CssClass="btn btn-secondary" runat="server" ID="BtnPendientes" OnClick="BtnPendientes_Click" />
                    <asp:Button Text="Habilitadas" CssClass="btn btn-secondary" runat="server" ID="Button1" OnClick="BtnHabilitados_Click" />

                    <asp:Button Text="Dadas de Baja" CssClass="btn btn-secondary" runat="server" ID="BtnDadasBaja" OnClick="BtnDadasBaja_Click" />

                </div>
                <div class="gridview-container">
                    <asp:GridView ID="GridViewInscripciones" DataKeyNames="IdInscripcion" CssClass="grid table table-striped" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField HeaderText="IdInscripcion" DataField="IdInscripcion" Visible="false" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                            <asp:BoundField HeaderText="Curso" DataField="NombreCurso" />
                            <asp:TemplateField HeaderText="Habilitar/Deshabilitar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkHabilitar" runat="server" Checked='<%# Eval("Habilitada") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Baja/Alta">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEliminar" runat="server" Checked='<%# Eval("Baja") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                </div>
                <div class="col-12" style="margin-left:122%" >

                    <asp:Button ID="btnHabilitar"  CssClass="btn btn-primary me-2" Text="Gestionar Habilitaciones" OnClick="btnHabilitar_Click" runat="server" />
                    <asp:Button ID="btnConfirmarEliminacion"  CssClass="btn btn-primary me-2" Text="Gestionar Altas/Bajas" OnClick="btnConfirmarEliminacion_Click" runat="server" />

                </div>
                <h5 id="H5Info" runat="server"></h5>
            </div>
        </div>


    </div>

</asp:Content>
