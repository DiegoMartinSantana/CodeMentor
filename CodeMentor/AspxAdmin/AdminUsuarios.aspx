<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdminUsuarios.aspx.cs" Inherits="CodeMentor.AdminAspx.AdminUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" class="curso-contenedor">
    <link href="../Content/AdminUsuarios.css" rel="stylesheet" />
    <div class="container mt-5">
        <h1 class="text-center mb-3">Administración de Usuarios</h1>

        <asp:Label ID="lblCantUsuarios" CssClass="custom-label" Style="font-size: 30px; margin-bottom: 2%" runat="server" Text=""></asp:Label>

        <!-- GridView de Usuarios -->
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card ">
                    <div class="card-header text-white text-center" style="background-color: #2980b9">
                        <h3>Usuarios Inscriptos</h3>
                    </div>
                    <div class="card-body">
                        <asp:Panel runat="server">
                            <asp:GridView ID="gviewUsuarios" OnSelectedIndexChanged="gviewUsuarios_SelectedIndexChanged" DataKeyNames="Idusuario" CssClass="table table-hover table-striped" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField HeaderText="Idusuario" DataField="Idusuario" HeaderStyle-CssClass="d-none" ItemStyle-CssClass="d-none" />
                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                                    <asp:BoundField HeaderText="Email" DataField="Email" />
                                    <asp:TemplateField HeaderText="Estado">
                                        <ItemTemplate>
                                            <%# Convert.ToBoolean(Eval("Baja")) ? "<i class='fas fa-times text-danger'></i>" : "<i class='fas fa-check text-success'></i>" %>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:BoundField HeaderText="País" DataField="Pais" />
                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkEliminar" runat="server" CssClass="custom-checkbox" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <p class="text-danger" id="ErrorEliminar" visible="false" runat="server"></p>
                            <div class="d-flex justify-content-end mt-3">
                                <asp:Button ID="btnConfirmaEliminacion" CssClass="btn btn-danger me-2" Text="Confirma Eliminación" OnClick="btnConfirmaEliminacion_Click" runat="server" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
