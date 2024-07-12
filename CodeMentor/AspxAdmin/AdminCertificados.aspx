<%@ Page Title="Administración de Certificados  " Language="C#" MasterPageFile="~/Masters/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdminCertificados.aspx.cs" Inherits="CodeMentor.AspxAdmin.AdminCertificados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/AdminCursos.css" rel="stylesheet" />

    <%--CONTENEDOR PRINCIPAL--%>
    <div class="container" style="margin-top: 2%">

        <%--TITULO--%>
        <div class="row">
            <div class="col-12 text-center mb-2">
                <h2 class="title">Certificados</h2>
            </div>
        </div>

        <%--FILTROS--%>
        <div class="row">
            <p class="mb-3">Ordenar por:</p>
            <div class="col-3 d-flex align-items-center">
                <asp:DropDownList OnSelectedIndexChanged="ddlAZ_SelectedIndexChanged" ID="ddlAZ" AutoPostBack="true" runat="server" CssClass="form-control form-select btn-secondary mb-3">
                    <asp:ListItem Text="A-Z" Value="2" />
                    <asp:ListItem Text="Z-A" Value="1" />
                </asp:DropDownList>
            </div>
        </div>

        <%--CERTIFICADOS--%>
        <div class="row">
            <div class="col-12">
                <asp:GridView runat="server" ID="DgwCertificados" AutoGenerateColumns="False" CssClass="table-custom">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <img src="https://i.ibb.co/Bn577Ng/certificado-icono.png" alt="Certificado Icono" width="60" height="60" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IdCertificacion" Visible="false" />
                        <asp:BoundField DataField="NombreCurso" HeaderText="Curso" Visible="True" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre Usuario" Visible="True" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido Usuario" Visible="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
