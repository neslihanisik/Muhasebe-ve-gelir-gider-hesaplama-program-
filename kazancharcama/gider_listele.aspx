<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="gider_listele.aspx.cs" Inherits="kazancharcama.gelir_listele" %>
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
                               Harcamalar
                          </header>
                          <table class="table table-striped table-advance table-hover">
                              <thead>
                              <tr>
                                  <th><i class="icon-minus"></i> Harcamalar</th>
                                  <th class="hidden-phone"><i class="icon-question-sign"></i> Açıklama</th>
                                  <th><i class="icon-minus"></i> Gider Miktarı</th>
                                  <th><i class=" icon-edit"></i> Düzenleme</th>
                                  <th><i class=" icon-edit"></i> Sil</th>
                                 
                              </tr>
                              </thead>
                            
                               
                             
                              <tbody>
                                  
                                   <asp:DataList ID="txtGiderListele"   runat="server">
                                          <itemtemplate>
                              <tr>
                                      
                                   <td>&nbsp;<i class=" icon-money">&nbsp;</i><%#Eval("harcama_adi")%>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;</td>
                                  <td class="hidden-phone">&nbsp;<%#Eval("harcama_aciklama")%>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;</td>
                                  <td>&nbsp;<%#Eval("harcama_tutari")%>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;</td>
                                  <td>&nbsp;<button type="button" id="txtGiderDuzenle" class="btn btn-shadow btn-success" onclick="btnDuzenle_Click"><a href="gider_güncelle.aspx">  Düzenle </a></button>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;</td>
                                  <td>&nbsp;<button type="button" id="txtGiderSil" class="btn btn-shadow btn-danger" onclick="btnSil_Click"><a href="gider_sil.aspx">  Sil </a></td>
                             
                              </tr>
                              </itemtemplate>
                                </asp:DataList>
                              </tbody>
                          </table>
                                     
                         
                          
                      </section>
                  </div>
                     <div class="col-sm-6">
                      
                       
                          <div class="panel-body">
                              <button type="button" id="txtGiderEkle" class="btn btn-shadow btn-success" onclick="btnEkle_Click"><a href="gider_ekle.aspx">  Gider Ekle </a></button>
                           
                             
                          </div>
                   
            
              </div>
              </div>
              <!-- page end-->
          </section>
      </section>
</asp:Content>
