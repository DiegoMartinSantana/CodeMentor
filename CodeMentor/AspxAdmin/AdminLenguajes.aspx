<%@ Page Title="Administracion de Lenguajes" Language="C#" MasterPageFile="~/Masters/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdminLenguajes.aspx.cs" Inherits="CodeMentor.AspxAdmin.AdminLenguajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../Content/AdminCursos.css" rel="stylesheet" />

    <%--CONTENEDOR PRINCIPAL--%>
    <div class="container" style="margin-top: 2%">

        <%--TITULO DE LA PAGINA--%>
        <div class="row">
            <div class="col-12 text-center mb-2">
                <h2 class="title">Lenguajes</h2>
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
            <div class="col-3 text-end">
                <asp:Button Text="Agregar Lenguajes" OnClick="BtnAgregarLenguaje_Click1" class="btn btn-primary mb-3" ID="BtnAgregarLenguaje" runat="server" />
            </div>
        </div>

        <%--LENGUAJES--%>
        <div class="row">
            <div class="col-8">
                <asp:GridView runat="server" ID="DgwLenguajes" OnRowCommand="DgwLenguajes_RowCommand" AutoGenerateColumns="False" CssClass="table-custom">
                    <Columns>
                        <asp:BoundField DataField="IdLenguaje" Visible="false" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <img src="https://i.ibb.co/tLj3k9V/codementor-isotipo-electric-indigo.png" alt="Certificado Icono" width="60" height="60" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre del Lenguaje" Visible="True" />
                        <asp:TemplateField HeaderText="Cursos Asociados" Visible="True">
                            <ItemTemplate>
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Ver" Style="width: 50%" CommandName="Cursos" CommandArgument='<%# Eval("IdLenguaje") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-4">

                <asp:Panel runat="server" ID="PanelCursosAsociados">
                    <h5 class="mb-4">Cursos Asociados :</h5>
                    <asp:Repeater runat="server" ID="RptCursosLenguaje">
                        <ItemTemplate>
                            <label class="form-control mb-3">
                                <%#Eval("Nombre")%>
                            </label>

                        </ItemTemplate>
                    </asp:Repeater>

                </asp:Panel>
                <asp:Panel runat="server" ID="PanelAgregarLenguaje">
                    <div class="card ">
                        <div class="card-header">
                            <h5 class="card-title">Agregar lenguaje</h5>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label>Nombre:</label>
                                <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" />
                            </div>
                            <asp:GridView runat="server" style="margin-top:3%;margin-bottom:1%" DataKeyNames="IdCurso" AutoGenerateColumns="false" CssClass="table-custom" ID="DgwCursosAsociar">
                                <Columns>
                                    <asp:BoundField DataField="IdCurso" HeaderText="IdCurso" Visible="false" />

                                    <asp:BoundField DataField="Nombre" HeaderText="Curso" Visible="True" />

                                    <asp:TemplateField HeaderText="Asociar" Visible="true">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAsociar" runat="server" CssClass="custom-checkbox" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>

                            </asp:GridView>
                        </div>
                        <div class="card-footer text-right">
                            <asp:Button ID="BtnAgregar" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAgregarLenguaje_Click" />
                            <asp:Button ID="BtnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" OnClick="BtnCancelar_Click" />
                        </div>
                    </div>
                </asp:Panel>

            </div>
        </div>


    </div>

</asp:Content>

