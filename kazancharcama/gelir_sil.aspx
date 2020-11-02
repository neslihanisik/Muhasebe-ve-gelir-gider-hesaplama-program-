<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="gelir_sil.aspx.cs" Inherits="kazancharcama.gelir_sil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	  <!--sidebar end-->
      <!--main content start-->
      <section id="main-content">
          <section class="wrapper">
              <!-- page start-->
              
              
              <div class="row">
                  <div class="col-lg-12">
                      <section class="panel">
                          <header class="panel-heading">
                              Kazançlar 
                          </header>
                   <table class="style1">
            <tbody><tr>
                <td class="style2">
                    <asp:label id="lblHata" runat="server"></asp:label>
                </td>
                <td>
                     </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:dropdownlist id="DDLGelirListesi" runat="server" width="200px">
                    </asp:dropdownlist>
                </td>
                <td>
                    <asp:button id="btnGelirSil" runat="server" style="font-weight: 700" text="Gelir Sil" width="100px" OnClick="btnGelirSil_Click">
                </asp:button></td>
            </tr>
            <tr>
                <td class="style2">
                     </td>
                <td>
                     </td>
            </tr>
        </tbody></table>
                          
                         </section>
                                </div>
              </div>
               
      <!-- page end-->
          </section>
      </section>
</asp:Content>
