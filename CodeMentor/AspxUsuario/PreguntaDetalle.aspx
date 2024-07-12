<%@ Page Title="Pregunta" Language="C#" MasterPageFile="~/Masters/MasterUsuario.Master" AutoEventWireup="true" CodeBehind="PreguntaDetalle.aspx.cs" Inherits="CodeMentor.AspxUsuario.PreguntaDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .Acomodar {
            margin-top: 6.5%;
            margin-left: 25%;
            margin-right: 25%;
            margin-bottom: 11%;
        }
    </style>
   
    <asp:Panel runat="server" ID="PregUsuario">

       
        <%if (Modificar != null)
            { %>

            <div class="list-group Acomodar">
                <div class="mb-3">
                <h5>Modifique su Pregunta</h5>
                    
                </div>
                <div class="list-group-item" style="margin-bottom: 2%; border-radius: 15px">
                    <div class="d-flex w-100 justify-content-between" style="margin-top: 0.8%">
                    <asp:TextBox ID="TxtTitulo" runat="server" CssClass="form-control" style="width:90%" placeholder="Ingresa el título de tu pregunta" />

                        <div class="mb-2"> 
                        <asp:ImageButton ImageUrl="https://cdn-icons-png.flaticon.com/512/6861/6861362.png" style="width:30px;height:30px" Id="BtnEliminar" OnClick="BtnEliminar_Click" runat="server" />
                        </div>

                    </div>
                    <asp:TextBox ID="TxtCuerpo" runat="server"  style="margin-top:2%"   TextMode="MultiLine" Rows="5" CssClass="form-control form-text mb-1" placeholder="Describe tu pregunta en detalle" />

                    <small><%:Modificar.Fecha %></small>


                </div>
                <div class="mb-3">
                    <p>Su pregunta no ha sido respondida por el momento. Puede hacer modificaciones.</p>
                    <a href="PreguntasRespuestas.aspx" class="btn btn-secondary">Cancelar</a>

                    <asp:Button Text="Guardar Cambios" ID="BtnGuardarCambios" OnClick="BtnGuardarCambios_Click" CssClass="btn btn-secondary" style="margin-left:1%" runat="server" />
                    <asp:Label style="color:red;margin-left:2%" Text="No se han producido Cambios" ID="LblNoCambios" runat="server" />
                    <asp:Button Text="Confirmar Eliminacion" ID="BtnConfirmarBorrar" OnClick="BtnConfirmarBorrar_Click" runat="server" CssClass="btn btn-outline-danger" />
                </div>
            </div>


        <%} %>
               
    </asp:Panel>

</asp:Content>
