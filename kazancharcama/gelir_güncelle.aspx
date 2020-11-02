<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="gelir_güncelle.aspx.cs" Inherits="kazancharcama.gelir_güncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section id="main-content">
          <section class="wrapper">
              <!-- page start-->
              
              
              <div class="row">
                  <div class="col-lg-12">
                      <section class="panel">
                          <header class="panel-heading">
                              Gelir Güncelle
                          </header>
                           <table class="style1">
        <tbody><tr>
            <td class="style2">
                <asp:label id="lblHata" runat="server"></asp:label>
            </td>
            <td class="style5">
                 </td>
            <td>
                 </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:dropdownlist id="ddlGelirListe" runat="server" width="200px">
                </asp:dropdownlist>
            </td>
            <td class="style5">
                 </td>
            <td>
                 </td>
        </tr>
        <tr>
            <td class="style7">
                <asp:button id="Button1" runat="server" style="font-weight: 700" text="Seçiniz" onClick="btnSeciniz_Click">
            </asp:button></td>
            <td class="style8">
            </td>
            <td class="style9">
            </td>
        </tr>
        <tr>
            <td class="style2">
                Gelir Adi
            </td>
            <td class="style5">
                :</td>
            <td>
                <asp:textbox id="txtGelirAdi" runat="server" width="200px"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Gelir Tutari</td>
            <td class="style5">
                :</td>
            <td>
                <asp:textbox id="txtGelirTutari" runat="server" width="200px"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Gelir Açıklama</td>
            <td class="style6">
                :</td>
            <td class="style4">
                <asp:textbox id="txtGelirAciklama" runat="server" width="200px"></asp:textbox>
            </td>
        </tr>
       
        <tr>
            <td class="style2">
                 </td>
            <td class="style5">
                 </td>
            <td>
               <asp:button id="btnGuncelle" runat="server" style="font-weight: 700" text="Güncelle"  onClick="btnGuncelle_Click">
            </asp:button></td>
        </tr>
    </tbody></table>
                          </div>
                       
            <!-- page end-->
          </section>
      </section>
</asp:Content>
