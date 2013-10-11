<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Form_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtBusqueda" runat="server" ></asp:TextBox>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Buscar" />
    </div>

   
        <div class="Div_ContenidoSeccion" align="left">
        <div id="ListViewEntidad" class="ListView_Container">
            <asp:UpdatePanel ID="upnListado" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:ListView ID="lvListado" runat="server" DataKeyNames="ID_AYUDA">
                        <LayoutTemplate>
                            <table class="ListView_Style">
                                <thead>
                                    <tr>
                                        <th width="50px">
                                            Codigo
                                        </th>
                                        <th>
                                            Título
                                        </th>
                                        <th>
                                            Descripcion
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="ItemPlaceHolder" runat="server">
                                    </tr>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th class="ListView_Style_pie" colspan="3">
                                            <asp:Label ID="lblResultado" runat="server" CssClass="FuenteControles"></asp:Label>
                                            <span class="espaciado"></span>Nro. Página:
                                            <asp:DropDownList ID="ddlPaginas" runat="server" CssClass="FuenteControles" Width="50px"
                                                OnSelectedIndexChanged="ddlPaginas_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <span class="espaciado"></span>
                                            <asp:ImageButton ID="ibtnInicio" runat="server" CommandArgument="First" SkinID="skinbtnPrimero"
                                                OnClick="ibtnPaginacion_Click" />
                                            <asp:ImageButton ID="ibtnAtras" runat="server" CommandArgument="Prev" SkinID="skinbtnAnterior"
                                                OnClick="ibtnPaginacion_Click" />
                                            <asp:ImageButton ID="btnAdelante" runat="server" CommandArgument="Next" SkinID="skinbtnSiguiente"
                                                OnClick="ibtnPaginacion_Click" />
                                            <asp:ImageButton ID="btnFinal" runat="server" CommandArgument="Last" SkinID="skinbtnUltimo"
                                                OnClick="ibtnPaginacion_Click" />
                                        </th>
                                    </tr>
                                </tfoot>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr class="ListView_Style_item">
                                <td align="center" style="width: 50px">
                                    <%#Eval("CODIGO_AYUDA")%>
                                </td>
                                <td align="center" style="width: 200px">
                                    <%#Eval("TITULO_AYUDA")%>
                                </td>
                                <td align="center" style="width: 300px">
                                    <%#Eval("TEXTO_AYUDA")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="ListView_Style_odd">
                                <td align="center" style="width: 50px">
                                    <%#Eval("CODIGO_AYUDA")%>
                                </td>
                                <td align="center" style="width: 200px">
                                    <%#Eval("TITULO_AYUDA")%>
                                </td>
                                <td align="center" style="width: 300px">
                                    <%#Eval("TEXTO_AYUDA")%>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <EmptyDataTemplate>
                            <table class="ListView_Style">
                                <thead>
                                    <tr>
                                        <tr>
                                            <th width="50px">
                                                Codigo
                                            </th>
                                            <th>
                                                Título
                                            </th>
                                            <th>
                                                Descripcion
                                            </th>
                                        </tr>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="ItemPlaceHolder" runat="server">
                                        <td colspan="3" style="background-color: White; height: 18px">
                                            No se encontraron registros
                                        </td>
                                    </tr>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th class="ListView_Style_pie" colspan="3">
                                            <asp:Label ID="lblResultado" runat="server" CssClass="FuenteControles"></asp:Label>
                                            <span class="espaciado"></span>Nro. Página:
                                            <asp:DropDownList ID="ddlPaginas" runat="server" CssClass="FuenteControles" Width="50px"
                                                OnSelectedIndexChanged="ddlPaginas_SelectedIndexChanged" AutoPostBack="true"
                                                Enabled="False">
                                            </asp:DropDownList>
                                            <span class="espaciado"></span>
                                            <asp:ImageButton ID="ibtnInicio" runat="server" CommandArgument="First" SkinID="skinbtnPrimero"
                                                OnClick="ibtnPaginacion_Click" Enabled="False" />
                                            <asp:ImageButton ID="ibtnAtras" runat="server" CommandArgument="Prev" SkinID="skinbtnAnterior"
                                                OnClick="ibtnPaginacion_Click" Enabled="False" />
                                            <asp:ImageButton ID="btnAdelante" runat="server" CommandArgument="Next" SkinID="skinbtnSiguiente"
                                                OnClick="ibtnPaginacion_Click" Enabled="False" />
                                            <asp:ImageButton ID="btnFinal" runat="server" CommandArgument="Last" SkinID="skinbtnUltimo"
                                                OnClick="ibtnPaginacion_Click" Enabled="False" />
                                        </th>
                                    </tr>
                                </tfoot>
                            </table>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </ContentTemplate>
                <%--<Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ibtnBuscar" EventName="Click" />
                </Triggers>--%>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
