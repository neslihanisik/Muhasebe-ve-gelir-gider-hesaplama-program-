<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="gider_ekle.aspx.cs" Inherits="kazancharcama.gider_ekle" %>
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
                            Gider Ekle
                          </header>
                          <div class="panel-body">
                              <form role="form" class="form-horizontal tasi-form">
                                  <div class="form-group has-success">
                                      <label class="col-lg-2 control-label" for="txtGiderAdi">Gider Adı</label>
                                     
                                   
                                         <asp:Textbox runat="server" ID="txtGiderAdi" CssClass="form-control" />
                                    
                                  </div>
                                  <div class="form-group has-error">
                                      <label class="col-lg-2 control-label" for="txtGiderTutari">Gider Tutarı</label>
                                    
                                           <asp:Textbox runat="server" ID="txtGiderTutari" CssClass="form-control" />
                                     
                                  </div>
                                  <div class="form-group has-warning">
                                      <label class="col-lg-2 control-label" for="txtGiderAciklama">Açıklama</label>
                                   
                                         <asp:Textbox runat="server" ID="txtGiderAciklama" CssClass="form-control" />
                                     
                                  </div>

                                  <div class="form-group">
                                      <div class="col-lg-offset-2 col-lg-10">
                                          
                                          <asp:Button Text="Kaydet" runat="server" ID="btnKaydet" CssClass="btn btn-success" OnClick="btnKaydetGider_Click"/>
                                      </div>
                                  </div>
                                     <div class="form-group">
                                      <div class="col-lg-offset-2 col-lg-10">
                                         <asp:label id="lblHata" runat="server" forecolor="Red"></asp:label>
                                      </div>
                                  </div>
                              </form>
                          </div>
                      </section>
                  </div>
              </div>
                </section>
      </section>
</asp:Content>
