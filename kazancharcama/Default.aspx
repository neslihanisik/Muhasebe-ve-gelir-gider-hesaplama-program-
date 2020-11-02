<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="kazancharcama.Ekle" %>
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
                          <table class="table table-striped table-advance table-hover">
                               
                                     
                              <thead>
                              <tr>
                                  <th><i class="icon- icon-plus"></i> Kazançlar</th>
                                  <th class="hidden-phone"><i class="icon-question-sign"></i> Açıklama</th>
                                  <th><i class="icon-plus"></i> Gelir Miktarı</th>
                                  <th><i class=" icon-edit"></i> Düzenleme</th>
                                  <th><i class=" icon-edit"></i> Sil</th>
                                  
                              </tr>
                              </thead>
                             
                              <tbody>
                                  
                                   <asp:DataList ID="txtGelirListele" runat="server">
                                          <itemtemplate>
                              <tr>
                                      
                                   <td>&nbsp;<i class=" icon-money">&nbsp;</i><%#Eval("gelir_adi")%>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;</td>
                                  <td class="hidden-phone">&nbsp;<%#Eval("gelir_aciklama")%>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;</td>
                                    <td>&nbsp;<%#Eval("gelir_tutari")%>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;</td>
                                  <td>&nbsp;<button type="button" id="txtGelirDuzenle" class="btn btn-shadow btn-success" onclick="btnDuzenle_Click"><a href="gelir_güncelle.aspx">  Düzenle </a></button>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;</td>
                                  <td>&nbsp;<button type="button" id="txtGelirSil" class="btn btn-shadow btn-danger" onclick="btnSil_Click"><a href="gelir_sil.aspx">  Sil </a></button>
                           </td>
                             
                              </tr>
                              </itemtemplate>
                                </asp:DataList>
                              </tbody>
                            
                          </table>
                       
                          
                      </section>
                  </div>
                     <div class="col-sm-6">
                      
                       
                          <div class="panel-body">
                              <button type="button" id="txtGelirEkle" class="btn btn-shadow btn-success" onclick="btnEkle_Click"><a href="gelir_ekle.aspx">  Gelir Ekle </a></button>
                           
                             
                          </div>
                   
            
              </div>
                    </div>
        
                  
              
                
             
              <!-- page end-->
          </section>
      </section>
</asp:Content>
