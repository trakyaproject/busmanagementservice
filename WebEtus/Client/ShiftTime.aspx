<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShiftTime.aspx.cs" Inherits="Client_ShiftTime" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
             <ext:Hidden runat="server" ID="hdnST"></ext:Hidden>
        <ext:GridPanel ID="grdST" runat="server"  AutoScroll="true">
        <TopBar>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                 <ext:Button runat="server" ID="btnAddNew" Text="Ekle" Icon="Add" OnDirectClick="btnAddNew_DirectClick">
                 </ext:Button>
                    <ext:Button ID="btnGet" runat="server" Icon="Find" OnDirectClick="btnGet_DirectClick" Text="Listele">
                        <DirectEvents>
                            <Click Timeout="2000000">
                                <EventMask Msg="Kayıtlar Getiriliyor. Lütfen bekleyiniz..." ShowMask="true"></EventMask>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </TopBar>
          <Store>
                <ext:Store ID="Store1" runat="server" PageSize="10">
                    <Model>
                        <ext:Model runat="server" IDProperty="shiftTimeId">
                            <Fields>
                                <ext:ModelField Name="shiftTimeId" />
                                <ext:ModelField Name="departureTime" />
                                <ext:ModelField Name="plate" />
                                <ext:ModelField Name="nameSurname" />
                                <ext:ModelField Name="lineName" />
                                <ext:ModelField Name="driverId" />
                                <ext:ModelField Name="lineId" />
                                <ext:ModelField Name="stiftStart" />
                                <ext:ModelField Name="shiftEnd" />
                                <ext:ModelField Name="state" />
                                <ext:ModelField Name="createdAt" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
        <ColumnModel  runat="server">
            <Columns>
                <ext:RowNumbererColumn runat="server" Text="Sıra No" Width="80"></ext:RowNumbererColumn>
                <ext:Column runat="server" DataIndex="shiftTimeId" Flex="2" Visible="false" Text="" ></ext:Column>
                <ext:Column  runat="server" DataIndex="departureTime" Flex="2" Text="Kalkış Zamanı"></ext:Column>
                <ext:Column runat="server" DataIndex="plate" Flex="2" Text="Plaka"></ext:Column>
                <ext:DateColumn runat="server" DataIndex="nameSurname" Flex="2" Text="Şoför Bilgileri"></ext:DateColumn>
                <ext:Column runat="server" DataIndex="lineName" Flex="2" Text="Hat Bilgileri"></ext:Column>
                <ext:Column  runat="server" DataIndex="driverId" Flex="2" Visible="false" Text="Telefon"></ext:Column>
                <ext:Column  runat="server" DataIndex="lineId" Flex="2" Visible="false"  Text="Adres"></ext:Column>
                <ext:Column  runat="server" DataIndex="stiftStart" Flex="2" Text="Başlangıç Zamanı"></ext:Column>
                 <ext:Column  runat="server" DataIndex="shiftEnd" Flex="2" Text="Bitiş Zamanı"></ext:Column>
                <ext:Column  runat="server" DataIndex="state" Flex="2" Text="Durum"></ext:Column>
                <ext:DateColumn runat="server" DataIndex="createdAt" Flex="2" Text="Tarih"></ext:DateColumn>
             </Columns>
        </ColumnModel>
        </ext:GridPanel>
       <ext:Window ID="WindowST" 
            runat="server" 
            Width="600"
            Modal="true"
            CloseAction = "Destroy"
            Hidden="true"          
            Closable="true"
            BodyPadding="5"
            Layout="FormLayout"
          >           
            <Items>
                <ext:TextField ID="txtshiftTimeId" runat="server"  FieldLabel="Sıra No" ReadOnly="true" Visible="true" AllowBlank="false"/>
                 <ext:ComboBox runat="server" ID="cmbdepartureTime" FieldLabel="Kalkış Zamanı" padding="10" >
                     <Items>
                         <ext:ListItem Value="-1" Text="Lütfen zaman seçiniz"></ext:ListItem>
                         <ext:ListItem  Value="Dt" Text="08:00"></ext:ListItem>
                     </Items>
                 </ext:ComboBox>
                 <ext:ComboBox runat="server" ID="cmb" FieldLabel="Kalkış Yeri" padding="10" >
                     <Items>
                         <ext:ListItem  Value="Dt" Text="Otogar"></ext:ListItem>
                         <ext:ListItem  Value="Dt" Text="Gazimihal"></ext:ListItem>
                         <ext:ListItem  Value="Dt" Text="Sarayiçi"></ext:ListItem>
                         <ext:ListItem  Value="Dt" Text="Pazartesi Pazarı"></ext:ListItem>
                         <ext:ListItem  Value="Dt" Text="Karaağaç"></ext:ListItem>
                         <ext:ListItem  Value="Dt" Text="Yeni Devlet Hastanesi"></ext:ListItem>
                         <ext:ListItem  Value="Dt" Text="Eski Toki"></ext:ListItem>
                      </Items>
                 </ext:ComboBox>
                <ext:ComboBox ID="cmbplate" runat="server" FieldLabel="Plaka" padding="10" />               
                <ext:ComboBox  ID="cmbnameSurname" runat="server" FieldLabel="Adı Soyadı" padding="10" />
                <ext:ComboBox  ID="cmblineName" runat="server" FieldLabel="Hat Bilgileri" padding="10" >
                     <Items>
                         <ext:ListItem Value="-1" Text="Lütfen hat seçiniz"></ext:ListItem>
                         <ext:ListItem  Value="1" Text="1"></ext:ListItem>
                         <ext:ListItem  Value="1A" Text="1A"></ext:ListItem>
                         <ext:ListItem  Value="1T" Text="1T"></ext:ListItem>
                         <ext:ListItem  Value="2A" Text="2A"></ext:ListItem>
                         <ext:ListItem  Value="2B" Text="2B"></ext:ListItem>
                         <ext:ListItem  Value="3" Text="3"></ext:ListItem>
                         <ext:ListItem  Value="3A" Text="3A"></ext:ListItem>
                         <ext:ListItem  Value="3B" Text="3B"></ext:ListItem>
                         <ext:ListItem  Value="3C" Text="3C"></ext:ListItem>
                         <ext:ListItem  Value="4" Text="4"></ext:ListItem>
                         <ext:ListItem  Value="5A" Text="5A"></ext:ListItem>
                         <ext:ListItem  Value="5B" Text="5B"></ext:ListItem>
                         <ext:ListItem  Value="5C" Text="5C"></ext:ListItem>
                         <ext:ListItem  Value="6A" Text="6A"></ext:ListItem>
                         <ext:ListItem  Value="7B" Text="7B"></ext:ListItem>
                     </Items>
                 </ext:ComboBox>
                <ext:ComboBox  ID="cmbstiftStart" runat="server" FieldLabel="Başlangıç Zamanı" padding="10" />
                <ext:ComboBox  ID="cmbshiftEnd" runat="server" FieldLabel="Bitiş Zamanı" padding="10" />
                <ext:Button runat="server" ID="Add" Text="Kaydet" OnDirectClick="btnKaydet_DirectClick" >
                    <DirectEvents>
                               <Click>
                                   <EventMask ShowMask="true" Msg="Kayıt ediliyor."></EventMask>
                               </Click>
                           </DirectEvents>
                        </ext:Button>
            </Items>            
        </ext:Window>     
          <ext:Window runat="server" ID="wndDeleteConfirm" Title="Silme Onayı" Modal="true" Hidden="true" Width="300"  Height="100" BodyStyle="background-color:white;">
            
              <Items>
                <ext:Hidden ID="hdnDriverDelete" runat="server"></ext:Hidden>
                <ext:Label runat="server" ID="lblDeleteConfim" HTML="silmek istediğinizden <b>emin misiniz?</b>"></ext:Label>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDeleteConfirmSave" OnDirectClick="btnDelete_DirectClick" Text="Sil" Icon="DatabaseDelete"></ext:Button>
                <ext:Button runat="server" ID="btnDeleteConfirmCancel" OnDirectClick="btnCancel_DirectClick" Text="Vazgeç" Icon="Cancel"></ext:Button>
            </Buttons>
        </ext:Window>       
        </form>
  </body>
</html>